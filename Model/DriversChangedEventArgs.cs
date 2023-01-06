namespace Model
{

    public class DriversChangedEventArgs : EventArgs
    {
        public Track _baan { get; set; }

        public DriversChangedEventArgs(Track baan)
        {
           _baan = baan;
        }
    }
}

