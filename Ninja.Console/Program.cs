using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.DataModel;
using Ninja.DomainClasses;

namespace Ninja.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjaContext context;
            context = new NinjaContext();
            //initialize the clan
            var clan = new Clan()
            {
                ClanName = "VermontNinjas"
            };
            context.Clans.Add(clan);

            var ninja = new DomainClasses.Ninja
            {
                Name = "Mike",
                ClanId = 1,
                ServeInOniwaban = true,
                DateOfBirth = new DateTime(1980, 10, 22)
            };


            context.Ninjas.Add(ninja);
            context.SaveChanges();
        }
    }
}
