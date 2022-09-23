namespace Model
{
    public class Track
    {

        public Track(string name, SectionTypes[] sections)
        {
            Name = name;
            Sections = ArrayToLinkedList(sections);
        }

        public string Name { get; set; }

        public LinkedList<Section> Sections { get; set; }

        public LinkedList<Section> ArrayToLinkedList(SectionTypes[] sectionTypes)
        {
            LinkedList<Section> _sections = new LinkedList<Section>();

            foreach (SectionTypes sectionType in sectionTypes)
            {
                Section sector = new Section(sectionType);
                _sections.AddLast(sector);
            }
            return _sections;
        }
    }
}
