using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            context.Clans.AddOrUpdate(clan);
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

        [Test]
        public void SelectNinja_ById()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas.Find(12);
                Console.WriteLine(ninjas.Name);
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void SelectNinjas_WithWhere_SingleResult()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas
                    .ToList().Where(n => n.Name == "Jordyn")
                    .FirstOrDefault();
                if (ninjas != null)
                    Console.WriteLine(ninjas.Name);
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void SelectNinjas_WithWhere_Contains()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas
                    .ToList().Where(n => n.Name.Contains("Jor"));
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void SelectNinjas_WithWhere_ReturnSetsofResult()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas
                    .ToList().Where(n => n.Id >= 1);
                foreach (Ninja ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }


                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void UpdateNinja()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas
                    .ToList().Where(n => n.Name == "Jorj")
                    .FirstOrDefault();
                if (ninjas != null)
                {
                    ninjas.Name = "Jordyn";
                    context.SaveChanges();
                }
                
                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void UpdateNinja_UsingState()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas
                    .ToList().Where(n => n.Name == "Jorj")
                    .FirstOrDefault();
                if (ninjas != null)
                {
                    ninjas.Name = "Jordyn";
                    context.Ninjas.Attach(ninjas);
                    context.Entry(ninjas).State = EntityState.Modified; //or added/deleted
                    context.SaveChanges();
                }

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void DeleteNinja()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas
                    .ToList().Where(n => n.Name == "Jordyn")
                    .FirstOrDefault();
                if (ninjas != null)
                {
                    ninjas.Name = "Jordyn";
                    context.Ninjas.Remove(ninjas);
                    context.SaveChanges();
                }

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void DeleteNinja_UsingState()
        {
            try
            {
                var context = new NinjaContext();
                var ninjas = context.Ninjas
                    .ToList().Where(n => n.Name == "Jordyn")
                    .FirstOrDefault();
                if (ninjas != null)
                {
                    ninjas.Name = "Jordyn";
                    context.Ninjas.Attach(ninjas);
                    context.Entry(ninjas).State = EntityState.Deleted; //or added/deleted
                    context.SaveChanges();
                }

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Assert.AreEqual(1, 0);
            }

        }

        [Test]
        public void InsertCompleteSetOfData()
        {
            var ninja = new Ninja()
            {
                Name = "Michael Felina",
                DateOfBirth = new DateTime(1970,10,22),
                ServeInOniwaban = true,
                ClanId = 1
            };

            var muscles = new NinjaEquipment()
            {
                Name = "Muscles",
                Type = EquipmentType.Tool,
            };
            var spunk = new NinjaEquipment()
            {
                Name = "Spunk",
                Type = EquipmentType.Weapon
            };

            context.Ninjas.Add(ninja);
            ninja.EquipmentOwned.Add(muscles);
            ninja.EquipmentOwned.Add(spunk);
            context.SaveChanges();
        }
    }
}
