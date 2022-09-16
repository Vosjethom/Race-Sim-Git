namespace Model
{
    public interface iParticipant : iEquipment
    {
        public string Name { get; set; }

        public int Points { get; set; }

        public iEquipment Equipment { get; set; }

        public TeamColors TeamColor { get; set; }
    }

    public enum TeamColors
    {
        Red,
        Green,
        Yellow,
        Grey,
        Blue,

    }
}
