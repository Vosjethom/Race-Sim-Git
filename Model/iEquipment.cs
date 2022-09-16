namespace Model
{
    public interface iEquipment
    {
        public int Quality { get; set; }

        public int Performance { get; set; }

        public int Speed { get; set; }

        public bool IsBroken { get; set; }
    }
}
