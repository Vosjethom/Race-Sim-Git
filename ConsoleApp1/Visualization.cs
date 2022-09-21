using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tasker_Race_Sim
{
    public static class Visualization
    {
        public static void Initialize()
        {

        }

        public static void DrawTrack(/*Track baan*/)
        {
            foreach (var VARIABLE in _finishHorizontaal)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("===============");

            foreach (var VARIABLE in _finishVerticaal)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("===============");

            foreach (var VARIABLE in _straigthHorizontaal)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("===============");

            foreach (var VARIABLE in _straigthVerticaal)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("===============");

            foreach (var VARIABLE in _turnDownUpLinks)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("===============");

            foreach (var VARIABLE in _turnUpDownLinks)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("===============");

            foreach (var VARIABLE in _turnDownUpRechts)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("===============");

            foreach (var VARIABLE in _turnUpDownRechts)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        #region graphics

        private static string[] _finishHorizontaal = { "       ", "-------",  " # #   ", "       ", "  # #  ", "-------", "       " };
        private static string[] _finishVerticaal = { "|     |", "|     |", "|   # |", "| #   |", "|   # |", "| #   |", "|     |" };
        private static string[] _straigthHorizontaal = { "       ", "-------", "       ", "       ", "       ", "-------", "       " };
        private static string[] _straigthVerticaal = { "|     |", "|     |", "|     |", "|     |", "|     |", "|     |", "|     |" };
        private static string[] _turnDownUpLinks = { "       ", "-----\\ ", "     | ", "     | ", "     | ", "-\\   | ", " |   | "};
        private static string[] _turnUpDownLinks = { " |   | ", " |   \\-", " |     ", " |     ", " |     ", " \\-----", "       " };
        private static string[] _turnDownUpRechts = { "       ", " /-----", " |     ", " |      ", " |     ", " |   /-", " |   | " };
        private static string[] _turnUpDownRechts = { " |   | ", "-/   | ", "     | ", "     | ", "     | ", "-----/ ", "       " };

        #endregion
    }
}
