using Microsoft.Extensions.DependencyInjection;
using NillertronNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NillertronNotes.Service
{
    public class FagService
    {
        private IServiceScopeFactory _scopeFactory;
        public FagService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<List<Fag>> GetAll()
        {
            var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<nillertron_com_dbContext>();
            using (context)
            {
                return context.Fag.ToList();
            }
        }
        public async Task<Fag> GetFagById(int id)
        {
            var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<nillertron_com_dbContext>();
            using (context)
            {
                return context.Fag.Where(x=> x.Id == id).FirstOrDefault();
            }
        }
    }
}
