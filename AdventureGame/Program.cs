using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel.Design;
using System.Data;
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
            Console.ReadKey();
            ClearConsole();
            introduction(playableCharacter);
            MoniaTown();
            Console.ResetColor();
            MoniaTownHub();
            Console.ReadKey();

        }
        static void drawUI (CharacterSheet player)
        {
            Console.WriteLine("----------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("HP "
                + player.CurHP.ToString()
                + "/"
                + player.MaxHP.ToString());

            Console.WriteLine("MP "
                + player.CurMP.ToString()
                + "/"
                + player.MaxMP.ToString());

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("LB =" + player.Lb);
            Console.WriteLine("Level = " + player.Level);
            Console.WriteLine(player.Name);
            Console.WriteLine(player.CurExp + "" + "/"+ player.ReqExp);

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

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Hey, you are finally awake. Do you remember your");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" name ");
            Console.ResetColor();
            Console.Write("?\n");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            String PCName = GetUserInput(); //Character's Name to be used in creating a CharacterSheet class
            if (String.IsNullOrEmpty(PCName))
            {
                Console.WriteLine("\nPlease enter your name\n\n");
                CharCreation();
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("I see, so you are THE ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(PCName);
            Console.ResetColor();
            Console.Write("?(y/n)\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            string Confirmation = Console.ReadLine().ToLower();
            if (Confirmation == "y" || Confirmation == "yes")
            {
                PCRace = CharCreationRace(PCName);
                PCClass = CharCreationClass();
                maxHP = 10;
                maxMP = 10;
                PCStr = 0;
                PCAgi = 0;
                PCIntel = 0;
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
                playableCharacter = new CharacterSheet(PCName, PCRace, PCClass, lb, PCStr, PCAgi, PCIntel, maxHP, maxMP, maxHP, maxMP);
            } else
            {
                CharCreation();
            }

            return playableCharacter;

        }
        static string CharCreationRace(string PCName)
        {
            string chosenRace= "";
            Console.ForegroundColor = ConsoleColor.Magenta;
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
            chosenRace = GetUserInput();
            Console.ForegroundColor = ConsoleColor.Green;
            switch (chosenRace)
            {
                case "1":
                    Console.WriteLine("Are you sure that's how you arrived here?");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenRace = "Human";
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Yeah, I didn't think so, you are in the middle of a freaking road");
                        CharCreationRace(PCName);
                    }
                    break;
                case "2":
                    Console.WriteLine("Are you sure that's how you arrived here?");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenRace = "Angel";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Yeah, that would be pretty ridiculous");
                        CharCreationRace(PCName);
                    }
                    break;
                case "3":
                    Console.WriteLine("Are you sure that's how you arrived here?");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenRace = "Demon";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Huh?");
                        CharCreationRace(PCName);
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please enter one of the above values");
                    CharCreationRace(PCName);
                    break;
            }
            return chosenRace;
        }
        static string CharCreationClass()
        {
            //TODO MAKE CLASSLESS CHARACTER CREATION    
            string chosenClass = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ok, we are almost ready I just want you to answer a last thing for me");
            Console.WriteLine("Have a look at these weapons and choose the one that suits you and please, be fast");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: Bow                                                                                        |");
            Console.WriteLine("2: Katana                                                                                     |");
            Console.WriteLine("3: Sword                                                                                      |");
            Console.WriteLine("4: Dagger                                                                                     |");
            Console.WriteLine("5: Book                                                                                       |");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("To select enter the number of the desired weapon");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            chosenClass = GetUserInput();
            Console.ResetColor();
            string Confirmation = "";
            Console.ForegroundColor = ConsoleColor.Green;
            switch (chosenClass)
            {
                case "1":
                    Console.WriteLine("You see a masterfully made bow from wood and a quiver with 20 iron arrows next to it");
                    Console.WriteLine("Are you sure you want to be an Archer?(y/n)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenClass = "Archer";
                        Skill SplitArrow = new Skill("SplitArrow", "Launch an arrow from your bow which splits on impact injuring a foe multiple times", "Agility");
                        playableCharacter.CharSkills.Add(SplitArrow);
                    } else
                    {
                        CharCreationClass();
                    }
                    break;
                case "2":
                    Console.WriteLine("You see a shining katana used by the samurai in ancient Japan");
                    Console.WriteLine("Are you sure you want to be a Samurai?(y/n)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenClass = "Samurai";
                        Skill Tsujigiri = new Skill("Tsujigiri", "You test the effictiveness of your weapon by attacking the first opponent in front of you", "Strength");
                        playableCharacter.CharSkills.Add(Tsujigiri);

                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                case "3":
                    Console.WriteLine("You see long silver sword with a beautiful handle");
                    Console.WriteLine("Are you sure you want to become a Paladin?(y/n)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenClass = "Paladin";
                        Skill HolyStrike = new Skill("Holy Strike", "You enchant your hammer with holy power after striking your enemy", "Strength");
                        playableCharacter.CharSkills.Add(HolyStrike);

                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                case "4":
                    Console.WriteLine("You see two daggers, short but long enough to perform a stealthy assassination");
                    Console.WriteLine("Are you sure you want to become an Assassin?(y/n)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenClass = "Assassin";
                        Skill SilentBlade = new Skill("Silent Blade", "You stab your enemy on the first spot you find available with incredible swiftness", "Agility");
                        playableCharacter.CharSkills.Add(SilentBlade);

                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                case "5":
                    Console.WriteLine("You see huge tome which emanates a deadly energy after a bit it starts emanating a warm friendly like energy");
                    Console.WriteLine("Are you sure you want to become a Magician?(y/n)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenClass = "Magician";
                        Skill LightningOrb = new Skill("Lightning Orb", "You strike your opponent with a swift bolt of lightning", "Intelligent");
                        playableCharacter.CharSkills.Add(LightningOrb);

                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
                default:
                    Console.WriteLine("You don't want any of the weapons? That's weird");
                    Console.WriteLine("Are you sure you want to become a Summoner?(y/n)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Confirmation = Console.ReadLine().ToLower();
                    if (Confirmation == "y" || Confirmation == "yes")
                    {
                        chosenClass = "Summoner";
                        Skill SummonImp = new Skill("Summon Imp", "You summon an imp to hit your enemy with a flame bolt", "Intelligence");
                        playableCharacter.CharSkill.Add(SummonImp);

                    }
                    else
                    {
                        CharCreationClass();
                    }
                    break;
            }
            return chosenClass;
        }

        static void introduction(CharacterSheet player)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Introduction are in order but I fear we are in imminent danger ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player.Name);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nLOOK BEHIND YOU!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLook behind?");
            Console.ForegroundColor = ConsoleColor.Blue;
            string tempUserInput = GetUserInput();
            if (tempUserInput == "yes" || tempUserInput == "y")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You turn back and see an enormous figure chasing after you");
                Console.Read();
                Console.WriteLine("The only thing you can make out is that it has big glowing red eyes");
                Console.Read();
                Console.WriteLine("Suddenly you see a white light closing in on the left side of the giant figure");
                Console.Read();
                Console.WriteLine("A very loud BANG penetrates your ears and makes you slightly dizzy");
                Console.Read();

                if (player.Agility >= 3)
                {
                    Console.WriteLine("However, your reflexes are enough to make you keep your balance and not fall over");
                } else
                {
                    Console.WriteLine("You stumble and start rolling away from the gigantic figure");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-2 HP");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The lady that is with you casts a spell so swiftly that she manages to break your fall");
                    Console.WriteLine("and you start hovering for slightly enough time to regain control over your body");
                    Console.Read();
                    Console.WriteLine("After a short time you manage to make your way in a town");
                }
            } else if (tempUserInput == "no" || tempUserInput == "n")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You are frightened enough by the sounds that are coming from whatever is behind you");
                Console.WriteLine("and decide not to look just in case you trip over and fall.");
                Console.Read();
                Console.WriteLine("While you are running you hear a loud bang, you thank God for not looking back since that bang would have probably made you lose control of your body");
                Console.Read();
                Console.WriteLine("After a short time you manage to make your way in a town");

            } else
            {
                Console.WriteLine("Please select one of the options");
                introduction(player);
            }

        }
        static void MoniaTown()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You must have a lot of questions, let me explain");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What are you going to do?");
            Console.ResetColor();
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: Who are you?                   |");
            Console.WriteLine("2: Where are you from?            |");
            Console.WriteLine("3: How did you find me?           |");
            Console.WriteLine("4: ...                            |");
            Console.ResetColor();
            Console.WriteLine("----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            string tempUserInput = GetUserInput();
            Console.ForegroundColor = ConsoleColor.Magenta;
            switch (tempUserInput)
            {
                case "1":
                    Console.WriteLine("My name is Kirki, I am a priest of the holy temple here in the town of Moria");
                    Console.WriteLine("I server under Nahzu and have devoted my life to Nahzu as his humble servant");
                    MoniaTown();
                    break;
                case "2":
                    MoniaTownExtendedDialogue();
                    break;
                case "3":
                    Console.WriteLine("I was gathering fruit for the village and I stumbled on you having passed out in the middle of the forest");
                    Console.WriteLine("You must be starving, I suggest we go to the tavern first and make you something to eat");
                    //TODO MOVE TO NEXT SCREEN
                    Console.Read();
                    break;
                case "4":
                    MoniaTownLonerDialogue();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please select one of the above options");
                    MoniaTown();
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;



        }
        static void MoniaTownExtendedDialogue()
        {
            Console.WriteLine("Born and raised here, in the beautiful town of Monia,");
            Console.WriteLine("hard to believe that a little town like this is still on the map with what's been happening to the rest of the world");
            Console.ResetColor();
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: I want to ask more questions|");
            Console.WriteLine("2: What has been happening?    |");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------");
            string MoniaQuestion = GetUserInput();
            switch (MoniaQuestion)
            {
                case "1":
                    MoniaTown();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("This is going to take a while, I think it's better if we went to make you something to eat, you must be starving");
                    MoniaTownHub();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please enter one of the possible options");
                    break;

            }
        }
        static void MoniaTownLonerDialogue()
        {
            Console.WriteLine("Not the talkative type I see..., well you must be starving, want any of the fruit I have gathered?");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: Yes                                             |");
            Console.WriteLine("2: No                                              |");
            Console.WriteLine("3: Sorry I'm not feeling well, excuse my rudeness  |");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            string LeaveMeAloneOption = GetUserInput();
            switch (LeaveMeAloneOption)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Here you go, there are more from where that came from as well");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You have received a handful of strawberries");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You must be tired I suggest we go to the local Inn to get you a room");
                    MoniaTownHub();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Oh Lord, I'm sorry in this case I will leave you alone, however if you need to find me for any reason");
                    Console.WriteLine("I will be inside the town's temple, I spend most of my time praying for the wellbeing of my fellow villagers");
                    break;
                case "3":
                    MoniaTown();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please enter one of the above choices");
                    break;
            }
        }

        static void MoniaTownHub()
        {
            Console.WriteLine("=============================|");
            Console.WriteLine("====WELCOME TO MONIA TOWN====|");
            Console.WriteLine("=============================|\n\n\n");

            Console.Write("==");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("1)Blacksmith");
            Console.ResetColor();
            Console.Write("====");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("2)Inn");
            Console.ResetColor();
            Console.Write("======|\n");
            Console.Write("|===");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("3)Store");
            Console.ResetColor();
            Console.Write("===");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("4)Church");
            Console.ResetColor();
            Console.Write("=======|\n");
            Console.Write("|================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0)Leave town");
            Console.ResetColor();
            Console.Write("|\n");
            string UserTemp = GetUserInput();
            switch(UserTemp)
            {
                case "1":

                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Having nothing you want to do in the town you decide to move on to explore the rest of the world!");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please select one of the above options");
                    Console.ResetColor();
                    break;

            }
        }
        public static bool IsOnlyLettersOrDigits(string s)
        {
            bool isValid = true;

            foreach( char c in s)
            {
                if (!Char.IsLetterOrDigit(c) || c == ' ')
                    isValid = false;
            }
            return isValid;
        }

        public static string GetUserInput()
        {
            string tempUserInput = Console.ReadLine().ToLower();
            if (IsOnlyLettersOrDigits(tempUserInput))
            {
                return tempUserInput;
            } else
            {
                return "";
            }
            
        }

        public static void ClearConsole()
        {
            Console.Clear();
            drawUI(playableCharacter);
        }
    }
}
