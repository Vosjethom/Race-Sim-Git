using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition _competition { get; set; }

        public static Race CurrentRace { get; set; }

        public static void Initialize(Competition competition)
        {
            _competition = competition;
        }

        public static void iParticipant()
        {
            iParticipant deelnemer = new Driver();
            _competition.Participants.Add(deelnemer);
        }

        public static void Track()
        {
            Track baan = new Track();
            _competition.Tracks.Enqueue(baan);
        }

        public static void NextRace()
        {
            _competition.NextTrack();
        }
    }
}
