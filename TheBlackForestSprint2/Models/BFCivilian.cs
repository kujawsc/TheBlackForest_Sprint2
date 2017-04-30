using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    public class BFCivilian : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public List<string> Messages { get; set; }

        /// <summary>
        /// Generate a message or use default
        /// </summary>
        /// <returns>Message text</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return $"My name is {base.FirstName} and I am a {base.Race}";
            }
        }

        ///<summary>
        /// Randomply seect a message from the list of messages
        /// </summary>
        /// <return>Message text</return>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
