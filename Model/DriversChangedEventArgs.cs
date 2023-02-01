namespace Model
{

    public class DriversChangedEventArgs : EventArgs
    {
        public Track _baan { get; set; }

        public DriversChangedEventArgs()
        {

        }
    }
}

