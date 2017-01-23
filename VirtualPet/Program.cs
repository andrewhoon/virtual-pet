using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Gremlin gremlin1 = new Gremlin();
            Console.WriteLine("Welcome to the Gremlin-Sitter game!");
            Console.WriteLine("Do you already have a saved game?"); //you will need to have played and quit on your own for this to load
            string existingOrNew = (Console.ReadLine());            //console will crash if you select "yes" and do not have a save.

            if (existingOrNew.ToUpper() == "YES" || existingOrNew.ToUpper() == "Y")
            {
                Console.WriteLine("Hit \"Enter\" to continue.");    //for some reason, to get my gamesave to work it needs
                StreamReader retrieveSave = new StreamReader("..\\..\\GameSave.txt");   //another input of "enter" to continue.
                int numberOfLines = 6;
                string[] lineArray = new string[numberOfLines]; //taking GameSave.txt and turning lines into an array to read them
                for (int i = 1; i < numberOfLines; i++)
                {
                    lineArray[i] = retrieveSave.ReadLine();
                }
                gremlin1.Name = (lineArray[1]);     //these are using the properties to change the variable amounts and string name
                gremlin1.Aggression = int.Parse(lineArray[2]);  //all lines read as a string, so Parse will get them into an int
                gremlin1.HydrationLevel = int.Parse(lineArray[3]);
                gremlin1.Happiness = int.Parse(lineArray[4]);
                gremlin1.HungerLevel = int.Parse(lineArray[5]);
                Console.ReadLine();
                retrieveSave.Close();
                Console.WriteLine("Welcome back " + gremlin1.Name + "!");
                goto menu;  //this sends it to the main menu
            }
            else
            {
                Console.WriteLine("Please enter the name you wish to give to your Gremlin.");
                gremlin1.Name = Console.ReadLine();
            }


           
            if (gremlin1.Name.ToUpper() == "GIZMO") //Gizmo is the name in the movies. If this is selected, they get a nice little message
            {
                Console.WriteLine("Everyone always picks Gizmo.  Oh well, Gizmo it is.");
            }

            else
            {
                Console.WriteLine(gremlin1.Name + " is a great name!");
            }



            menu:   //using this instead of a loop because the program seems small enough to find and
                                                                    //because i got my "gamesave" to work with it.
                Console.WriteLine("\n" + gremlin1.Name + " currently is at:");  //\n is to give a space to make console more readable
                Console.WriteLine("Aggression level: " + gremlin1.Aggression + ".");
                Console.WriteLine("Thirst level: " + gremlin1.HydrationLevel + ".");
                Console.WriteLine("Happiness level: " + gremlin1.Happiness + ".");
                Console.WriteLine("Hunger level: " + gremlin1.HungerLevel + ".\n");
                Console.WriteLine("Enter \"Feed\" or \"F\" to give " + gremlin1.Name + " some food.");
                Console.WriteLine("Enter \"Water\" or \"W\" to give " + gremlin1.Name + " some water.");
                Console.WriteLine("Enter \"Play\" or \"P\" to play with " + gremlin1.Name + ".");
                Console.WriteLine("Enter \"Dump\" or \"D\" to dump water onto " + gremlin1.Name + ".");
                Console.WriteLine("Enter \"Quit\" or \"Q\" to quit and save game.");
                Console.WriteLine("Enter any other letter or letters to do nothing.\n \n \n \n \n \n");  //I did a lot of \n's to really increase readability
                string response = Console.ReadLine();



            switch (response.ToUpper()) //this takes their entry and the switch case will select which method to call on.
            {
                case "W":
                    gremlin1.GetWater();
                    break;
                case "WATER":
                    gremlin1.GetWater();
                    break;
                case "F":
                    gremlin1.GetFood();
                    break;
                case "FOOD":
                    gremlin1.GetFood();
                    break;
                case "P":
                    gremlin1.PlayTime();
                    break;
                case "PLAY":
                    gremlin1.PlayTime();
                    break;
                case "D":
                    gremlin1.WaterDump();
                    break;
                case "DUMP":
                    gremlin1.WaterDump();
                    break;
                case "Q":
                    StreamWriter gameSave = new StreamWriter("..\\..\\GameSave.txt");  //this will write or overwrite the txt 
                    using (gameSave)                                                    //that will be used to read when console is
                    {                                                                   //reopened and saved game is selected.
                        gameSave.WriteLine(gremlin1.Name);
                        gameSave.WriteLine(gremlin1.Aggression);
                        gameSave.WriteLine(gremlin1.HydrationLevel);
                        gameSave.WriteLine(gremlin1.Happiness);
                        gameSave.WriteLine(gremlin1.HungerLevel);
                    }
                    Console.WriteLine("Total ticks were " + gremlin1.Ticks + ".");  //let people know how many times they entered a selection
                        Environment.Exit(0);
                    break;
                case "QUIT":
                    StreamWriter gameSave2 = new StreamWriter("..\\..\\GameSave.txt");
                    using (gameSave2)
                    {
                        gameSave2.WriteLine(gremlin1.Name);     //this does the same as case Q. Had to make a second StreamWriter
                        gameSave2.WriteLine(gremlin1.Aggression);   //but result is the same.
                        gameSave2.WriteLine(gremlin1.HydrationLevel);
                        gameSave2.WriteLine(gremlin1.Happiness);
                        gameSave2.WriteLine(gremlin1.HungerLevel);
                    }
                    Console.WriteLine("Total ticks were " + gremlin1.Ticks + ".");
                    Environment.Exit(0);
                    break;
                default:
                    gremlin1.DoNothing();   //if none of the menu options are selected, it will default to "do nothing"
                    break;

            }

            //these are the methods that are always called on after the menu selection and the changing of values in
            //gremlin1's parameters.  These determine if the paramaters are either too high or too low.
            gremlin1.TicksTaken();  //this method has to be run first in case it effects the numbers that are used in other methods
            gremlin1.Monster();
            gremlin1.Starving();
            gremlin1.PureJoy();
            gremlin1.Dehydration();

            goto menu;  //this brings us back to the main menu
            }

        

    }
}
