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
        }

        public static void AddTracks()
        {
            Track baan = new Track("Zandvoort", new[] { SectionTypes._finishHorizontaal, SectionTypes._straigthHorizontaal,                        //2
                SectionTypes._turnUpDownLinks, SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownLinks, SectionTypes._turnDownUpRechts,                    //6
                SectionTypes._straigthHorizontaal, SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownLinks,                //10
                SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownLinks, SectionTypes._turnDownUpRechts, SectionTypes._straigthHorizontaal,                //14
                SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpRechts, SectionTypes._straigthHorizontaal, SectionTypes._straigthHorizontaal,           //18
                SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownRechts, SectionTypes._straigthHorizontaal, SectionTypes._turnDownUpRechts,               //22
                SectionTypes._straigthVerticaal, SectionTypes._turnUpDownLinks, SectionTypes._straigthHorizontaal, SectionTypes._turnUpDownRechts,              //26
                SectionTypes._turnDownUpRechts, SectionTypes._turnDownUpLinks, SectionTypes._straigthVerticaal, SectionTypes._straigthVerticaal,                //30
                SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownRechts, SectionTypes._straigthHorizontaal               //34
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
                Console.Clear();
            }
        }
    }
}
