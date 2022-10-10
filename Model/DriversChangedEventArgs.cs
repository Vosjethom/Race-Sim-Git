using System.Dynamic;

namespace Model
{
    public delegate void DriversChanged(Track baanTrack);

    public class DriversChangedEventArgs : EventArgs
    {
        private Track _baan;

        public Track Baan
        {
            get { return _baan; }
            set
            {
                if (!(Baan.Equals(_baan)))
                {
                    DriversChangedEvent?.Invoke(Baan);
                }
            }
        }

        

        public event DriversChanged DriversChangedEvent;
    }
}
