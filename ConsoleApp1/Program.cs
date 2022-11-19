using Controller;

namespace Tasker_Race_Sim
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Episode 1

            //Data.Initialize();

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.track.Name}");

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.track.Name}");

            //Data.NextRace();

            //Console.WriteLine($"naam van de baan: {Data.CurrentRace.track.Name}");

            #endregion

            #region Episode 2

            //Data.Initialize();

            //Data.NextRace();

            //Visualization.Initialize(Data.CurrentRace);

            //Visualization.DrawTrack(Data.CurrentRace.track);

            #endregion

            #region Episode 3

            Data.Initialize();

            Data.NextRace();

            Visualization.Initialize(Data.CurrentRace);

            Data.CurrentRace.DriversChangedEvent += (sender, e) =>
            {
                Visualization.DrawTrack(Data.CurrentRace.track);
            };

            #endregion


            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}