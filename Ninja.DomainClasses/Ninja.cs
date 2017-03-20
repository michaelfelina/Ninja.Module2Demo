using System;
using System.Collections;
using System.Collections.Generic;

namespace Ninja.DomainClasses
{
    public class Ninja : IModificationHistory
    {
        public Ninja()
        {
            EquipmentOwned = new List<NinjaEquipment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServeInOniwaban { get; set; }
        public Clan Clan { get; set; }
        public int ClanId { get; set; }
        public List<NinjaEquipment> EquipmentOwned {get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDirty { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}