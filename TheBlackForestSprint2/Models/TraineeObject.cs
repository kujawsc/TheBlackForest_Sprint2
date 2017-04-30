using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    public class TraineeObject :  ForestObjects
    { 
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int BlackForestLocationId { get; set; }
        public TraineeObjectType Type { get; set; }
        public int ExperiencePoints { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsPoisonous { get; set; }
        public bool IsVisible { get; set; }
        public int HealthPoints { get; set; }
        public int Value { get; set; }

    }
}
