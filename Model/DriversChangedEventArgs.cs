namespace Model
{

    public class DriversChangedEventArgs : EventArgs
    {
        private Track _baan;

        public Track Baan { get; set; }
    }
}

