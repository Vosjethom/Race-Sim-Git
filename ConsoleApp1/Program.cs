using Controller;
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

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            Visualization.Initialize();

            Visualization.DrawTrack(Data.CurrentRace.Track);

            

            Console.WriteLine(Visualization.PlaatsDeelnemer("qwerty 1 qwerty 2", Data._competition.Participants[0],
                Data._competition.Participants[1]));


            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}