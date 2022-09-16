using Controller;

namespace Tasker_Race_Sim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data.Initialize();

            Console.WriteLine(Data._competition.Tracks.Count);

            Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            Data.NextRace();

            Console.WriteLine(Data._competition.Tracks.Count);

            Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            Data.NextRace();

            Console.WriteLine(Data._competition.Tracks.Count);

            Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}