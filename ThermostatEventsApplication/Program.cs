using System;

namespace ThermostatEventsApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            // The sequence is: Start device, thermostat and heat sensor.
            // Then the heat sensor keeps monitoring the temperature until the device is shut down,
            Console.WriteLine("Press any key to start the device...");
            Console.ReadKey();

            IDevice device = new Device();
            device.RunDevice();
            Console.ReadKey();
        }
    }
}
