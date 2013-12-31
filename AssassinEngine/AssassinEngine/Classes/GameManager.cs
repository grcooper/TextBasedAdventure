using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    static class GameManager
    {

        // Public Methods 

        public static void ShowTitleScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(TextUtils.WordWrap("*********Welcome To Shut the Window*********\n\n***********Created with Assassin************\n\nYou are in your house at around 6:00. The skies were supposed to be clear all day, but you notice a large clap of thunder. Stupid Weatherman! But wait! There is a window open upstairs in your bedroom! You should probably go up to your room and close it before your carpet gets soaked and your comic book collection is ruined!\n\n", 
                Console.WindowWidth));
            Console.WriteLine("\nNote: You may type 'help' at any time to see a list of commands.");
            Console.WriteLine("\nPress a key to begin.");

            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();

        }

        public static void StartGame()
        {
            Player.GetCurrentRoom().Describe();
            TextBuffer.Display();
        }

        public static void EndGame(string endingText)
        {
            Program.quit = true;

            Console.Clear();

            Console.WriteLine(TextUtils.WordWrap(endingText, Console.WindowWidth));

            Console.WriteLine("\nYou may now close this window as well!.");
            Console.CursorVisible = false;

            while (true)
                Console.ReadKey(true);
        }

        public static void ApplyRules(Hero myhero)
        {
            
            Battle battle;
            List<Character> monsters;
            monsters = new List<Character>();
            BattleHelper.LevelUp(myhero);

            if (myhero.DustBunnyAlive == 0)
            {
                Monster.PickupItem("Key");
            }

            if (myhero.MoldAlive == 0)
            {
                Monster.CompleteObjective("My Window", myhero);
            }

            if (Player.GetObjective("DustBunny") != null && myhero.DustBunnyAlive == 0)
            {
                Console.Clear();
                monsters.Add(new Dustbunny());
                battle = new Battle(myhero, monsters);
                Player.DropObjective("DustBunny");
                myhero.DustBunnyAlive = 1;                
            }

            if (Player.GetObjective("Mold") != null && myhero.MoldAlive == 0)
            {
                Console.Clear();
                monsters.Add(new Mold());
                battle = new Battle(myhero, monsters);
                Player.DropObjective("Mold");
                myhero.MoldAlive = 1;
            }

            if (myhero.DustBunnyAlive == 1)
            {
                Level.Rooms[2, 0].Description = "You are in the kitchen.";
                Monster.DropItem("Key");                
            }

            if (myhero.MoldAlive == 1)
            {
                Level.Rooms[0, 2].Description = "You are in your room. Your super amazing comfy carpet is on the floor, your comic collection is neatly organized in its shelf. You my now close YOUR window!";
                Monster.DropObjective("My Window");
            }

            if (Player.GetInventoryItem("Snacks") != null)
            {
                while (myhero.CurrentHealth != myhero.MaxHealth)
                {  
                    myhero.CurrentHealth += 1;
                }
                Player.DropItem("Snacks");
            }

            if (Player.GetInventoryItem("Vacuum") != null)
            {
                Level.Rooms[0, 1].Description = "Your closet is filled with coats.";
                if (myhero.VacuumPickup == 0)
                {
                    myhero.Strength += 5;
                    myhero.VacuumPickup += 1;
                }
            }

            if (Player.GetInventoryItem("Vacuum") == null)
            {
                if (myhero.VacuumPickup == 1)
                {
                    myhero.Strength -= 5;
                    myhero.VacuumPickup -= 1;
                }
            }
            
            if (Player.GetObjective("TV") != null)
            {
                Level.Rooms[1, 0].Description = "You enter the living room. You feel a slight breeze. There is a door to the west and the east, to the east there appears to be a kitchen. To the south is some stairs leading upwards, to where you do not know.";
            }

            if (Player.GetObjective("Window") != null)
            {
                Level.Rooms[1, 0].Description = "You are in the living room. You see the TV has still been left on. There is a door to the west and the east, to the east there appears to be a kitchen. To the south is some stairs leading upwards, to where you do not know.";    
            }

            if (Player.GetObjective("Window") != null && Player.GetObjective("TV") != null)
            {
                Level.Rooms[1, 0].Description = "You are in the living room. There is a door to the west and the east, to the east there appears to be a kitchen. To the south is some stairs leading upwards, to where you do not know.";            
            }

            if (Player.GetObjective("Plant") != null)
            {
                Level.Rooms[0, 0].Description = "You are in the front foyer of your house. You can't remember which doors lead where. Too bad for you the map of your house you usually hang up here has been misplaced! There is a door to the east that seems to lead to another room. There also appears to be a closet to the south.";                
            }

            if (Player.GetInventoryItem("Key") != null)
            {
                Level.Rooms[1, 2].AddExit(Direction.West);//top of stairs
                Level.Rooms[1, 2].AddExit(Direction.East);
                Level.Rooms[1, 2].Description = "Top of the stairs.";
                Level.Rooms[0, 2].AddExit(Direction.East);//your room
                Level.Rooms[2, 2].AddExit(Direction.West);//kids room
            }

            if (myhero.CurrentHealth <= 0)
            {
                EndGame("Sorry you were defeated in combat. You lose the game.");
            }
            if (Player.Moves > 15)
            {
                EndGame("You took to long and the rain got to your house before you could shut the window. Congradulations. You need to buy a new carpet and your childhood treasures have been ruined.");
            }

            if (Player.GetInventoryItem("Blue Ball") != null)
            {
                EndGame("Sorry the blue ball you picked up was actually a crazy creature that bit your arm off and you pass out. Your carpet is soaked and childhood treasures are destroyed. Too bad. You also died.");
            }

            if (Player.GetObjective("My Window") != null && Player.GetObjective("Kids Window") == null && Player.GetObjective("Window") == null)
            {
                EndGame("Congrats you have defeated the vile mold and closed your window! Wasn't there a window in your kids room and living room as well?");
            }

            if (Player.GetObjective("My Window") != null && Player.GetObjective("Window") != null && Player.GetObjective("Kids window") == null)
            {
                EndGame("Congrats you have defeated the vile mold and closed your window! Wasn't there a window in your kids room as well?");
            }

            if (Player.GetObjective("My Window") != null && Player.GetObjective("Kids Window") != null && Player.GetObjective("Window") == null)
            {
                EndGame("Congrats you have defeated the vile mold and closed your window! Wasn't there a window in your living room as well?");
            }

            if (Player.GetObjective("My Window") != null && Player.GetObjective("Kids Window") != null && Player.GetObjective("Window") != null)
            {
                EndGame("Congrats you have defeated the vile mold and closed all of your windows!");
            }
        }
    }
}
