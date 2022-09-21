namespace Model
{
    public class Competition
    {

        public List<iParticipant> Participants { get; set; }

        public Queue<Track> Tracks;

        public Competition()
        {
            Tracks = new Queue<Track>();
            Participants = new List<iParticipant>();
        }

        public Track NextTrack()
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
