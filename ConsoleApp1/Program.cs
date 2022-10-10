using Controller;
using Model;

namespace Tasker_Race_Sim
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Episode 1

            //Data.Initialize();

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.Track.Name}");

            #endregion

            #region Episode 2

            //Data.Initialize();

            //Visualization.Initialize();

            //Data.NextRace();

            //Visualization.DrawTrack(Data.CurrentRace.Track);

            #endregion

            #region Episode 3

            Data.Initialize();

            Visualization.Initialize();

            Data.NextRace();

            Data.CurrentRace.DriversChangedEvent += (sender, e) =>
            {
                Visualization.DrawTrack(Data.CurrentRace.Track);
            };

            #endregion


            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}