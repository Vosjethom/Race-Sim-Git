using Controller;

namespace Tasker_Race_Sim
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Episode 1

            Data.Initialize();

            Data.NextRace();

            Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            Data.NextRace();

            Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            Data.NextRace();

            Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            #endregion

            #region Episode 2

            //Data.Initialize();

            //Visualization.Initialize();

            //Data.NextRace();

            //Visualization.DrawTrack(Data.CurrentRace.Track);

            //Visualization.PlaatsDeelnemer("qwerty 1 qwerty 2", Data._competition.Participants[0],
            //    Data._competition.Participants[1]);

            #endregion




            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}