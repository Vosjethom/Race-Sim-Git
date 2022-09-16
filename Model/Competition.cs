using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Competition
    {

        public List<iParticipant> Participants { get; set; }

        public Queue<Track> Tracks;

        public Track? NextTrack()
        {
            if (Tracks.Count > 0)
            {
                return Tracks.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}
