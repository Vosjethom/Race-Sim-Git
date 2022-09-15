using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition _competition { get; set; }

        public static Race CurrentRace { get; set; }

        public static void Initialize()
        {
            _competition = new Competition();
            AddParticipant();
            AddTracks();
        }

        public static void AddParticipant()
        {
            iParticipant deelnemer = new Driver();
            deelnemer.Name = "Max Verstappen";
            _competition.Participants.Add(deelnemer);
        }
        
        public static void AddTracks()
        {
            Track baan = new Track();
            baan.Name = "Zandvoort";
            _competition.Tracks.Enqueue(baan);
        }

        public static void NextRace()
        {
            
        }
    }
}
