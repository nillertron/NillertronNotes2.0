using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NillertronNotes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NillertronNotes.Service
{
    public class FilService
    {
        private List<FagFiler> _filListe = new List<FagFiler>();
        private IServiceScopeFactory _scopeFactory;
        private IWebHostEnvironment env;
        public FilService(IServiceScopeFactory scopeFactory, IWebHostEnvironment env)
        {
            _scopeFactory = scopeFactory;
            this.env = env;
        }
        public async Task<List<FagFiler>> GetAllForSubject(int fagId)
        {
            var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<nillertron_com_dbContext>();
            using(dbContext)
            {
                var list = dbContext.FagFiler.Where(x => x.FagId == fagId).ToList();
                list.ForEach(x => x.Url = "files/studie/" + x.Url);
                _filListe = list;
                return list;
            }
        }

        public async Task CreateFile(FagFiler fil, int fagId)
        {
            fil.Uploadet = DateTime.Now;
            fil.FagId = fagId;

            var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetService<nillertron_com_dbContext>();
            using (db)
            {
                db.FagFiler.Add(fil);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<FagFiler>> Search(string searchWord)
        {
            
            if(searchWord == "" || searchWord == string.Empty)
            {
                return _filListe;

            }
            else
            {
                searchWord = searchWord.ToLower();
                var list = _filListe.Where(x => x.Beskrivelse.ToLower().Contains(searchWord) || x.DisplayName.ToLower().Contains(searchWord)).ToList();
                return list;
            }
        }

        public async Task DeleteFile(FagFiler file)
        {
            var root = env.WebRootPath;
            var filePlacement = file.Url;
            var path = Path.Combine(root, filePlacement);
            File.Delete(path);
            var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetService<nillertron_com_dbContext>();
            using(db)
            {
                db.Remove(file);
                await db.SaveChangesAsync();
            }

        }
            
    }
}
