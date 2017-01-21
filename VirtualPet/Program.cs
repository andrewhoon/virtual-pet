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
            Console.WriteLine("Welcome to the Gremlim-Sitter game!");
            Console.WriteLine("Do you already have a saved game?");
            string existingOrNew = (Console.ReadLine());
            if (existingOrNew.ToUpper() == "YES")
            {
                Console.WriteLine("Hit \"Enter\" to continue.");
                StreamReader retrieveSave = new StreamReader("..\\..\\GameSave.txt");
                int numberOfLines = 6;
                string[] lineArray = new string[numberOfLines];
                for (int i = 1; i < numberOfLines; i++)
                {
                    lineArray[i] = retrieveSave.ReadLine();
                }
                gremlin1.Name = (lineArray[1]);
                gremlin1.Aggression = int.Parse(lineArray[2]);
                gremlin1.HydrationLevel = int.Parse(lineArray[3]);
                gremlin1.Happiness = int.Parse(lineArray[4]);
                gremlin1.HungerLevel = int.Parse(lineArray[5]);
                Console.ReadLine();
                retrieveSave.Close();
                Console.WriteLine("Welcome back " + gremlin1.Name + "!");
                goto menu;
            }
            else
            {
                Console.WriteLine("Please enter the name you wish to give to your Gremlin.");
                gremlin1.Name = Console.ReadLine();
            }

           
            if (gremlin1.Name.ToUpper() == "GIZMO")
            {
                Console.WriteLine("Everyone always picks Gizmo.  Oh well, Gizmo it is.");
            }

            else
            {
                Console.WriteLine(gremlin1.Name + " is a great name!");
            }


            menu:
            
                Console.WriteLine("\n" + gremlin1.Name + " currently is at:");  //\n is to give a space to make console more readable
                Console.WriteLine("Aggression level: " + gremlin1.Aggression + ".");
                Console.WriteLine("Thirst level: " + gremlin1.HydrationLevel + ".");
                Console.WriteLine("Happiness level: " + gremlin1.Happiness + ".");
                Console.WriteLine("Hunger level: " + gremlin1.HungerLevel + ".\n");
                Console.WriteLine("Enter \"Feed\" or \"F\" to give " + gremlin1.Name + " some food.");
                Console.WriteLine("Enter \"Water\" or \"W\" to give " + gremlin1.Name + " some water.");
                Console.WriteLine("Enter \"Play\" or \"P\" to play with " + gremlin1.Name + ".");
                Console.WriteLine("Enter \"Quit\" or \"Q\" to quit.");
                Console.WriteLine("Enter any other letter or letters to do nothing.\n \n \n \n \n \n");  //I did a lot of \n's to really increase readability
                string response = Console.ReadLine();



            switch (response.ToUpper())
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
                case "Q":
                    StreamWriter gameSave = new StreamWriter("..\\..\\GameSave.txt");
                    using (gameSave)
                    {
                        gameSave.WriteLine(gremlin1.Name);
                        gameSave.WriteLine(gremlin1.Aggression);
                        gameSave.WriteLine(gremlin1.HydrationLevel);
                        gameSave.WriteLine(gremlin1.Happiness);
                        gameSave.WriteLine(gremlin1.HungerLevel);
                    }
                        Environment.Exit(0);
                    break;
                case "QUIT":
                    StreamWriter gameSave2 = new StreamWriter("..\\..\\GameSave.txt");
                    using (gameSave2)
                    {
                        gameSave2.WriteLine(gremlin1.Name);
                        gameSave2.WriteLine(gremlin1.Aggression);
                        gameSave2.WriteLine(gremlin1.HydrationLevel);
                        gameSave2.WriteLine(gremlin1.Happiness);
                        gameSave2.WriteLine(gremlin1.HungerLevel);
                    }
                    Environment.Exit(0);
                    break;
                default:
                    gremlin1.DoNothing();
                    break;

            }
            gremlin1.Monster();
            gremlin1.Starving();
            gremlin1.PureJoy();

            goto menu;
           
               






            }

        

    }
}
