using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class Gremlin
    {
        private string name;
        private int aggression = 50;
        private int hydrationLevel = 50;
        private int happiness = 50;
        private int hungerLevel = 50;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Aggression
        {
            get { return this.aggression; }
            set { this.aggression = value; }

        }

        public int HydrationLevel
        {
            get { return this.hydrationLevel; }
            set { this.hydrationLevel = value; }
        }

        public int Happiness
        {
            get { return this.happiness; }
            set { this.happiness = value; }
        }

        public int HungerLevel
        {
            get { return this.hungerLevel; }
            set { this.hungerLevel = value; }
        }

        public void GetWater()
        {
         //put a random in here as to get different results
            this.aggression += 20;
            this.hydrationLevel -= 20;
            this.happiness += 10;
        }

        public void GetFood()
        {
            this.aggression -= 20;
            this.hydrationLevel += 20;
            this.hungerLevel -= 35;
            this.happiness += 15;
        }

        public void DoNothing()
        {
            this.aggression -= 10;
            this.hydrationLevel += 10;
            this.hungerLevel += 10;
            this.happiness -= 5;
        }

        public void PlayTime()
        {
            this.aggression += 10;
            this.hydrationLevel += 5;
            this.hungerLevel += 5;
            this.happiness += 25;
        }

        public void Monster()
        {
            if (this.aggression >= 100)
            {
                Console.WriteLine(this.name + " has gotten too aggressive and is now a monster! \nYou may need to feed it or leave it alone to get back to normal!");
            }
        }

    }
}
