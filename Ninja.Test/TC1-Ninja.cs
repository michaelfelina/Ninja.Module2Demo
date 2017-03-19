using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.DataModel;
using NUnit.Framework;

namespace Ninja.Test
{
    using Ninja.DomainClasses;

    [TestFixture]
    public class TC1_Ninja
    {
        NinjaContext context;
        public TC1_Ninja()
        {
            context = new NinjaContext();
            //initialize the clan
            var clan = new Clan()
            {
                ClanName = "VermontNinjas"
            };
            context.Clans.Add(clan);
        }

        [Test]
        public void Add()
        {
            try
            {
                var ninja = new Ninja
                {
                    Name = "Mike",
                    ClanId = 1,
                    ServeInOniwaban = true,
                    DateOfBirth = new DateTime(1980, 10, 22)
                };

                
                context.Ninjas.Add(ninja);
                context.SaveChanges();
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void Add_Many()
        {
            try
            {
                var ninja = new List<Ninja>()
                {
                    new Ninja()
                    {
                        Name = "Haidee",
                        ClanId = 1,
                        ServeInOniwaban = true,
                        DateOfBirth = new DateTime(1983, 7, 29)
                    },
                    new Ninja()
                    {
                        Name = "Jorj",
                        ClanId = 1,
                        ServeInOniwaban = true,
                        DateOfBirth = new DateTime(2010, 7, 30)
                    },

                };

                var context = new NinjaContext();
                context.Ninjas.AddRange(ninja);
                context.SaveChanges();
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void SelectNinjas()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas.ToList();
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1,0);
            }
                
        }
    }
}
