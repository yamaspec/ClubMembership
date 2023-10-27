using System;

namespace ThermostatEventsApplication
{
    public class CoolingMechanism : ICoolingMechanism
    {
        void ICoolingMechanism.Off()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism off...");
            Console.WriteLine();
        }

        void ICoolingMechanism.On()
        {
            Console.WriteLine();
            Console.WriteLine("Switching cooling mechanism on...");
            Console.WriteLine();
        }
    }
}
