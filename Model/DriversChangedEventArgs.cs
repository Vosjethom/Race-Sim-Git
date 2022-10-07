namespace Model
{
    public class DriversChangedEventArgs : EventArgs
    {
        private Track baan;

        public delegate void DriversChanged(object sender, DriversChangedEventArgs e);
    }
}
