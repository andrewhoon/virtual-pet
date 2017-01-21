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
            this.aggression -= 10;
            this.hydrationLevel += 13;
            this.hungerLevel -= 18;
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
            if (this.aggression >= 80  && this.aggression < 100)
            {
                Console.WriteLine(this.name + " has gotten too aggressive and is now a monster! \nYou may need to feed it or leave it alone to get back to normal!");
            }
            else if (this.aggression >= 100)
            {
                Console.WriteLine("You have killed " + this.name + " due to being over aggressive. " + this.name + "'s\nlittle heart couldn\'t take it.");
                Environment.Exit(0);
            }
            else if (this.aggression <= 20 && this.aggression > 0)
            {
                Console.WriteLine("You may want to play with " + this.name + " before this gremlin dies of boredom!");
            }
            else if(this.aggression <= 0)
            {
                Console.WriteLine(this.name + " ,unfortunately, has died of boredom.");
                Environment.Exit(0);
            }

        }

        public void Starving()
        {
            if (this.hungerLevel >= 80 && this.hungerLevel < 100)
            {
                Console.WriteLine("Your gremlin is starving!  Please feed " + this.name + " immediately!");
            }
            else if (this.hungerLevel >=100)
            {
                Console.WriteLine("Since you never fed your gremlin, we had to take " + this.name + " into protective\ncustody and away from you. You\'ll never see " + this.name + " again!");
                Environment.Exit(0);
            }
            else if (this.hungerLevel <= 20 && this.hungerLevel > 0)
            {
                Console.WriteLine("You may want to put your Gremlin on a diet, " + this.name + " has a poor BMI.");
            }
            else if (this.hungerLevel <= 0)
            {
                Console.WriteLine("We just sent " + this.name + " to fat camp and away from enablers such as you.");
                Environment.Exit(0);
            }
        }

        public void PureJoy()
        {
            if (this.happiness <= 20 && this.happiness > 0)
            {
                Console.WriteLine("Your gremlin is quite miserable.  Do you not spend quality time together?");
            }
            else if (this.happiness <= 0)
            {
                Console.WriteLine("Your gremlin left you for someone more fun.");
                Environment.Exit(0);
            }
            else if (this.happiness >= 100)
            {
                Console.WriteLine("There is no limit to how happy a gremlin can be!!!");
            }
        }

    }
}
