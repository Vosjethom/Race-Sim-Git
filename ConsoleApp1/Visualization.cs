using Model;

namespace Tasker_Race_Sim
{
    public static class Visualization
    {
        public static void Initialize()
        {
            Console.SetCursorPosition(0, 1);
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        public static void DrawTrack(Track baan)
        {
            foreach (var sector in baan.Sections)
            {
                switch (sector.SectionType)
                {
                    case SectionTypes._finishHorizontaal:
                        foreach (string section1 in _finishHorizontaal)
                        {
                            Console.WriteLine(section1);
                        }
                        break;

                    case SectionTypes._finishVerticaal:
                        foreach (var section2 in _finishVerticaal)
                        {
                            Console.WriteLine(section2);
                        }
                        break;

                    case SectionTypes._straigthHorizontaal:
                        foreach (var section3 in _straigthHorizontaal)
                        {
                            Console.WriteLine(section3);
                        }
                        break;

                    case SectionTypes._straigthVerticaal:
                        foreach (var section4 in _straigthVerticaal)
                        {
                            Console.WriteLine(section4);
                        }
                        break;

                    case SectionTypes._turnDownUpLinks:
                        foreach (var section5 in _turnDownUpLinks)
                        {
                            Console.WriteLine(section5);
                        }
                        break;

                    case SectionTypes._turnUpDownLinks:
                        foreach (var section6 in _turnUpDownLinks)
                        {
                            Console.WriteLine(section6);
                        }
                        break;

                    case SectionTypes._turnDownUpRechts:
                        foreach (var section7 in _turnDownUpRechts)
                        {
                            Console.WriteLine(section7);
                        }
                        break;

                    case SectionTypes._turnUpDownRechts:
                        foreach (var section8 in _turnUpDownRechts)
                        {
                            Console.WriteLine(section8);
                        }
                        break;
                }
            }
        }

        public static string PlaatsDeelnemer(string sectie, iParticipant replace1, iParticipant replace2)
        {
            sectie.Replace("1", replace1.Name.Substring(0,1));
            sectie.Replace("2", replace2.Name.Substring(0,1));

            return sectie;
        }

        #region graphics

        private static string[] _finishHorizontaal = { "         ", "---------", " # 1     ", " #       ", " #  2    ", "---------", "         " };
        private static string[] _finishVerticaal = { " |     | ", " |#####| ", " | 1   | ", " |     | ", " |   2 | ", " |     | ", " |     | " };
        private static string[] _straigthHorizontaal = { "         ", "---------", " 1       ", "         ", "  2      ", "---------", "         " };
        private static string[] _straigthVerticaal = { " |     | ", " | 1   | ", " |     | ", " |     | ", " |   2 | ", " |     | ", " |     | " };
        private static string[] _turnDownUpLinks = { "         ", "-------\\ ", "  1    | ", "       | ", "     2 | ", "-\\     | ", " |     | " };
        private static string[] _turnUpDownLinks = { " |     | ", " |     \\-", " |    1  ", " |       ", " |    2  ", " \\-------", "         " };
        private static string[] _turnDownUpRechts = { "         ", " /-------", " |    1  ", " |       ", " |    2  ", " |     /-", " |     | " };
        private static string[] _turnUpDownRechts = { " |     | ", "-/     | ", " 1     | ", "       | ", " 2     | ", "-------/ ", "         " };

        #endregion

    }
}
