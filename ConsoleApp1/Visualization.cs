using Controller;
using Model;
namespace Tasker_Race_Sim
{
    public static class Visualization
    {
        //public delegate void DriversChanged(Track baan);
        public static void Initialize(Race race)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Naam circuit: {race.track.Name}");
            _race = race;
        }

        private static Race _race;
        private static int coordinaatX = 25;
        private static int coordinaatY = 1;
        private static int direction;
        public static void DrawTrack(Track baan)
        {
            foreach (var sector in baan.Sections)
            {
                iParticipant deelnemerLinks = _race.GetSectionData(sector).Left;
                iParticipant deelnemerRechts = _race.GetSectionData(sector).Right;

                switch (sector.SectionType)
                {
                    case SectionTypes._startGridHorizontaal:
                        direction = 4;
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        foreach (string section in _startGridHorizontaal)
                        {
                            Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                            Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        }
                        coordinaatX -= 7;
                        coordinaatY -= 7;
                        direction = 4;
                        break;

                    case SectionTypes._startGridVerticaal:
                        direction = 1;
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        foreach (string section in _startGridHorizontaal)
                        {
                            Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                            Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        }
                        coordinaatY -= 7;
                        direction = 1;
                        break;

                    case SectionTypes._finishHorizontaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        foreach (string section in _finishHorizontaal)
                        {
                            Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                            Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        }
                        coordinaatX -= 7;
                        coordinaatY -= 7;
                        direction = 4;
                        break;

                    case SectionTypes._finishVerticaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        foreach (var section in _finishVerticaal)
                        {
                            Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                            Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        }
                        coordinaatY -= 7;
                        direction = 1;
                        break;

                    case SectionTypes._straigthHorizontaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        if (direction == 2)
                        {
                            foreach (var section in _straigthHorizontaal)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX += 7;
                            coordinaatY -= 7;
                            direction = 2;
                        }

                        if (direction == 4)
                        {
                            foreach (var section in _straigthHorizontaal)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX -= 7;
                            coordinaatY -= 7;
                            direction = 4;
                        }
                        break;

                    case SectionTypes._straigthVerticaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        if (direction == 1)
                        {
                            foreach (var section in _straigthVerticaal)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY += 7;
                            direction = 1;
                        }

                        if (direction == 3)
                        {
                            foreach (var section in _straigthVerticaal)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY--;
                            direction = 3;
                        }
                        break;

                    case SectionTypes._turnDownUpLinks:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        if (direction == 1)
                        {
                            foreach (var section in _turnDownUpLinks)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX -= 7;
                            coordinaatY -= 7;
                            direction = 4;
                        }

                        if (direction == 2)
                        {
                            foreach (var section in _turnDownUpLinks)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY--;
                            direction = 3;
                        }
                        break;

                    case SectionTypes._turnUpDownLinks:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        if (direction == 3)
                        {
                            foreach (var section in _turnUpDownLinks)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX += 7;
                            coordinaatY -= 7;
                            direction = 2;
                        }

                        if (direction == 4)
                        {
                            foreach (var section in _turnUpDownLinks)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY -= 13;
                            direction = 1;
                        }
                        break;

                    case SectionTypes._turnDownUpRechts:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        if (direction == 1)
                        {
                            foreach (var section in _turnDownUpRechts)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX += 7;
                            coordinaatY -= 7;
                            direction = 2;
                        }

                        if (direction == 4)
                        {
                            foreach (var section in _turnDownUpRechts)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY--;
                            direction = 3;
                        }
                        break;

                    case SectionTypes._turnUpDownRechts:
                        Console.SetCursorPosition(coordinaatX, coordinaatY);

                        if (direction == 2)
                        {
                            foreach (var section in _turnUpDownRechts)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY -= 13;
                            direction = 1;
                        }

                        if (direction == 3)
                        {
                            foreach (var section in _turnUpDownRechts)
                            {
                                Console.Write(VerplaatsDeelnemer(section, deelnemerLinks, deelnemerRechts));
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX -= 7;
                            coordinaatY -= 7;
                            direction = 4;
                        }
                        break;
                }
            }
            coordinaatX = 25;
            coordinaatY = 1;
        }

        public static string VerplaatsDeelnemer(string sectie, iParticipant replace1, iParticipant replace2)
        {
            if (replace1 == null && replace2 == null)
            {
                if (sectie.Contains("1"))
                {
                    string newSectie1 = sectie.Replace("1", " ");
                    return newSectie1;
                }
                if (sectie.Contains("2"))
                {
                    string newSectie2 = sectie.Replace("2", " ");
                    return newSectie2;
                }
            }

            else if (replace1 == null && replace2 != null)
            {
                if (sectie.Contains("1"))
                {
                    string newSectie1 = sectie.Replace("1", " ");
                    return newSectie1;
                }

                if (sectie.Contains("2"))
                {
                    string newSectie2 = sectie.Replace("2", replace2.Name.Substring(0, 1));
                    return newSectie2;
                }
            }

            else if (replace1 != null && replace2 == null)
            {
                if (sectie.Contains("1"))
                {
                    string newSectie1 = sectie.Replace("1", replace1.Name.Substring(0, 1));
                    return newSectie1;
                }

                if (sectie.Contains("2"))
                {
                    string newSectie2 = sectie.Replace("2", " ");
                    return newSectie2;
                }
            }

            else
            {

                if (sectie.Contains("1"))
                {
                    string newSectie1 = sectie.Replace("1", replace1.Name.Substring(0, 1));
                    return newSectie1;
                }

                if (sectie.Contains("2"))
                {
                    string newSectie2 = sectie.Replace("2", replace2.Name.Substring(0, 1));
                    return newSectie2;
                }
            }
            return sectie;
        }

        //public static void EventHandlerDriversChanged(DriversChangedEventArgs driversChanged)
        //{
        //    DrawTrack(driversChanged.Baan);
        //}

        #region graphics
        private static string[] _startGridHorizontaal = { "       ", "-------", " [1    ", "       ", "   [2  ", "-------", "       " };
        private static string[] _startGridVerticaal = { " |   | ", " |###| ", " |  ^| ", " |  1| ", " |^  | ", " |2  | ", " |   | " };
        private static string[] _finishHorizontaal = { "       ", "-------", " # 1   ", " #     ", " #  2  ", "-------", "       " };
        private static string[] _finishVerticaal = { " |   | ", " |###| ", " |1  | ", " |   | ", " |  2| ", " |   | ", " |   | " };
        private static string[] _straigthHorizontaal = { "       ", "-------", " 1     ", "       ", "  2    ", "-------", "       " };
        private static string[] _straigthVerticaal = { " |   | ", " |1  | ", " |   | ", " |   | ", " |  2| ", " |   | ", " |   | " };
        private static string[] _turnDownUpLinks = { "       ", "-----\\ ", "  1  | ", "     | ", "    2| ", "-\\   | ", " |   | " };
        private static string[] _turnUpDownLinks = { " |   | ", " |   \\-", " |  1  ", " |     ", " |2    ", " \\-----", "       " };
        private static string[] _turnDownUpRechts = { "       ", " /-----", " | 1   ", " |     ", " |   2 ", " |   /-", " |   | " };
        private static string[] _turnUpDownRechts = { " |   | ", "-/   | ", " 1   | ", "     | ", "   2 | ", "-----/ ", "       " };
        #endregion
    }
}
