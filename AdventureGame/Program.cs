using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace AdventureGame
{
    class Program
    {
        public static CharacterSheet playableCharacter;

        static void Main(string[] args)
        {
            playableCharacter = CharCreation();
            Console.ForegroundColor = ConsoleColor.Blue;
            string showStats = playableCharacter.showDetails();
            Console.WriteLine(showStats);
            Console.Read();

            //drawUI(Cloud.MaxHP, Cloud.CurHP, Cloud.MaxMP, Cloud.CurMP, Cloud.Lb, Cloud.Name);
        }

        static void drawUI (int maxHP,int curHP,int maxMP,int curMP,string LB,string name)
        {
            Console.WriteLine("----------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("HP "
                + curHP.ToString()
                + "/"
                + maxHP.ToString()
                + "   |");

            Console.WriteLine("MP "
                + curMP.ToString()
                + "/"
                + maxMP.ToString()
                + "    |");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("LB =" + LB + " |");
            Console.WriteLine(name + "     |");
            Console.ResetColor();
            Console.WriteLine("----------");
        }
        static CharacterSheet CharCreation()
        {
            String PCRace;
            String PCClass;
            int maxHP = 10;
            int maxMP = 10;
            int PCStr = 0;
            int PCAgi = 0;
            int PCIntel = 0;
            Console.WriteLine("Welcome to the game");
            Console.Write("Made by ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Georgios Drakos\n\n");
            Console.ResetColor();

            Console.Write("Hey, you are finally awake. Do you remember your");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" name ");
            Console.ResetColor();
            Console.Write("?\n");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            String PCName = Console.ReadLine(); //Character's Name to be used in creating a CharacterSheet class
            Console.ResetColor();
            Console.Write("I see, so your name is ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(PCName);
            Console.ResetColor();
            Console.Write("?(y/n)\n");
            string Confirmation = Console.ReadLine().ToLower();
            if (Confirmation == "y")
            {
                PCRace = CharCreationRace(PCName);
                PCClass = CharCreationClass();
                maxHP = 10;
                maxMP = 10;
                PCStr = 0;
                PCAgi = 0;
                PCIntel = 0;
                /* public CharacterSheet(string name, string race, string pcClass, string lb, int strength, int agi, int intel, int maxHP, int maxMP, int level, int curHP, int curMP)*/
                switch (PCRace)
                {
                    case "Human":
                        PCStr += 2;
                        PCAgi += 2;
                        PCIntel += 2;
                        maxHP += 5;
                        maxMP += 5;
                        break;
                    case "Angel":
                        PCStr += 3;
                        PCAgi += 1;
                        PCIntel += 5;
                        maxHP += 2;
                        maxMP += 5;
                        break;
                    case "Demon":
                        PCStr += 5;
                        PCAgi += 3;
                        PCIntel += 1;
                        maxHP += 5;
                        maxMP += 2;
                        break;
                    default:
                        Console.WriteLine("You shouldn't be able to read this, if you do my game is busted!!!!");
                        break;
                }
                switch (PCClass)
                {
                    case "Archer":
                        PCStr += 2;
                        PCAgi += 5;
                        PCIntel += 3;
                        maxHP += 3;
                        maxMP += 3;
                        break;
                    case "Samurai":
                        PCStr += 5;
                        PCAgi += 4;
                        PCIntel += 1;
                        maxHP += 5;
                        maxMP += 2;
                        break;
                    case "Paladin":
                        PCStr += 5;
                        PCAgi += 1;
                        PCIntel += 4;
                        maxHP += 7;
                        maxMP += 4;
                        break;
                    case "Assassin":
                        PCStr += 3;
                        PCAgi += 5;
                        PCIntel += 2;
                        maxHP += 3;
                        maxMP += 3;
                        break;
                    case "Magician":
                        PCStr += 0;
                        PCAgi += 3;
                        PCIntel += 7;
                        maxHP += 1;
                        maxMP += 10;
                        break;
                    case "Monk":
                        PCStr += 6;
                        PCAgi += 3;
                        PCIntel += 1;
                        maxHP += 3;
                        maxMP += 5;
                        break;
                    default:
                        Console.WriteLine("You shouldn't be able to read this, if you do my game is busted!!!!");
                        break;
                }
                string lb = "------";
                playableCharacter = new CharacterSheet(PCName, PCRace, PCClass, lb, PCStr, PCAgi, PCIntel, maxHP, maxMP, maxHP, maxHP, maxMP);
            } else
            {
                CharCreation();
            }

            return playableCharacter;

        }
        static string CharCreationRace(string PCName)
        {
            string chosenRace= "";
            Console.Write("We don't always have visitors in this place, do you remember how you got here ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(PCName);
            Console.ResetColor();
            Console.Write(" ? \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("I remember...");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: being on a ship and crashing on the beach right there                                  |");
            Console.WriteLine("2: falling from a sky after a dispute with someone                                        |");
            Console.WriteLine("3: climbing a flight of stairs for days without seeing any light until I stumbled here    |");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("To select enter the number of the desired option");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            chosenRace = Console.ReadLine();
            Console.ResetColor();
            switch (chosenRace)
            {
                case "1":
                    Console.WriteLine("Are you sure that's how you arrived here?");
                    string Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y")
                    {
                        chosenRace = "Human";
                    } else
                    {
                        Console.WriteLine("Yeah, I didn't think so, you are in the middle of a freaking road");
                        CharCreationRace(PCName);
                    }
                    break;
                case "2":
                    Console.WriteLine("Are you sure that's how you arrived here?");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenRace = "Angel";
                    }
                    else
                    {
                        Console.WriteLine("Yeah, that would be pretty ridiculous");
                        CharCreationRace(PCName);
                    }
                    break;
                case "3":
                    Console.WriteLine("Are you sure that's how you arrived here?");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenRace = "Demon";
                    }
                    else
                    {
                        Console.WriteLine("Huh? where do you live??");
                        CharCreationRace(PCName);
                    }
                    break;
                default:
                    Console.WriteLine("Please enter one of the above values we don't have time to waste, they are coming!!!");
                    CharCreationRace(PCName);
                    break;
            }
            return chosenRace;
        }
        static string CharCreationClass()
        {
            string chosenClass = "";
            Console.WriteLine("Ok, we are almost ready I just want you to answer a last thing for me");
            Console.WriteLine("Have a look at these weapons and choose the one that suits you and please, be fast");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: Bow                                                                                          |");
            Console.WriteLine("2: Katana                                                                                       |");
            Console.WriteLine("3: Sword                                                                                        |");
            Console.WriteLine("4: Dagger                                                                                       |");
            Console.WriteLine("5: Book                                                                                         |");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("To select enter the number of the desired weapon");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            chosenClass = Console.ReadLine();
            Console.ResetColor();
            string Confirmation = "";
            switch (chosenClass)
            {
                case "1":
                    Console.WriteLine("You see a masterfully made bow from wood and a quiver with 20 iron arrows next to it");
                    Console.WriteLine("Are you sure you want to be an Archer?(y/n)");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenClass = "Archer";
                    } else
                    {
                        CharCreationClass();
                    }
                    break;
                case "2":
                    Console.WriteLine("You see a shining katana used by the samurais is ancient Japan");
                    Console.WriteLine("Are you sure you want to be a Samurai?(y/n)");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenClass = "Samurai";
                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                case "3":
                    Console.WriteLine("You see long silver sword with a beautiful handle");
                    Console.WriteLine("Are you sure you want to become a Paladin?(y/n)");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenClass = "Paladin";
                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                case "4":
                    Console.WriteLine("You see two daggers, short but long enough to perform a stealthy assassination");
                    Console.WriteLine("Are you sure you want to become an Assassin?(y/n)");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenClass = "Assassin";
                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                case "5":
                    Console.WriteLine("You see huge tome which emanates a deadly energy after a bit it starts emanating a warm friendly like energy");
                    Console.WriteLine("Are you sure you want to become a Magician?(y/n)");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenClass = "Magician";
                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                default:
                    Console.WriteLine("You don't want any of the weapons? That's weird");
                    Console.WriteLine("Are you sure you want to become a Monk?(y/n)");
                    Confirmation = Console.ReadLine();
                    if (Confirmation == "y")
                    {
                        chosenClass = "Monk";
                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
            }
            return chosenClass;
        }
    }
}
