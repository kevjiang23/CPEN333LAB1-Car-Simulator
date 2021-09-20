using System;
namespace CarSimulator
{
    public class DragRace
    {
        static void Main(string[] args)
        {

            Car myTesla = new Car("Tesla", 1500, 1000, 0.51);
            Car myPrius = new Car("Prius", 1000, 750, 0.43);


            // drive for 60 seconds with delta time of 1s
            double dt = 1;

            for (double t = 0; t < 60; t += dt)
            {
                myTesla.drive(dt);
                myPrius.drive(dt);

                // Print the time and current state
                Console.WriteLine("t:{0}, Tesla: x:{1}, v:{2}, a:{3}, Prius = x:{4}, v:{5}, a:{6}", t, myTesla.myCarState.position, myTesla.myCarState.velocity, 
                    myTesla.myCarState.acceleration, myPrius.myCarState.position, myPrius.myCarState.velocity,
                    myPrius.myCarState.acceleration);

                // Print who is in lead
                if (myTesla.myCarState.position > myPrius.myCarState.position)
                    Console.WriteLine("The Tesla is in the lead!");
                else if (myPrius.myCarState.position > myTesla.myCarState.position)
                    Console.WriteLine("The Prius is in the lead!");
                else
                    Console.WriteLine("Both cars are tied!");

                // Set win conditions for both cars
                if (myTesla.myCarState.position >= 402.3)
                {
                    Console.WriteLine("The Tesla has won!");
                    break; // Break statement to exit the loop and stop the computations
                }
                if (myPrius.myCarState.position >= 402.3)
                {
                    Console.WriteLine("The Prius has won!");
                    break;
                }
            }
        }
    }
}
