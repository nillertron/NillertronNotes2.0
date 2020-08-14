using Microsoft.Extensions.DependencyInjection;
using NillertronNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NillertronNotes.Service
{
    public class NoteService
    {
        private List<Noter> _NoteListe { get; set; } = new List<Models.Noter>();

        private IServiceScopeFactory _scopeFactory;
        public NoteService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task<List<Noter>> Search(string searchWord)
        {
            var list = _NoteListe.Where(x => x.NoteText.ToLower().Contains(searchWord.ToLower()) || x.Overskrift.ToLower().Contains(searchWord.ToLower())).ToList();
            return list;
        }
        public async Task<List<Noter>> GetAllForSubject(int fagId)
        {
            if (_NoteListe.Count != 0)
            {
                _NoteListe.Clear();
            }
            var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<nillertron_com_dbContext>();
            using (dbContext)
            {
                _NoteListe = dbContext.Noter.Where(x => x.FagId == fagId).ToList();
            }


            return _NoteListe;

        }

        public async Task<string> WrapItUpBaby(string value)
        {
            var divStartTag = "<div class=\"ImgWrap\">";
            var endTag = "</div>";
            value = value.Replace("alt=\"Image\" class=\"img-responsive\"", "class=\"img-thumbnail\">");
            return value;

        }
        public async Task Create(Noter note)
        {
            var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetService<nillertron_com_dbContext>();
            using (db)
            {
                note.Skrevet = DateTime.Now;
                note.BrugerId = 1;
                db.Noter.Add(note);
                await db.SaveChangesAsync();
            }

        }

        public async Task<Noter> GetSpecific(int noteId)
        {
            var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetService<nillertron_com_dbContext>();
            using(db)
            {
                return db.Noter.Where(o => o.Id == noteId).FirstOrDefault();
            }
        }

        public async Task Update(Noter note)
        {
            var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetService<nillertron_com_dbContext>();
            using(db)
            {
                db.Noter.Update(note);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(Noter note)
        {
            var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetService<nillertron_com_dbContext>();
            using (db)
            {
                db.Noter.Remove(note);
                await db.SaveChangesAsync();
            }

        }

    }
}
