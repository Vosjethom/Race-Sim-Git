using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface iParticipant : iEquipment
    {
        public string Name { get; set; }

        public int Points { get; set; } 

        public iEquipment Equipment { get; set; }

        public TeamColors TeamColor { get; set; }
    }

    public enum TeamColors
    {
            Red = 0,
            Green = 1, 
            Yellow = 2,
            Grey = 3,
            Blue = 4,
        
    }
}
