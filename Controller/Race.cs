﻿using Model;

namespace Controller
{
    public class Race
    {

        public Race(Track baan, List<iParticipant> deelnemer)
        {
            Track = baan;
            Participants = deelnemer;
        }

        public Track Track { get; set; }

        public List<iParticipant> Participants { get; set; }

        public DateTime StartTime { get; set; }

        private Random _random;

        private Dictionary<Section, SectionData> _positions;

        public SectionData GetSectionData(Section sector)
        {
            if (_positions.TryGetValue(sector, out var sectionData))
            {
                return sectionData;
            }
            else
            {
                SectionData _sectionData = new SectionData();
                return _sectionData;
            }
        }

        public SectionData GetSectionData()
        {
            SectionData _sectionData = new SectionData();
            return _sectionData;
        }

        public void RandomizeEquipment()
        {
            for (int i = 0; i < Participants.Count; i++)
            {
                iEquipment equipment = Participants[i];
                equipment.Quality = _random.Next(101);
                equipment.Performance = _random.Next(101);

            }
        }
    }
}
