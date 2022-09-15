namespace Model
{
    public class Section
    {
        public SectionTypes SectionType { get; set; }
    }

    public enum SectionTypes
    {
            Straight = 0,
            LeftCorner = 1,
            RightCorner = 2,
            StartGrid = 3,
            Finish = 4
    }
}