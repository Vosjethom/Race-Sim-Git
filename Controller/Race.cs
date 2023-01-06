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
        private int indexTimer { get; set; }
        private int linksCheck { get; set; }
        private int rechtsCheck { get; set; }
        public SectionData currentSectionData { get; set; }
        public SectionData nextSectionData { get; set; }
        private int _index { get; set; }

        public Race(Track baan, List<iParticipant> deelnemers)
        {
            track = baan;
            Participants = deelnemers;
            _random = new Random();
            RandomizeEquipment();
            _positions = new Dictionary<Section, SectionData>();
            StartGrid(baan, deelnemers);
            huidigeSection = track.Sections.Last;
            _index = track.Sections.Count;

            //currentSectionData = GetSectionData(track.Sections.Last.Value);

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

            indexTimer++;
            Debug.WriteLine($"timerCount = '{indexTimer}'");
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

        public void SetSectionData(Section sector, iParticipant participant)
        {
            //Section volgendeSection;

            //if (_index + 1 == track.Sections.Count)
            //{
            //    volgendeSection = track.Sections.ElementAt(0);
            //}
            //else
            //{
            //    volgendeSection = track.Sections.ElementAt(_index - 1);
            //}

            //SectionData volgendeSectionData = GetSectionData(volgendeSection);


            if (_positions.ContainsKey(sector))
            {
                SectionData sectionData = _positions[sector];
                _positions.Remove(sector);

                if (sectionData.Left == null && sectionData.Right != null)
                {
                    sectionData.Left = participant;
                    sectionData.DistanceLeft = 0;
                    _positions.Add(sector, sectionData);
                }

                if (sectionData.Left != null && sectionData.Right == null)
                {
                    sectionData.Right = participant;
                    sectionData.DistanceRight = 0;
                    _positions.Add(sector, sectionData);
                }

                if (sectionData.Left == null && sectionData.Right == null)
                {
                    sectionData.Left = participant;
                    sectionData.DistanceLeft = 0;
                    _positions.Add(sector, sectionData);
                }
            }
        }

        public void BerekenAfstandSection()
        {
            LinkedListNode<Section> previousLinkedListNode = huidigeSection.Previous;
            LinkedListNode<Section> currentLinkedListNode = huidigeSection;
            LinkedListNode<Section> nextLinkedListNode = huidigeSection.Next;

            //if (GetSectionData(currentLinkedListNode.Value) == null)
            //{
            //    huidigeSection = nextLinkedListNode;
            //    BerekenAfstandSection();
            //    Debug.WriteLine("section is null");
            //}

            //if (nextLinkedListNode == null)
            //{
            //    nextLinkedListNode = track.Sections.First;
            //}

            //if (previousLinkedListNode == null)
            //{
            //    previousLinkedListNode = track.Sections.Last;
            //}

            //SectionData currentSectionData = GetSectionData(currentLinkedListNode.Value);
            //SectionData previousSectionData = GetSectionData(previousLinkedListNode.Value);
            //SectionData nextSectionData = GetSectionData(nextLinkedListNode.Value);

            for (int i = _index - 1; i >= 0; i--)
            {
                //previousSectionData = GetSectionData(track.Sections.ElementAt(i - 1));
                currentSectionData = GetSectionData(track.Sections.ElementAt(i));

                if (i + 1 == track.Sections.Count)
                {
                    nextSectionData = GetSectionData(track.Sections.ElementAt(0));
                }
                else
                {
                    nextSectionData = GetSectionData(track.Sections.ElementAt(i + 1));
                }

                iParticipant deelnemerRechts = currentSectionData.Right;
                iParticipant deelnemerLinks = currentSectionData.Left;


                if (deelnemerLinks != null && deelnemerRechts == null)
                {
                    currentSectionData.DistanceLeft += (deelnemerLinks.Performance * deelnemerLinks.Speed);

                    Debug.WriteLine("==========");

                    Debug.Write(currentSectionData.Left.Name + "\t");
                    Debug.Write(currentSectionData.DistanceLeft + "\n");


                    Debug.WriteLine("==========");
                }

                if (deelnemerLinks == null && deelnemerRechts != null)
                {
                    currentSectionData.DistanceRight += (deelnemerRechts.Performance * deelnemerRechts.Speed);

                    Debug.WriteLine("==========");

                    Debug.Write(currentSectionData.Right.Name + "\t");
                    Debug.Write(currentSectionData.DistanceRight + "\n");


                    Debug.WriteLine("==========");
                }

                if (deelnemerLinks != null && deelnemerRechts != null)
                {
                    currentSectionData.DistanceLeft += (deelnemerLinks.Performance * deelnemerLinks.Speed);

                    Debug.WriteLine("==========");

                    Debug.Write(currentSectionData.Left.Name + "\t");
                    Debug.Write(currentSectionData.DistanceLeft + "\n");

                    currentSectionData.DistanceRight += (deelnemerRechts.Performance * deelnemerRechts.Speed);

                    Debug.Write(currentSectionData.Right.Name + "\t");
                    Debug.Write(currentSectionData.DistanceRight + "\n");


                    Debug.WriteLine("==========");
                }

                //=============================== met sectionData

                if (currentSectionData.DistanceLeft >= 100)
                {
                    if (nextSectionData.Left == null)
                    {

                        SetSectionData(currentLinkedListNode.Value, deelnemerLinks);

                        nextSectionData.Left = deelnemerLinks;
                        currentSectionData.Left = null;

                        ///Debug.WriteLine($"nextSection {deelnemerLinks.Name} links {track.Sections.ElementAt(i + 1).SectionType}");

                        //_positions[currentLinkedListNode.Value].DistanceLeft = 0;

                        //currentSectionData.Left = null;

                        //nextSectionData.DistanceLeft = 0;
                        //currentSectionData.DistanceLeft = 0;
                    }
                    else if (nextSectionData.Right == null)
                    {

                        SetSectionData(currentLinkedListNode.Value, deelnemerLinks);

                        nextSectionData.Right = deelnemerLinks;
                        currentSectionData.Left = null;

                        ///Debug.WriteLine($"nextSection {deelnemerLinks.Name} rechts {track.Sections.ElementAt(i + 1).SectionType}");

                        //_positions[currentLinkedListNode.Value].DistanceLeft = 0;

                        //currentSectionData.Left = null;

                        //nextSectionData.DistanceRight = 0;
                        //currentSectionData.DistanceLeft = 0;
                    }
                    else if (nextSectionData.Left != null && nextSectionData.Right != null)
                    {
                        //_positions[currentLinkedListNode.Value].DistanceLeft = 0;
                        currentSectionData.DistanceLeft = 0;

                        //SetSectionData(currentLinkedListNode.Value, deelnemerLinks);

                        ///Debug.WriteLine("nextSection is vol");
                    }
                    //Debug.WriteLine($"{currentSectionData.Left} linksNextSection");
                }

                if (currentSectionData.DistanceRight >= 100)
                {
                    if (nextSectionData.Left == null)
                    {

                        SetSectionData(currentLinkedListNode.Value, deelnemerRechts);

                        nextSectionData.Left = deelnemerRechts;
                        currentSectionData.Right = null;

                        ///Debug.WriteLine($"nextSection {deelnemerRechts.Name} links {track.Sections.ElementAt(i + 1).SectionType}");

                        //_positions[currentLinkedListNode.Value].DistanceRight = 0;

                        //currentSectionData.Right = null;

                        //nextSectionData.DistanceLeft = 0;
                        //currentSectionData.DistanceRight = 0;
                    }
                    else if (nextSectionData.Right == null)
                    {

                        SetSectionData(currentLinkedListNode.Value, deelnemerRechts);

                        nextSectionData.Right = deelnemerRechts;
                        currentSectionData.Right = null;

                        ///Debug.WriteLine($"nextSection {deelnemerRechts.Name} rechts {track.Sections.ElementAt(i + 1).SectionType}");

                        //_positions[currentLinkedListNode.Value].DistanceRight = 0;

                        //currentSectionData.Right = null;

                        //nextSectionData.DistanceRight = 0;
                        //currentSectionData.DistanceRight = 0;
                    }
                    else if (nextSectionData.Left != null && nextSectionData.Right != null)
                    {
                        //_positions[currentLinkedListNode.Value].DistanceRight = 0;
                        currentSectionData.DistanceRight = 0;

                        //SetSectionData(currentLinkedListNode.Value, deelnemerRechts);

                        ///Debug.WriteLine("nextSection is vol");
                    }
                    //Debug.WriteLine($"{currentSectionData.Right} rechtsNextSection");
                }

                //=============================== met dictionary

                //if (currentSectionData.DistanceLeft >= 100)
                //{
                //    if (_positions[nextLinkedListNode.Value].Left == null)
                //    {
                //        _positions[nextLinkedListNode.Value].Left = deelnemerLinks;
                //        _positions[currentLinkedListNode.Value].Left = null;

                //        Debug.WriteLine($"nextSection {deelnemerLinks.Name}");

                //        _positions[currentLinkedListNode.Value].DistanceLeft = 0;
                //        _positions[nextLinkedListNode.Value].DistanceLeft = 0;
                //    }
                //    else if (_positions[nextLinkedListNode.Value].Right == null)
                //    {
                //        _positions[nextLinkedListNode.Value].Right = deelnemerLinks;
                //        _positions[currentLinkedListNode.Value].Left = null;

                //        Debug.WriteLine($"nextSection {deelnemerLinks.Name}");

                //        _positions[currentLinkedListNode.Value].DistanceLeft = 0;
                //        _positions[nextLinkedListNode.Value].DistanceRight = 0;
                //    }
                //    else if (nextSectionData.Left != null && nextSectionData.Right != null)
                //    {
                //        _positions[currentLinkedListNode.Value].DistanceLeft = 0;

                //        Debug.WriteLine("nextSection is vol");
                //    }
                //    //Debug.WriteLine($"{currentSectionData.Left} linksNextSection");
                //}

                //if (currentSectionData.DistanceRight >= 100)
                //{
                //    if (_positions[nextLinkedListNode.Value].Left == null)
                //    {
                //        _positions[nextLinkedListNode.Value].Left = deelnemerRechts;
                //        _positions[currentLinkedListNode.Value].Right = null;

                //        Debug.WriteLine($"nextSection {deelnemerRechts.Name}");

                //        _positions[currentLinkedListNode.Value].DistanceRight = 0;
                //        _positions[nextLinkedListNode.Value].DistanceLeft = 0;
                //    }
                //    else if (_positions[nextLinkedListNode.Value].Right == null)
                //    {
                //        _positions[nextLinkedListNode.Value].Right = deelnemerRechts;
                //        _positions[currentLinkedListNode.Value].Right = null;

                //        Debug.WriteLine($"nextSection {deelnemerRechts.Name}");

                //        _positions[currentLinkedListNode.Value].DistanceRight = 0;
                //        _positions[nextLinkedListNode.Value].DistanceRight = 0;
                //    }
                //    else if (nextSectionData.Left != null && nextSectionData.Right != null)
                //    {
                //        _positions[currentLinkedListNode.Value].DistanceRight = 0;

                //        Debug.WriteLine("nextSection is vol");
                //    }
                //    //Debug.WriteLine($"{currentSectionData.Right} rechtsNextSection");
                //}
            }
            //huidigeSection = previousLinkedListNode;

            foreach (Section section in track.Sections)
            {
                SectionData secdat = GetSectionData(section);
                Debug.WriteLine(section.SectionType.ToString());

                if (secdat.Left == null)
                {
                    Debug.WriteLine("null");
                }
                else
                {
                    Debug.WriteLine(secdat.Left.Name + " left in sectionData");
                }

                if (secdat.Right == null)
                {
                    Debug.WriteLine("null");
                }
                else
                {
                    Debug.WriteLine(secdat.Right.Name + " right in sectionData");
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