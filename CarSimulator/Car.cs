using System;
namespace CarSimulator
{
    public class Car
    {
        protected double mass;
        protected string model;
        protected double dragArea;
        protected double engineForce;
        public State myCarState;
        /// implement constructor and methods
       
        // Car Constructor
        public Car(string model, double mass, double engineForce, double dragArea)
        {
            this.model = model;
            this.mass = mass;
            this.engineForce = engineForce;
            this.dragArea = dragArea;

            //Create an instance of State for myCarState; values are initialized to 0 given the default constructor from State.cs
            this.myCarState = new State();
        }

        public Car()
        {
            this.myCarState = new State();
            this.myCarState.position = 0;
            this.myCarState.velocity = 0;
            this.myCarState.acceleration = 0;
            this.myCarState.time = 0;
        }

        // getModel() function
        public string getModel()
        {
            Console.WriteLine("model:{0} ", this.model);
            return this.model;
        }

        // getMass() function
        public double getMass()
        {
            Console.WriteLine("mass:{0} ", this.mass);
            return this.mass;
        }

        // getState() function
        public State getState()
        {
            // Returns the current myCarState and prints the variables in console
            State gotState = new State();
            gotState.position = this.myCarState.position;
            gotState.velocity = this.myCarState.velocity;
            gotState.acceleration = this.myCarState.acceleration;
            gotState.time = this.myCarState.time;

            Console.WriteLine("position:{0}, velocity:{1}, acceleration:{2}, time:{3}", this.myCarState.position, this.myCarState.velocity,
                this.myCarState.acceleration, this.myCarState.time);

            return gotState;
        }

        // drive() function
        public virtual void drive(double dt)
        {
            // use Car() parameters to determine net force and acceleration
            double dragForce = 0.5 * this.dragArea * 1.225 * this.myCarState.velocity * this.myCarState.velocity;
            double netForce = this.engineForce - dragForce;
            this.myCarState.acceleration = CarSimulator.Physics1D.compute_acceleration(netForce, mass);

            // Calculated position before velocity so that the calculation can be performed with the original velocity
            this.myCarState.position = CarSimulator.Physics1D.compute_position(this.myCarState.position, this.myCarState.velocity, dt);
            this.myCarState.velocity = CarSimulator.Physics1D.compute_velocity(this.myCarState.velocity, this.myCarState.acceleration, dt);
            this.myCarState.time = this.myCarState.time + dt;
        }

        // accelerate() function
        public void accelerate(bool input)
        {
            if (input == false)
                this.myCarState.acceleration = 0; //If false, stop acceleration; otherwise continue acceleration calculations
        }

        //implement inheritence
        public class Prius : Car
        {
            public Prius() : base() // Prius specifications
            {
            
            }
            public Prius(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {
                this.model = model;
                this.mass = mass;
                this.engineForce = engineForce;
                this.dragArea = dragArea;
            }
        }
        public class Mazda : Car
        {
            public Mazda() : base() 
            {
            }
            public Mazda(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {
                this.model = model;
                this.mass = mass;
                this.engineForce = engineForce;
                this.dragArea = dragArea;
            }
        }
        public class Tesla : Car
        {
            public Tesla() : base() 
            {

            }
            public Tesla(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {
                this.model = model;
                this.mass = mass;
                this.engineForce = engineForce;
                this.dragArea = dragArea;
            }
        }
        public class Herbie : Car // Override
        {

            //Added 'virtual' to the drive() function so it can be overriden
            public override void drive(double dt)
            {
                // I'm gonna say that Herbie magically ignores drag force; rest of function is the same
                double dragForce = 0;
                double netForce = this.engineForce - dragForce;
                this.myCarState.acceleration = CarSimulator.Physics1D.compute_acceleration(netForce, mass);
                this.myCarState.position = CarSimulator.Physics1D.compute_position(this.myCarState.position, this.myCarState.velocity, dt);
                this.myCarState.velocity = CarSimulator.Physics1D.compute_velocity(this.myCarState.velocity, this.myCarState.acceleration, dt);
                this.myCarState.time = this.myCarState.time + dt;
            }

            public Herbie() : base()
            {
            }
            public Herbie(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {
                this.model = model;
                this.mass = mass;
                this.engineForce = engineForce;
                this.dragArea = dragArea;
            }
        }


    }
}