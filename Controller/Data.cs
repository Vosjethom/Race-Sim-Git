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
            if (_competition.NextTrack != null)
            {
                CurrentRace = new Race(_competition.NextTrack(), _competition.Participants);
            }
        }
    }
}
