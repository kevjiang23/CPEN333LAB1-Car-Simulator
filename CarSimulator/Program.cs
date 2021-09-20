/*using System;

namespace CarSimulator
{
    class Program
    {
       static void Main(string[] args)
        {
           // read in car mass
            Console.WriteLine("Enter the mass of the car (kg): ");
            double mass;
            mass = Convert.ToDouble(Console.ReadLine());

            // read in engine force
            Console.WriteLine("Enter the net force of the engine (N): ");
            double engine_force;
            engine_force = Convert.ToDouble(Console.ReadLine());

            // read in drag area coefficient
            Console.WriteLine("Enter the car's drag area (m^2): ");
            double drag_area;
            drag_area = Convert.ToDouble(Console.ReadLine());

            // read in time step
            Console.WriteLine("Enter the simulation time step (s): ");
            double dt;
            dt = Convert.ToDouble(Console.ReadLine());

            // read in total number of simulation steps
            Console.WriteLine("Enter the number of time steps (int): ");
            int N;
            N = Convert.ToInt32(Console.ReadLine());

            // initialize the car's state
            double x0 = 0;  // initial position
            double v = 0;  // initial velocity
            double t = 0;  // initial time
            double fd, x1, a; // drag force and secondary position and acceleration


            // run the simulation
            for (int i = 0; i < N; ++i)
            {
                // Compute updated force
                fd = 0.5 * drag_area * 1.225 * v * v; //Drag force equation
                double fn = engine_force - fd; //Fnet = Fengine - Fdrag

                // Compute car's acceleration from Fnet
                a = CarSimulator.Physics1D.compute_acceleration(fn, mass);

                // Compute car's new velocity from previous calculated acceleration and dt
                double v1 = CarSimulator.Physics1D.compute_velocity(v, a, dt);

                // Compute car's new position from original velocity and dt
                x1 = CarSimulator.Physics1D.compute_position(x0, v, dt);

                // Increment time
                t += dt;  

                // Update initial values for pos and vel for next time step
                v = v1; 
                x0 = x1; 
        
                // Print the time and current state
                Console.WriteLine("t:{0}, a:{1}, v:{2}, x0:{3}, fd:{4} ", t, a, v, x0, fd);
            }
        }
    }
}

/* Simulating with short time steps yield reasonable acceleration and velocity readings. 
   Increasing the time step vastly increases the amount each value changes by and greatly
   increases the drag force */
