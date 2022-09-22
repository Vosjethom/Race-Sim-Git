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
            for (int i = 0; i < 7; i++)
            {
                Console.Write(_turnDownUpRechts[i]);
                Console.Write(_finishHorizontaal[i]);
                Console.Write(_turnDownUpLinks[i] + "\n");
            }

            for (int i = 0; i < 7; i++)
            {
                Console.Write(_straigthVerticaal[i] + "\n");
                Console.SetCursorPosition(18, 7 + i);
                Console.Write(_straigthVerticaal[i] + "\n");
            }

            for (int i = 0; i < 7; i++)
            {
                Console.Write(_turnUpDownLinks[i]);
                Console.Write(_straigthHorizontaal[i]);
                Console.Write(_turnUpDownRechts[i] + "\n");
            }
        }

        #region graphics

        private static string[] _finishHorizontaal = { "         ", "---------", " #       ", " #       ", " #       ", "---------", "         " };
        private static string[] _finishVerticaal = { " |     | ", " |#####| ", " |     | ", " |     | ", " |     | ", " |     | ", " |     | " };
        private static string[] _straigthHorizontaal = { "         ", "---------", "         ", "         ", "         ", "---------", "         " };
        private static string[] _straigthVerticaal = { " |     | ", " |     | ", " |     | ", " |     | ", " |     | ", " |     | ", " |     | " };
        private static string[] _turnDownUpLinks = { "         ", "-------\\ ", "       | ", "       | ", "       | ", "-\\     | ", " |     | " };
        private static string[] _turnUpDownLinks = { " |     | ", " |     \\-", " |       ", " |       ", " |       ", " \\-------", "         " };
        private static string[] _turnDownUpRechts = { "         ", " /-------", " |       ", " |       ", " |       ", " |     /-", " |     | " };
        private static string[] _turnUpDownRechts = { " |     | ", "-/     | ", "       | ", "       | ", "       | ", "-------/ ", "         " };

        #endregion

    }
}
