using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker_Race_Sim
{
    public static class Visualization
    {
        public static void Initialize()
        {

        }

        #region graphics

        private static string[] _finishHorizontaal = { "       ", "-------",  " # #   ", "       ", "  # #  ", "-------", "       " };
        private static string[] _finishVerticaal = { "|     |", "|     |", "|   # |", "| #   |", "|   # |", "| #   |", "|     |" };
        private static string[] _straigthHorizontaal = { "       ", "-------", "       ", "       ", "       ", "-------", "       " };
        private static string[] _straigthVerticaal = { "|     |", "|     |", "|     |", "|     |", "|     |", "|     |", "|     |" };
        private static string[] _turnDownUpLinks = { "       ", "-----\\ ", "     | ", "      | ", "-\\   | ", " |   | ", " |   | "};

        #endregion
    }
}
