namespace Model
{
    public class Driver : iParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public iEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }
        public int Quality { get; set; }
        public int Performance { get; set; }
        public int Speed { get; set; }
        public bool IsBroken { get; set; }
        public int LapCount { get; set; }
        public bool Finished { get; set; }
    }
}
