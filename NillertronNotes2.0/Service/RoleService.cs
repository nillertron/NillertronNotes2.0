using Microsoft.Extensions.DependencyInjection;
using NillertronNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NillertronNotes.Service
{
    public class RoleService
    {
        private IServiceScopeFactory _scopeFactory;
        public RoleService(IServiceScopeFactory fac)
        {
            _scopeFactory = fac;
        }
        /// <summary>
        /// Brugt for at indsætte admin rollen, ikke brugbar metode
        /// </summary>
        private void SortRoles()
        {
            var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<nillertron_com_dbContext>();
            using (dbContext)
            {
                var role = new AspNetRoles { Id = "1", Name = "Admin", NormalizedName = "ADMIN" };
                dbContext.Add(role);
                dbContext.SaveChanges();
                role = dbContext.AspNetRoles.Where(x => x.Name == "Admin").FirstOrDefault();
                var user = dbContext.AspNetUsers.Where(x => x.UserName == "nichlaschristensen@live.dk").FirstOrDefault();
                var roleLine = new AspNetUserRoles { Role = role, User = user, RoleId = role.Id, UserId = user.Id };
                dbContext.Add(roleLine);
                dbContext.SaveChanges();
            }

        }
    }
}
