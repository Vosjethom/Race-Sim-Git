using Model;
using System.Diagnostics;
using System.Reflection;
using System.Timers;
using Timer = System.Timers.Timer;
namespace Controller
{
    public class Race
    {
        public event EventHandler<DriversChangedEventArgs> DriversChanged;

        public delegate void TimedEvent(object? sender, ElapsedEventArgs e);

        public Track track { get; set; }
        public List<iParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random { get; set; }
        public Dictionary<Section, SectionData> _positions { get; set; }
        private Timer _timer { get; set; }
        public LinkedListNode<Section> huidigeSection { get; set; }
        public SectionData currentSectionData { get; set; }
        public SectionData nextSectionData { get; set; }
        private int _index { get; set; }
        private int RaceLength { get; set; } = 1;

        public Race(Track baan, List<iParticipant> deelnemers)
        {
            track = baan;
            Participants = deelnemers;
            _random = new Random();
            RandomizeEquipment();
            _positions = new Dictionary<Section, SectionData>();
            StartGrid(baan, deelnemers);
            _index = track.Sections.Count;

            foreach (Section section in track.Sections)
            {
                GetSectionData(section);
            }

            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Elapsed += OnTimedEvent;
            Start();
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs elapsedInterval)
        {
            BerekenAfstandSection();
            DriversChanged?.Invoke(sender, new DriversChangedEventArgs(track));

            _index = track.Sections.Count;
        }

        private void Start()
        {
            _timer.Start();

            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //DriversChanged?.Invoke(this, new DriversChangedEventArgs(track));
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //DriversChanged?.Invoke(this, new DriversChangedEventArgs(track));
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //DriversChanged?.Invoke(this, new DriversChangedEventArgs(track));
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //DriversChanged?.Invoke(this, new DriversChangedEventArgs(track));
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //DriversChanged?.Invoke(this, new DriversChangedEventArgs(track));
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //BerekenAfstandSection();
            //DriversChanged?.Invoke(this, new DriversChangedEventArgs(track));

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

        public void SetSectionData(Section currentSection, Section nextSection, iParticipant deelnemerLinks, iParticipant deelnemerRechts)
        {
            if (_positions.ContainsKey(currentSection))
            {
                SectionData currentSectionData = _positions[currentSection];
                SectionData nextSectionData = _positions[nextSection];
                _positions.Remove(currentSection);
                _positions.Remove(nextSection);

                if (currentSectionData.DistanceLeft > 100)
                {
                    if (nextSectionData.Left == null && nextSectionData.Right != null)
                    {
                        nextSectionData.Left = deelnemerLinks;
                        nextSectionData.DistanceLeft = 0;
                    }
                    else if (nextSectionData.Left != null && nextSectionData.Right == null)
                    {
                        nextSectionData.Right = deelnemerLinks;
                        nextSectionData.DistanceRight = 0;
                    }
                    else if (nextSectionData.Left == null && nextSectionData.Right == null)
                    {
                        nextSectionData.Left = deelnemerLinks;
                        nextSectionData.DistanceLeft = 0;
                    }

                    if (currentSection == track.Sections.First() && deelnemerLinks.LapCount == RaceLength)
                    {
                        deelnemerLinks.Finished = true;
                        currentSectionData.Left = null;

                        if (nextSectionData.Left == deelnemerLinks)
                        {
                            nextSectionData.Left = null;
                        }
                        else if (nextSectionData.Right == deelnemerLinks)
                        {
                            nextSectionData.Right = null;
                        }
                    }

                    if (currentSection == track.Sections.ElementAt(0) && nextSection == track.Sections.ElementAt(1))
                    {
                        deelnemerLinks.LapCount++;
                    }

                    currentSectionData.Left = null;
                    currentSectionData.DistanceLeft = 0;
                    _positions.Add(currentSection, currentSectionData);
                    _positions.Add(nextSection, nextSectionData);
                }

                if (currentSectionData.DistanceRight > 100)
                {
                    if (nextSectionData.Left == null && nextSectionData.Right != null)
                    {
                        nextSectionData.Left = deelnemerRechts;
                        nextSectionData.DistanceLeft = 0;
                    }
                    else if (nextSectionData.Left != null && nextSectionData.Right == null)
                    {
                        nextSectionData.Right = deelnemerRechts;
                        nextSectionData.DistanceRight = 0;
                    }
                    else if (nextSectionData.Left == null && nextSectionData.Right == null)
                    {
                        nextSectionData.Left = deelnemerRechts;
                        nextSectionData.DistanceLeft = 0;
                    }
                    
                    if (currentSection == track.Sections.First() && deelnemerRechts.LapCount == RaceLength)
                    {
                        deelnemerRechts.Finished = true;
                        currentSectionData.Right = null;

                        if (nextSectionData.Left == deelnemerLinks)
                        {
                            nextSectionData.Left = null;
                        }
                        else if (nextSectionData.Right == deelnemerLinks)
                        {
                            nextSectionData.Right = null;
                        }
                    }

                    if (currentSection == track.Sections.ElementAt(0) && nextSection == track.Sections.ElementAt(1))
                    {
                        deelnemerRechts.LapCount++;
                    }
                    
                    currentSectionData.Right = null;
                    currentSectionData.DistanceRight = 0;
                    _positions.Add(currentSection, currentSectionData);
                    _positions.Add(nextSection, nextSectionData);
                }
            }
        }

        public void BerekenAfstandSection()
        {
            for (int i = _index - 1; i >= 0; i--)
            {
                Section currentSection;
                Section nextSection;

                if (i == track.Sections.Count - 1)
                {
                    currentSection = track.Sections.Last.Value;
                    nextSection = track.Sections.First.Value;
                    currentSectionData = GetSectionData(currentSection);
                    nextSectionData = GetSectionData(nextSection);
                }
                else
                {
                    currentSection = track.Sections.ElementAt(i);
                    nextSection = track.Sections.ElementAt(i + 1);
                    currentSectionData = GetSectionData(currentSection);
                    nextSectionData = GetSectionData(nextSection);
                }

                iParticipant deelnemerRechts = currentSectionData.Right;
                iParticipant deelnemerLinks = currentSectionData.Left;

                if (deelnemerLinks != null && deelnemerRechts == null)
                {
                    currentSectionData.DistanceLeft += (deelnemerLinks.Performance * deelnemerLinks.Speed);
                }

                if (deelnemerLinks == null && deelnemerRechts != null)
                {
                    currentSectionData.DistanceRight += (deelnemerRechts.Performance * deelnemerRechts.Speed);
                }

                if (deelnemerLinks != null && deelnemerRechts != null)
                {
                    currentSectionData.DistanceLeft += (deelnemerLinks.Performance * deelnemerLinks.Speed);
                    currentSectionData.DistanceRight += (deelnemerRechts.Performance * deelnemerRechts.Speed);
                }

                if (currentSectionData.DistanceLeft >= 100 || currentSectionData.DistanceRight >= 100)
                {
                    SetSectionData(currentSection, nextSection, deelnemerLinks, deelnemerRechts);
                }
            }
        }

        public void RandomizeEquipment()
        {
            foreach (iParticipant deelnemer in Participants)
            {
                deelnemer.Quality = _random.Next(1, 100);
                deelnemer.Performance = _random.Next(2, 12);
                deelnemer.Speed = _random.Next(3, 8);
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