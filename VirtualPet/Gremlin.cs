using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class Gremlin
    {
        private string name;        //field to set initial defaults for name and levels of aggression, thirst, etc.
        private int aggression = 50;    //These private ints will be altered for gremlin1 in the properites
        private int hydrationLevel = 50;
        private int happiness = 50;
        private int hungerLevel = 50;
        private int ticks = 0;

        public string Name      //these properties help us adjust the variable scores for the game.
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

        public int Ticks
        {
            get { return this.ticks; }
            set { this.ticks = value; }
        }

        public void GetWater()
        {
            //put a random in here as to get different results. Some results have a better chance of being selected than others.
            Random ran = new Random();
            int anyNumber = ran.Next(0, 11);
            if (anyNumber <= 3)
            {
                this.aggression += 25;  //the higher the aggression level, the more likely the gremlin turns into a monster.
                this.hydrationLevel -= 20;  //hydrationLevel lowering means thirst is lowering. The gremlin isn't as thirsy after.
                this.happiness += 10;   //with happiness level, the higher the score the happier the gremlin is.
                this.hungerLevel += 5;  //hungerLevel lowering means the gremlin is less hungry.
                Console.WriteLine("Your gremlin appreciates being hydrated, but be careful he doesn't get too aggressive!");
            }
            else if (anyNumber <= 6)
            {
                this.aggression += 18;
                this.hydrationLevel -= 10;
                this.happiness += 3;
                this.hungerLevel += 3;
            }
            else if (anyNumber <= 9)
                {
                this.aggression += 13;
                this.hydrationLevel -= 12;
                this.happiness -= 5;
                this.hungerLevel += 10;
                }
            else
            {
                this.aggression += 32;  //even though he didn't accept the water, he is being aggressive.
                this.happiness -= 16;
                this.hungerLevel += 12;
                Console.WriteLine("Gremlins generally cannot have too much water. This gremlin got angry and refuses.");
            }
        }

        public void GetFood()   //this method will be called if the user selects feed from the menu
        {
            Random ran = new Random();
            int anyNumber = ran.Next(0, 11);
            if (anyNumber <= 3)
            {
                this.aggression -= 10;
                this.hydrationLevel += 13;
                this.hungerLevel -= 20;
                this.happiness += 15;
                Console.WriteLine("Your gremlin thinks that food really hit the spot!");
            }
            else if (anyNumber <= 9)
            {
                this.aggression -= 20;
                this.hydrationLevel += 9;
                this.hungerLevel -= 16;
                this.happiness += 12;
            }
            else
            {
                this.aggression += 10;
                this.happiness -= 20;
                Console.WriteLine("Your gremlin refuses to eat.");
            }
        }

        public void DoNothing()  //this method will be called when the user doesn't select another offered option in menu
        {
            Random ran = new Random();
            int anyNumber = ran.Next(0, 11);
            if (anyNumber <= 5)
            {
                this.aggression -= 10;
                this.hydrationLevel += 10;
                this.hungerLevel += 10;
                this.happiness -= 5;
            }
            else
            {
                this.aggression -= 25;
                this.hydrationLevel += 2;
                this.hungerLevel += 2;
                this.happiness -= 20;
                Console.WriteLine("Your gremlin is a little more relaxed now.");
            }

        }

        public void PlayTime()  //this method will be called from the menu if the user selects "play"
        {
            Random ran = new Random();
            int anyNumber = ran.Next(0, 11);
            if (anyNumber <= 3)
            {
                this.aggression += 10;
                this.hydrationLevel += 5;
                this.hungerLevel += 5;
                this.happiness += 25;
                Console.WriteLine("Your gremlin loves playtime!");
            }
            else if (anyNumber <= 6)
            {
                this.aggression += 6;
                this.hydrationLevel += 10;
                this.hungerLevel += 10;
                this.happiness += 17;
            }
            else if (anyNumber <= 9)
            {
                this.aggression += 4;
                this.hydrationLevel += 14;
                this.hungerLevel += 15;
                this.happiness += 12;
            }
            else
            {
                this.aggression += 20;
                this.happiness -= 30;
                Console.WriteLine("Your gremlin does not want to play right now.");
            }
        }

            public void WaterDump() //this particular method is always bad. You should not dump water onto a gremlin.
        {
            Random ran = new Random();
            int anyNumber = ran.Next(0, 1);
            if (anyNumber == 0)
            {
                this.aggression = 99;
                this.happiness = 20;
                this.hungerLevel += 15;
                Console.WriteLine("You really shouldn't do that. " + this.Name + " is now a monster!");
            }
            else
            {
                this.aggression = 99;
                this.happiness = 10;
                this.hungerLevel += 20;
                Console.WriteLine("You have unleashed a monster into the world! Feeding it may calm it down.");
            }

        }


        public void TicksTaken()        //this adds one every time a menu option is selected.  Every 5 plays will result in 
        {                               //the gremlin perfoming some action on its own.
            this.ticks ++;
            if (this.ticks % 5 == 0)
            {
                Random ran = new Random();
                int anyNumber = ran.Next(0, 2);

                if (anyNumber == 0)
                {
                    this.aggression -= 15;
                    this.hungerLevel += 5;
                    this.hydrationLevel += 5;
                    this.happiness += 5;
                    Console.WriteLine(this.Name + " has taken a short nap but is now awake.");
                }
                else if (anyNumber == 1)
                {
                    this.aggression += 20;
                    this.hungerLevel += 20;
                    this.hydrationLevel -= 5;
                    this.happiness -= 20;
                    Console.WriteLine("Your gremlin has accidentally spilled water on itself!");
                }
                else
                {
                    this.aggression -= 5;
                    this.hungerLevel -= 15;
                    this.hydrationLevel += 3;
                    this.happiness += 6;
                    Console.WriteLine(this.Name + " has fed itself without you knowing.");
                }
            }
        }

        public void Monster()           //Gremlin turns into a monster at 80. Gremlin dies if aggression get to 100 or above and game ends.
        {                               //Unfortunately, the gremlin can also die of boredom if the score reaches 0 or less.
            if (this.aggression >= 80  && this.aggression < 100)    //this is determined by level of variable "aggression"
            {
                Console.WriteLine(this.name + " has gotten too aggressive and is now a monster! \nYou may need to feed it or leave it alone to get back to normal!");
            }
            else if (this.aggression >= 100)
            {
                Console.WriteLine("You have killed " + this.name + " due to being over aggressive. " + this.name + "'s\nlittle heart couldn\'t take it.");
                Console.WriteLine("Aggression level: " + this.aggression + ". TOO AGGRESSIVE!"); //writing these since they won't go to the menu.
                Console.WriteLine("Thirst level: " + this.hydrationLevel + ".");
                Console.WriteLine("Happiness level: " + this.happiness + ".");
                Console.WriteLine("Hunger level: " + this.hungerLevel + ".\n");
                Console.WriteLine("Total ticks were " + this.ticks + ".");  //let people know how many times they played
                Environment.Exit(0);
            }
            else if (this.aggression <= 20 && this.aggression > 0)
            {
                Console.WriteLine("You may want to play with " + this.name + " before this gremlin dies of boredom!");
            }
            else if(this.aggression <= 0)
            {
                Console.WriteLine(this.name + " ,unfortunately, has died of boredom.");
                Console.WriteLine("Aggression level: " + this.aggression + ". TOO BORED!");
                Console.WriteLine("Thirst level: " + this.hydrationLevel + ".");
                Console.WriteLine("Happiness level: " + this.happiness + ".");
                Console.WriteLine("Hunger level: " + this.hungerLevel + ".\n");
                Console.WriteLine("Total ticks were " + this.ticks + ".");
                Environment.Exit(0);
            }

        }

        public void Starving()  //this is determined by the level of variable "hungerLevel"
        {
            if (this.hungerLevel >= 80 && this.hungerLevel < 100)   //Gremlin can starve with a score of 100 or more
            {                                                       //Conversely, the gremlin can get too fat and be removed, ending the game.
                Console.WriteLine("Your gremlin is starving!  Please feed " + this.name + " immediately!");
            }
            else if (this.hungerLevel >=100)
            {
                Console.WriteLine("Since you never fed your gremlin, we had to take " + this.name + " into protective\ncustody and away from you. You\'ll never see " + this.name + " again!");
                Console.WriteLine("Aggression level: " + this.aggression + ".");
                Console.WriteLine("Thirst level: " + this.hydrationLevel + ".");
                Console.WriteLine("Happiness level: " + this.happiness + ".");
                Console.WriteLine("Hunger level: " + this.hungerLevel + ". TOO HUNGRY! \n");
                Console.WriteLine("Total ticks were " + this.ticks + ".");
                Environment.Exit(0);
            }
            else if (this.hungerLevel <= 20 && this.hungerLevel > 0)
            {
                Console.WriteLine("You may want to put your Gremlin on a diet, " + this.name + " has a poor BMI.");
            }
            else if (this.hungerLevel <= 0)
            {
                Console.WriteLine("We just sent " + this.name + " to fat camp and away from enablers such as you.");
                Console.WriteLine("Aggression level: " + this.aggression + ".");
                Console.WriteLine("Thirst level: " + this.hydrationLevel + ".");
                Console.WriteLine("Happiness level: " + this.happiness + ".");
                Console.WriteLine("Hunger level: " + this.hungerLevel + ". FED TOO MUCH! \n");
                Console.WriteLine("Total ticks were " + this.ticks + ".");
                Environment.Exit(0);
            }
        }

        public void PureJoy()   //this is determined by level of the variable "happiness"
        {
            if (this.happiness <= 20 && this.happiness > 0) //the gremlin happiness level can get too low and the gremlin can leave you.
            {                                               //however, the gremlin cannot get too happy.  The happier, the better.
                Console.WriteLine("Your gremlin is quite miserable.  Do you not spend quality time together?");
            }
            else if (this.happiness <= 0)
            {
                Console.WriteLine("Your gremlin left you for someone more fun.");
                Console.WriteLine("Aggression level: " + this.aggression + ".");
                Console.WriteLine("Thirst level: " + this.hydrationLevel + ".");
                Console.WriteLine("Happiness level: " + this.happiness + ". HAPPINESS TOO LOW!");
                Console.WriteLine("Hunger level: " + this.hungerLevel + ".\n");
                Console.WriteLine("Total ticks were " + this.ticks + ".");
                Environment.Exit(0);
            }
            else if (this.happiness >= 100)
            {
                Console.WriteLine("There is no limit to how happy a gremlin can be!!!");
            }
        }

        public void Dehydration()       //this is determined by level of variable "hydrationLevel"
        {                               //you can dehydrate your gremlin and end the game with a level of 0.
            if (this.hydrationLevel <= 20)   //however, since water effects aggression so much, you can't
            {                                                           //end the game in this method. Most likely it will end
                Console.WriteLine("Gremlins do not like too much water. It can make them aggressive."); //in the method "Monster".
            }
            else if (this.hydrationLevel >= 80 && this.hydrationLevel < 100)
            {
                Console.WriteLine("You don\'t want your gremlin to dehydrate! You better get it some water");
            }
            else if (this.hydrationLevel >= 100)
            {
                Console.WriteLine(this.Name + " has dehydrated and your game has ended.");
                Console.WriteLine("Aggression level: " + this.aggression + ".");
                Console.WriteLine("Thirst level: " + this.hydrationLevel + ". YOUR GREMLIN WAS THIRSTY!");
                Console.WriteLine("Happiness level: " + this.happiness + ".");
                Console.WriteLine("Hunger level: " + this.hungerLevel + ".\n");
                Console.WriteLine("Total ticks were " + this.ticks + ".");
                Environment.Exit(0);
            }

        }
    }
}
