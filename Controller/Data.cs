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

            iParticipant deelnemer2 = new Driver();
            deelnemer2.Name = "Lewis Hamilton";
            _competition.Participants.Add(deelnemer2);

            iParticipant deelnemer3 = new Driver();
            deelnemer3.Name = "Charles Leclerc";
            _competition.Participants.Add(deelnemer3);

            iParticipant deelnemer4 = new Driver();
            deelnemer4.Name = "Sergio Perez";
            _competition.Participants.Add(deelnemer4);
        }

        public static void AddTracks()
        {
            Track baan = new Track("Zandvoort", new[] {  SectionTypes._startGridHorizontaal, SectionTypes._startGridHorizontaal, SectionTypes._finishHorizontaal,
                SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownLinks, SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownRechts,
                SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownLinks, SectionTypes._straigthHorizontaal, SectionTypes._straigthHorizontaal,
                SectionTypes._straigthHorizontaal, SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownLinks,
                SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpLinks
                });
            _competition.Tracks.Enqueue(baan);

            Track baan2 = new Track("Silverstone", new SectionTypes[6]);
            _competition.Tracks.Enqueue(baan2);

            Track baan3 = new Track("Monaco", new SectionTypes[4]);
            _competition.Tracks.Enqueue(baan3);
        }

        public static void NextRace()
        {
            if (_competition.NextTrack != null)
            {
                CurrentRace = new Race(_competition.NextTrack(), _competition.Participants);
                //Console.Clear();
            }
        }
    }
}
