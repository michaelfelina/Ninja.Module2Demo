namespace Ninja.DataModel{
    using System.Data.Entity;
    using DomainClasses;

    public class NinjaContext : DbContext
    {
        public NinjaContext() :base("Ninja")
        {
            
        }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipments { get; set; }
    }
}
