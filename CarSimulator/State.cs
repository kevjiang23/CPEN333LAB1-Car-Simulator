using System;
namespace CarSimulator
{
    class Program
    {
        /*//Created new instance of main program by commenting out other files
        static void Main(string[] args)
        {
            // Generates a class with only two variables
            State sample_state = new State();

            // set() function to change values for all variables
            sample_state.set(3,4,5,6); 

            //Print out elements of generated State class
            Console.WriteLine("positon:{0}, velocity:{1}, acceleration:{2}, time:{3}", sample_state.position,
                sample_state.velocity, sample_state.acceleration, sample_state.time); 
        }*/
    }

    public class State
    {
        public double position;
        public double velocity;
        public double acceleration;
        public double time;
 
        // Set function allowing users to change parameter values
         public void set(double position, double velocity, double acceleration, double time)
        {
            this.position = position;
            this.velocity = velocity;
            this.acceleration = acceleration;
            this.time = time;
        }
        // Default constructor to initialize all values to 0
        public State()
        {
            position = 0; velocity = 0; acceleration = 0; time = 0;
        }
        // Overloaded constructors to initialize class variables upon construction
        public State(double position)
        {
            this.position = position;
        }
        public State(double position, double velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }
        public State(double position, double velocity, double acceleration)
        {
            this.position = position;
            this.velocity = velocity;
            this.acceleration = acceleration;
        }
        public State(double position, double velocity, double acceleration, double time)
        {
            this.position = position;
            this.velocity = velocity;
            this.acceleration = acceleration;
            this.time = time;
        }
    }
    }

