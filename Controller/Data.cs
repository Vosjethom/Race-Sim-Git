using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition _competition { get; set; }
        public static Race CurrentRace { get; set; }
        public static List<iParticipant> Participants = new List<iParticipant>();

        public static void Initialize()
        {
            _competition = new Competition();

            AddParticipant();

            _competition.Participants = Participants;

            AddTracks();
            NextRace();
        }

        public static void AddParticipant()
        {
            iParticipant deelnemer = new Driver();
            deelnemer.Name = "Max Verstappen";
            Participants.Add(deelnemer);

            iParticipant deelnemer2 = new Driver();
            deelnemer2.Name = "Lewis Hamilton";
            Participants.Add(deelnemer2);

            iParticipant deelnemer3 = new Driver();
            deelnemer3.Name = "Charles Leclerc";
            Participants.Add(deelnemer3);

            iParticipant deelnemer4 = new Driver();
            deelnemer4.Name = "Sergio Perez";
            Participants.Add(deelnemer4);
        }

        public static void AddTracks()
        {
            Track baan = new Track("Zandvoort", new[] {  SectionTypes._finishHorizontaal, SectionTypes._startGridHorizontaal, SectionTypes._startGridHorizontaal,
                SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownLinks, SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownRechts,
                SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownLinks, SectionTypes._straigthHorizontaal, SectionTypes._straigthHorizontaal,
                SectionTypes._straigthHorizontaal, SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpLinks, SectionTypes._turnUpDownLinks,
                SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpLinks
                });
            _competition.Tracks.Enqueue(baan);

            Track baan2 = new Track("Silverstone", new[] { SectionTypes._finishHorizontaal, SectionTypes._startGridHorizontaal, SectionTypes._startGridHorizontaal,
            SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownLinks, SectionTypes._straigthHorizontaal, SectionTypes._straigthHorizontaal, 
            SectionTypes._straigthHorizontaal, SectionTypes._turnDownUpRechts, SectionTypes._turnUpDownRechts, SectionTypes._turnDownUpLinks});
            _competition.Tracks.Enqueue(baan2);

            Track baan3 = new Track("Monaco", new SectionTypes[4]);
            _competition.Tracks.Enqueue(baan3);
        }

        public static void NextRace()
        {
            //if (_competition.NextTrack != null)
            //{
            //    //AddParticipant();
            //    CurrentRace = new Race(_competition.NextTrack(), _competition.Participants);
            //    //CurrentRace.StartGrid(CurrentRace.track, CurrentRace.Participants);
            //    Console.Clear();
            //}

            Track track = _competition.NextTrack();
            if (track != null)
            {
                //Graphics.Visualise(5, 5, track);
                //CurrentRace.Track = track;
                //CurrentRace.Participants= Participants;
                CurrentRace = new Race(track, Participants);
                //foreach (IParticipant part in Participants) { 

                //    CurrentRace.FinishedPlayer(part);
                //}
            }
            //return track;
        }
    }
}
