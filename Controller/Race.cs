using Model;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Controller
{
    public delegate void TimedEvent(object? sender, ElapsedEventArgs e);
    public class Race
    {
        public Race(Track baan, List<iParticipant> deelnemers)
        {
            Track = baan;
            Participants = deelnemers;
            StartGrid(baan, deelnemers);
            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Elapsed += OnTimedEvent;
            Start();
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs elapsedInterval)
        {
            DriversChangedEvent?.Invoke(_timer, elapsedInterval);
        }

        private void Start()
        {
            _timer.Start();
        }

        public Track Track { get; set; }

        public List<iParticipant> Participants { get; set; }

        public DateTime StartTime { get; set; }

        private Random _random;

        private Dictionary<Section, SectionData> _positions { get; set; }

        private Timer _timer;

        public SectionData GetSectionData(Section sector)
        {
            if (_positions.ContainsValue(_positions[sector]))
            {
                return _positions[sector];
            }
            else
            {
                SectionData _sectionData = new SectionData();
                _positions.Add(sector, _sectionData);
                return _sectionData;
            }
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
            SectionData sector = new SectionData();
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
        public event TimedEvent DriversChangedEvent;
    }
}
