using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    public abstract class Npc : Trainee
    {
        public abstract int Id { get; set; }
        public abstract string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
