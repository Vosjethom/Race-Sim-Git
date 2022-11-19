using Model;
using System.Timers;
using Timer = System.Timers.Timer;
namespace Controller
{
    public class Race
    {
        public event TimedEvent DriversChangedEvent;

        public delegate void TimedEvent(object? sender, ElapsedEventArgs e);

        public Track track { get; set; }
        public List<iParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random;
        private Dictionary<Section, SectionData> _positions { get; set; }
        private Timer _timer;
        public LinkedListNode<Section> huidigeSection;

        public Race(Track baan, List<iParticipant> deelnemers)
        {
            track = baan;
            Participants = deelnemers;
            _random = new Random();
            RandomizeEquipment();
            _positions = new Dictionary<Section, SectionData>();
            StartGrid(baan, deelnemers);
            huidigeSection = track.Sections.First;
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
            LinkedListNode<Section> currentLinkedListNode = huidigeSection;
            LinkedListNode<Section> nextLinkedListNode = currentLinkedListNode.Next;

            if (GetSectionData(currentLinkedListNode.Value) == null)
            {
                huidigeSection = nextLinkedListNode;
                BerekenAfstandSection();
            }

            if (nextLinkedListNode == null)
            {
                nextLinkedListNode = track.Sections.First;
            }

            SectionData currentSectionData = GetSectionData(currentLinkedListNode.Value);
            SectionData nextSectionData = GetSectionData(nextLinkedListNode.Value);

            foreach (Section section in track.Sections)
            {
                if (GetSectionData(section) == null)
                {
                    currentLinkedListNode = track.Sections.Find(section);
                }
            }

            iParticipant deelnemerRechts = currentSectionData.Right;
            iParticipant deelnemerLinks = currentSectionData.Left;

            if (deelnemerLinks == null && deelnemerRechts == null)
            {
                huidigeSection = currentLinkedListNode.Next;
                BerekenAfstandSection();
            }

            if (deelnemerLinks != null)
            {
                currentSectionData.DistanceLeft += (deelnemerLinks.Performance * deelnemerLinks.Speed);
            }

            if (deelnemerRechts != null)
            {
                currentSectionData.DistanceRight += (deelnemerRechts.Performance * deelnemerRechts.Speed);
            }

            if (currentSectionData.DistanceLeft >= 100)
            {
                if (nextSectionData.Left == null)
                {
                    _positions[nextLinkedListNode.Value].Left = deelnemerLinks;
                    _positions[currentLinkedListNode.Value].Left = null;

                    nextSectionData.DistanceLeft = 0;
                    currentSectionData.DistanceLeft = 0;
                }
                else if (nextSectionData.Right == null)
                {
                    _positions[nextLinkedListNode.Value].Right = deelnemerLinks;
                    _positions[currentLinkedListNode.Value].Left = null;

                    nextSectionData.DistanceRight = 0;
                    currentSectionData.DistanceLeft = 0;
                }
                else if (nextSectionData.Left != null && nextSectionData.Right != null)
                {
                    currentSectionData.DistanceLeft = 0;
                }
            }

            if (currentSectionData.DistanceRight >= 100)
            {
                if (nextSectionData.Left == null)
                {
                    _positions[nextLinkedListNode.Value].Left = deelnemerRechts;
                    _positions[currentLinkedListNode.Value].Right = null;

                    nextSectionData.DistanceLeft = 0;
                    currentSectionData.DistanceRight = 0;
                }
                else if (nextSectionData.Right == null)
                {
                    _positions[nextLinkedListNode.Value].Right = deelnemerRechts;
                    _positions[currentLinkedListNode.Value].Right = null;

                    nextSectionData.DistanceRight = 0;
                    currentSectionData.DistanceRight = 0;
                }
                else if (nextSectionData.Left != null && nextSectionData.Right != null)
                {
                    currentSectionData.DistanceRight = 0;
                }
            }
        }

        public void RandomizeEquipment()
        {
            foreach (iParticipant deelnemer in Participants)
            {
                deelnemer.Quality = _random.Next(1, 100);
                deelnemer.Performance = _random.Next(5, 10);
                deelnemer.Speed = _random.Next(5, 10);
            }
        }

        public void StartGrid(Track baan, List<iParticipant> deelnemers)
        {
            SectionTypes startGridHorizontal = SectionTypes._startGridHorizontaal;
            SectionTypes startGridVertical = SectionTypes._startGridVerticaal;

            foreach (Section section1 in baan.Sections)
            {
                if (section1.SectionType.Equals(startGridVertical))
                {
                    SectionData sector = new SectionData();
                    for (int i = deelnemers.Count; i > 0; i--)
                    {
                        if (i % 2 == 0)
                        {
                            iParticipant participant = deelnemers[0];
                            if (sector.Right == null)
                            {
                                sector.Right = participant;
                                deelnemers.Remove(participant);
                            }
                        }
                        else
                        {
                            iParticipant participant = deelnemers[0];
                            if (sector.Left == null)
                            {
                                sector.Left = participant;
                                deelnemers.Remove(participant);
                            }

                        }
                    }
                    _positions.Add(section1, sector);
                }

                if (section1.SectionType.Equals(startGridHorizontal))
                {
                    SectionData sector = new SectionData();
                    for (int i = deelnemers.Count; i > 0; i--)
                    {
                        if (i % 2 == 0)
                        {
                            iParticipant participant = deelnemers[i - 1];
                            if (sector.Right == null)
                            {
                                sector.Right = participant;
                                deelnemers.Remove(participant);
                            }
                        }
                        else
                        {
                            iParticipant participant = deelnemers[i - 1];
                            if (sector.Left == null)
                            {
                                sector.Left = participant;
                                deelnemers.Remove(participant);
                            }
                        }
                    }
                    _positions.Add(section1, sector);
                }
            }
        }
    }
}