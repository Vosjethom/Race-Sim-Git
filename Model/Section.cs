namespace Model
{
    public class Section
    {

        public Section(SectionTypes sectionType)
        {
            SectionType = sectionType;
        }

        public SectionTypes SectionType { get; set; }
    }

    public enum SectionTypes
    {

        _finishHorizontaal,
        _finishVerticaal,
        _straigthHorizontaal,
        _straigthVerticaal,
        _turnDownUpLinks,
        _turnUpDownLinks,
        _turnDownUpRechts,
        _turnUpDownRechts

    }
}