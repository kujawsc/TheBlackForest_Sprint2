using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    public class BlackForestTimeLocationObjects :  ForestObjects
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int BlackForestLocationId { get; set; }
        public bool IsDeadly { get; set; }
        public bool IsPoisonous { get; set; }
        public int HealthPoints { get; set; }
    }
}
