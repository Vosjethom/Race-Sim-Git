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
            _competition.Participants = new List<iParticipant>();
            _competition.Tracks = new Queue<Track>();

            AddParticipant();
            AddTracks();

            CurrentRace = new Race(_competition.Tracks.First(), _competition.Participants);
        }

        public static void AddParticipant()
        {
            iParticipant deelnemer = new Driver();
            deelnemer.Name = "Max Verstappen";
            _competition.Participants.Add(deelnemer);

            iParticipant deelnemer2 = new Driver();
            deelnemer.Name = "Lewis Hamilton";
            _competition.Participants.Add(deelnemer2);

            iParticipant deelnemer3 = new Driver();
            deelnemer.Name = "Charles Leclerc";
            _competition.Participants.Add(deelnemer3);
        }
        
        public static void AddTracks()
        {
            Track baan = new Track();
            baan.Name = "Zandvoort";
            _competition.Tracks.Enqueue(baan);

            Track baan2 = new Track();
            baan.Name = "Silverstone";
            _competition.Tracks.Enqueue(baan2);

            Track baan3 = new Track();
            baan.Name = "Monaco";
            _competition.Tracks.Enqueue(baan3);
        }

        public static void NextRace()
        {
            if (_competition.Tracks.Count > 0)
            {
                CurrentRace = new Race(_competition.NextTrack(), _competition.Participants);
            }
        }
    }
}
