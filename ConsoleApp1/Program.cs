using Controller;
using System;
using Model;

namespace Tasker_Race_Sim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data.Initialize();

            Data.NextRace();

            Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}