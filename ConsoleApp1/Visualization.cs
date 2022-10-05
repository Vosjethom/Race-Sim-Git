using Model;

namespace Tasker_Race_Sim
{
    public static class Visualization
    {
        public static void Initialize()
        {
            //Console.SetWindowSize(100, 100);
            Console.SetCursorPosition(0, 1);
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        private static int coordinaatX = 50;
        private static int coordinaatY = 50;

        private static int direction;

        public static void DrawTrack(Track baan)
        {
            foreach (var sector in baan.Sections)
            {
                switch (sector.SectionType)
                {
                    case SectionTypes._finishHorizontaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        foreach (string section1 in _finishHorizontaal)
                        {
                            Console.Write(section1);
                            Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        }
                        coordinaatX -= 7;
                        coordinaatY -= 8;
                        direction = 4;
                        break;

                    case SectionTypes._finishVerticaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        foreach (var section2 in _finishVerticaal)
                        {
                            Console.Write(section2);
                            Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        }
                        coordinaatY -= 8;
                        direction = 1;
                        break;

                    case SectionTypes._straigthHorizontaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        if (direction == 2)
                        {
                            foreach (var section3 in _straigthHorizontaal)
                            {
                                Console.Write(section3);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX += 7;
                            coordinaatY -= 8;
                            direction = 2;
                        }

                        if (direction == 4)
                        {
                            foreach (var section3 in _straigthHorizontaal)
                            {
                                Console.Write(section3);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX -= 7;
                            coordinaatY -= 8;
                            direction = 4;
                        }
                        break;

                    case SectionTypes._straigthVerticaal:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        if (direction == 1)
                        {
                            foreach (var section3 in _straigthVerticaal)
                            {
                                Console.Write(section3);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY += 8;
                            direction = 1;
                        }

                        if (direction == 3)
                        {
                            foreach (var section3 in _straigthVerticaal)
                            {
                                Console.Write(section3);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY--;
                            direction = 3;
                        }
                        break;

                    case SectionTypes._turnDownUpLinks:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        if (direction == 1)
                        {
                            foreach (var section5 in _turnDownUpLinks)
                            {
                                Console.Write(section5);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX -= 7;
                            coordinaatY -= 8;
                            direction = 4;
                        }

                        if (direction == 2)
                        {
                            foreach (var section5 in _turnDownUpLinks)
                            {
                                Console.Write(section5);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY--;
                            direction = 3;
                        }
                        break;

                    case SectionTypes._turnUpDownLinks:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        if (direction == 3)
                        {
                            foreach (var section6 in _turnUpDownLinks)
                            {
                                Console.Write(section6);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX += 7;
                            coordinaatY -= 8;
                            direction = 2;
                        }

                        if (direction == 4)
                        {
                            foreach (var section6 in _turnUpDownLinks)
                            {
                                Console.Write(section6);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY -= 15;
                            direction = 1;
                        }
                        break;

                    case SectionTypes._turnDownUpRechts:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        if (direction == 1)
                        {
                            foreach (var section7 in _turnDownUpRechts)
                            {
                                Console.Write(section7);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX += 7;
                            coordinaatY -= 8;
                            direction = 2;
                        }

                        if (direction == 4)
                        {
                            foreach (var section7 in _turnDownUpRechts)
                            {
                                Console.Write(section7);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY--;
                            direction = 3;
                        }
                        break;

                    case SectionTypes._turnUpDownRechts:
                        Console.SetCursorPosition(coordinaatX, coordinaatY++);
                        if (direction == 2)
                        {
                            foreach (var section8 in _turnUpDownRechts)
                            {
                                Console.Write(section8);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatY -= 15;
                            direction = 1;
                        }

                        if (direction == 3)
                        {
                            foreach (var section8 in _turnUpDownRechts)
                            {
                                Console.Write(section8);
                                Console.SetCursorPosition(coordinaatX, coordinaatY++);
                            }
                            coordinaatX -= 7;
                            coordinaatY -= 8;
                            direction = 4;
                        }
                        break;
                }
            }
        }

        public static string PlaatsDeelnemer(string sectie, iParticipant replace1, iParticipant replace2)
        {
            //if (sectie.Contains('1') && sectie.Contains('2'))
            //{
            //    string newSectie3 = sectie.Replace("1", replace1.Name.Substring(0, 1));
            //    string newSectie4 = newSectie3.Replace("2", replace2.Name.Substring(0, 1));
            //    return newSectie4;
            //}

            if (sectie.Contains('1'))
            {
                string newSectie1 = sectie.Replace("1", replace1.Name.Substring(0, 1));
                return newSectie1;
            }

            if (sectie.Contains('2'))
            {
                string newSectie2 = sectie.Replace("1", replace2.Name.Substring(0, 1));
                return newSectie2;
            }

            return sectie;
        }

        #region graphics

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
