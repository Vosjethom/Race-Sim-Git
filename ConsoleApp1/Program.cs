using Controller;
using Model;
using System.Diagnostics;

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

            Visualization.Initialize(Data.CurrentRace);

            Visualization.DrawTrack(Data.CurrentRace.track);

            Data.CurrentRace.DriversChanged += (sender, e) =>
            {
                Visualization.DrawTrack(e._baan);
            };

            Data.CurrentRace.NewRace += (sender, e) =>
            {
                Visualization.Initialize(Data.CurrentRace);
                Visualization.DrawTrack(Data.CurrentRace.track);
                Debug.WriteLine("volgende circuit");
            };

            #endregion


            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}