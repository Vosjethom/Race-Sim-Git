using Model;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Controller
{
    public class Race
    {
        public Race(Track baan, List<iParticipant> deelnemer)
        {
            Track = baan;
            Participants = deelnemer;
            StartGrid(baan, deelnemer);
            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {

        }

        private void Start()
        {
            _timer.Start();
        }

        public Track Track { get; set; }

        public List<iParticipant> Participants { get; set; }

        public DateTime StartTime { get; set; }

        private Random _random;

        private Dictionary<Section, SectionData> _positions;

        private Timer _timer;

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

        public void StartGrid(Track baan, List<iParticipant> deelnemers)
        {
            SectionData sector = GetSectionData();
            for (int i = 0; i < deelnemers.Count; i++)
            {
                if (i % 2 > 0)
                {
                    iParticipant participant = deelnemers[i];
                    sector.Left = participant;
                }
                else
                {
                    iParticipant participant = deelnemers[i];
                    sector.Right = participant;
                }
            }
        }
    }
}
