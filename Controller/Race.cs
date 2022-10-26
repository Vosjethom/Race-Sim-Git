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
            track = baan;
            Participants = deelnemers;
            _random = new Random();
            RandomizeEquipment();
            _positions = new Dictionary<Section, SectionData>();
            huidigeSection = track.Sections.First;
            StartGrid(baan, deelnemers);
            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Elapsed += OnTimedEvent;
            Start();
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs elapsedInterval)
        {
            DriversChangedEvent?.Invoke(_timer, elapsedInterval);
            BerekenAfstandSection();
        }

        private void Start()
        {
            _timer.Start();
        }

        public Track track { get; set; }
        public List<iParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random;
        private Dictionary<Section, SectionData> _positions { get; set; }
        private Timer _timer;

        private LinkedListNode<Section> huidigeSection;

        public SectionData GetSectionData(Section sector)
        {
            if (_positions.ContainsKey(sector))
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

        public void BerekenAfstandSection()
        {
            LinkedListNode<Section> currentLinkedListNode = track.Sections.Find(huidigeSection.Value);
            LinkedListNode<Section> nextLinkedListNode = currentLinkedListNode.Next;

            if (nextLinkedListNode == null)
            {
                nextLinkedListNode = track.Sections.First;
            }

            SectionData currentSectionData = GetSectionData(currentLinkedListNode.Value);
            SectionData nextSectionData = GetSectionData(nextLinkedListNode.Value);

            iParticipant deelnemerRechts = currentSectionData.Right;
            iParticipant deelnemerLinks = currentSectionData.Left;

            if (currentSectionData.Left != null)
            {
                currentSectionData.DistanceLeft += (deelnemerLinks.Performance * deelnemerLinks.Speed);
            }

            if (currentSectionData.Right != null)
            {
                currentSectionData.DistanceRight += (deelnemerRechts.Performance * deelnemerRechts.Speed);
            }

            if (currentSectionData.DistanceLeft >= 100)
            {
                if (nextSectionData.Left == null)
                {
                    _positions[nextLinkedListNode.Value].Left = _positions[currentLinkedListNode.Value].Left;
                    _positions[currentLinkedListNode.Value].Left = null;
                    nextSectionData.Left = deelnemerLinks;
                    //huidigeSection = nextLinkedListNode;
                    currentSectionData.DistanceLeft = 0;
                }
                else if (nextSectionData.Right == null)
                {
                    _positions[nextLinkedListNode.Value].Right = _positions[currentLinkedListNode.Value].Right;
                    _positions[currentLinkedListNode.Value].Right = null;
                    nextSectionData.Right = deelnemerLinks;
                    //huidigeSection = nextLinkedListNode;
                    currentSectionData.DistanceLeft = 0;
                } 
                else if (nextSectionData.Left != null && nextSectionData.Right != null)
                {
                    currentSectionData.DistanceLeft = 0;
                }
                huidigeSection = nextLinkedListNode;
            }

            if (currentSectionData.DistanceRight >= 100)
            {
                if (nextSectionData.Left == null)
                {
                    _positions[nextLinkedListNode.Value].Left = _positions[currentLinkedListNode.Value].Left;
                    _positions[currentLinkedListNode.Value].Left = null;
                    nextSectionData.Left = deelnemerRechts;
                    //huidigeSection = nextLinkedListNode;
                    currentSectionData.DistanceRight = 0;
                }
                else if (nextSectionData.Right == null)
                {
                    _positions[nextLinkedListNode.Value].Right = _positions[currentLinkedListNode.Value].Right;
                    _positions[currentLinkedListNode.Value].Right = null;
                    nextSectionData.Right = deelnemerRechts;
                    currentSectionData.DistanceRight = 0;
                }
                else if (nextSectionData.Left != null && nextSectionData.Right != null)
                {
                    currentSectionData.DistanceRight = 0;
                }
                huidigeSection = nextLinkedListNode;
            }
            //huidigeSection = nextLinkedListNode;
        }

        public void RandomizeEquipment()
        {
            for (int i = 0; i < Participants.Count; i++)
            {
                iEquipment equipment = Participants[i].Equipment;
                equipment.Quality = _random.Next(3, 180);
                equipment.Performance = _random.Next(5,8);
                equipment.Speed = _random.Next(3,5);
            }
        }

        public void StartGrid(Track baan, List<iParticipant> deelnemers)
        {
            Section section = baan.Sections.First.Value;
            SectionData sector = new SectionData();

            for (int i = 0; i < deelnemers.Count; i++)
            {
                if (i % 2 > 0)
                {
                    iParticipant participant = deelnemers[i];
                    sector.Right = participant;
                }
                else
                {
                    iParticipant participant = deelnemers[i];
                    sector.Left = participant;
                }
            }
            _positions.Add(section, sector);
        }
        public event TimedEvent DriversChangedEvent;
    }
}