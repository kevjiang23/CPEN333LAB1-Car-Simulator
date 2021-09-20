using System.Linq;
using System.Collections.Generic;
using System;
namespace CarSimulator
{
    public class Highway
    {
        static void Main(string[] args)
        {
            int fleetNumberPerType = 25;
           /* // Step 1: implement fleets of arrays/lists per vehicle type and compute states 
            // Using enumerate.select() to generate array for objects
            Car.Tesla[] myTeslas = Enumerable.Range(0,fleetNumberPerType - 1).Select(x=> new Car.Tesla("Tesla", 1500, 1000, 0.51)).ToArray();
            Car.Prius[] myPriuses = Enumerable.Range(0, fleetNumberPerType - 1).Select(x => new Car.Prius("Prius", 1000, 750, 0.43)).ToArray();
            Car.Mazda[] myMazdas = Enumerable.Range(0, fleetNumberPerType - 1).Select(x => new Car.Mazda("Mazda", 1250, 1300, 0.46)).ToArray();
            Car.Herbie[] myHerbies = Enumerable.Range(0, fleetNumberPerType - 1).Select(x => new Car.Herbie("Herbie", 800, 900, 0.35)).ToArray(); */

            // Step 2: implement all the fleet in one list and compute states
            var myCars = new List<Car>();
            for (int i = 0; i < fleetNumberPerType; i++)
            {
                myCars.Add(new CarSimulator.Car.Tesla("Tesla", 1500, 1000, 0.51));
                myCars.Add(new CarSimulator.Car.Prius("Prius", 1000, 750, 0.43));
                myCars.Add(new CarSimulator.Car.Mazda("Mazda", 1250, 1300, 0.46));
                myCars.Add(new CarSimulator.Car.Herbie("Herbie", 800, 900, 0.35));
 }
            int dt = 1;

            // Loop through the time and list to drive all the vehicles (Step 1)

           /* for (double t = 0; t < 60; t += dt)
            {
                // Outer for loop ensures that all 100 vehicle's states are evaluated 60 times, once at each time step
                for (int i = 0; i < fleetNumberPerType - 1; i++)
                {
                    // Nested for loop ensures that all 4x25 cars are driven at each time step 
                    myTeslas[i].drive(dt);
                    myPriuses[i].drive(dt);
                    myMazdas[i].drive(dt);
                    myHerbies[i].drive(dt);

                    // Display the cars states acceleration, speed, position at each time step
                    Console.WriteLine("t:{0}, Tesla: x:{1}, v:{2}, a:{3}, Prius = x:{4}, v:{5}, a:{6}," +
                    ", Mazda = x:{4}, v:{5}, a:{6}, Herbie = x:{4}, v:{5}, a:{6}", myTeslas[i].myCarState.time, myTeslas[i].myCarState.position,
                    myTeslas[i].myCarState.velocity, myTeslas[dt].myCarState.acceleration, myPriuses[i].myCarState.position, myPriuses[i].myCarState.velocity,
                    myPriuses[i].myCarState.acceleration, myMazdas[i].myCarState.position, myMazdas[i].myCarState.velocity, myMazdas[i].myCarState.acceleration);
                }
            }*/

            
            // Loop through the time and list to drive all the vehicles (Step 2)
            for (double t = 0; t < 60; t += dt)
            {
                for (int i = 0; i < fleetNumberPerType; i++)
                {
                    // Drive cars at each index through nested for-loop
                    myCars[i].drive(dt);

                    // Display the cars states acceleration, speed, position at each time step
                    Console.WriteLine("t:{0}, Tesla: x:{1}, v:{2}, a:{3}, Prius = x:{4}, v:{5}, a:{6}," +
                    ", Mazda = x:{4}, v:{5}, a:{6}, Herbie = x:{4}, v:{5}, a:{6}", myCars[i].myCarState.time, myCars[i].myCarState.position,
                    myCars[i].myCarState.velocity, myCars[dt].myCarState.acceleration, myCars[i].myCarState.position, myCars[i].myCarState.velocity,
                    myCars[i].myCarState.acceleration, myCars[i].myCarState.position, myCars[i].myCarState.velocity, myCars[i].myCarState.acceleration);
                }
            }
        }

    }
}