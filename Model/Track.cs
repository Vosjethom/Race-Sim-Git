using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Track
    {

        public Track(/*string name, SectionTypes[] sections*/)
        {
            //Name = name;
            //Sections = sections;
            
        }

        public string Name { get; set; }

        public LinkedList<Section> Sections { get; set; }

    }
}
