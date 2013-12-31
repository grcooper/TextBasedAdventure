using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    static class Level
    {
        private static Room[,] rooms;

        #region properties

        public static Room[,] Rooms
        {
            get { return rooms; }
        }

        #endregion

        public static void Initialize(Hero myhero, List<Character> Monster)
        {
            BuildLevel(myhero, Monster);
        }

        private static void BuildLevel(Hero myhero, List<Character> Monster)
        {
           

            rooms = new Room[10, 10];

            Room room;
            Item item;
            Objective objective;
            

            //Place the player in the starting room
            Player.PosX = 0;
            Player.PosY = 0;

            //////////////////////// 0,0 ////////////////////////////

            room = new Room();

            rooms[0, 0] = room;

            room.Title = "Front Foyer";
            room.Description = "You are in the front foyer of your house. You can't remember which doors lead where. Too bad for you the map of your house you usually hang up here has been misplaced! Your dog has knocked over the plant in the corner as well. Bummer. There is a door to the east that seems to lead to another room. There also appears to be a closet to the south.";
            room.AddExit(Direction.East);
            room.AddExit(Direction.South);

            objective = new Objective();

            objective.Title = "Plant";
            objective.CompletionText = "You clean up the plant. Stupid Dog.";

            room.Objectives.Add(objective);

            

            //////////////////////// 1,0 ////////////////////////////

            room = new Room();

            rooms[1, 0] = room;

            room.Title = "Living Room";
            room.Description = "You are in the living room. You feel a slight breeze from the open window, but you are distracted by the golf on tv to pay any attention to it. There is a door to the west and the east, to the east there appears to be a kitchen. To the south is some stairs leading upwards, to where you do not know.";
            room.AddExit(Direction.East);
            room.AddExit(Direction.South);
            room.AddExit(Direction.West);

            objective = new Objective();

            objective.Title = "TV";
            objective.CompletionText = "You have turned off the TV";
            room.Objectives.Add(objective);

            objective = new Objective();

            objective.Title = "Window";
            objective.CompletionText = "You have closed the window.";
           

            room.Objectives.Add(objective);


            //////////////////////// 2,0 ////////////////////////////

            room = new Room();

            rooms[2, 0] = room;

            room.Title = "Kitchen";
            room.Description = "You are in the kitchen. What appears to be an evil Dustbunny lurks in the corner, nibbling on food scraps. It appears to be guarding a shiny object, maybe a key. To the south there is a door that appears to be another closet.";
            room.AddExit(Direction.West);
            room.AddExit(Direction.South);

            item = new Item();

            item.Title = "Key";
            item.PickupText = "You collect a key that you think you have seen before.";

            room.Items.Add(item);

            objective = new Objective();

            objective.Title = "DustBunny";
            objective.CompletionText = "You defeated the dustbunnies!";

            room.Objectives.Add(objective);

            room.Monster.Add(new Dustbunny());

           

            //////////////////////// 0,1 ////////////////////////////

            room = new Room();

            rooms[0, 1] = room;

            room.Title = "Closet";
            room.Description = "Your closet is filled with coats and you see a vacuum in the corner.";
            room.AddExit(Direction.North);

            item = new Item();

            item.Title = "Vacuum";
            item.PickupText = "You are now carrying around your vacuum. Aren't you cool. The vacuum gives you +5 strength.";
            item.Weight = 3;

            room.Items.Add(item);

            //////////////////////// 1,1 ////////////////////////////

            room = new Room();

            rooms[1, 1] = room;

            room.Title = "Stairs";
            room.Description = "You begin to venture up the stairs. OH NO you fell into a fiery pit of death, just kidding. You may continue up the stairs to the south, or return to the living room to the north.";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            //////////////////////// 2,1 ////////////////////////////
            room = new Room();

            rooms[2, 1] = room;

            room.Title = "Pantry";
            room.Description = "You are standing in the Pantry, good times. Old food scraps lay around, you really should clean up.";
            room.AddExit(Direction.North);

            item = new Item();

            item.Title = "Snacks";
            item.PickupText = "You eat the snacks and feel replenished!";

            room.Items.Add(item);
            //////////////////////// 0,2 ////////////////////////////

            room = new Room();

            rooms[0, 2] = room;

            room.Title = "Your Room";
            room.Description = "You are in your room. Your super amazing comfy carpet is on the floor, your comic collection is neatly organized in its shelf. But wait, an evil Mold is guarding your window, how can you close it and save your stuff with it there?! YOU MUST DESTROY IT!!!";
            room.AddExit(Direction.East);

            objective = new Objective();

            objective.Title = "My Window";
            objective.CompletionText = "You have closed your window. Yippy.";

            room.Objectives.Add(objective);

            room.Monster.Add(new Mold());

            objective = new Objective();

            objective.Title = "Mold";
            objective.CompletionText = "You defeated the evil mold, well aren't you just snazzy.";

            room.Objectives.Add(objective);

            
            //////////////////////// 1,2 ////////////////////////////
            room = new Room();

            rooms[1, 2] = room;

            room.Title = "Top of stairs";
            room.Description = "You can see down the stairs from here into the living room. There is a locked room to the west and to the east.";
            room.AddExit(Direction.North);
            
            
            //////////////////////// 2,2 ////////////////////////////
            room = new Room();

            rooms[2, 2] = room;

            room.Title = "Kids Room";
            room.Description = "You are in your kids room, wait you have kids? There is the kids window here, and a menacing looking blue ball.";
            

            item = new Item();

            item.Title = "Blue Ball";
            item.PickupText = "You pick up the ball and notice something strange.";
            item.Weight = 2;

            room.Items.Add(item);

            objective = new Objective();

            objective.Title = "Kids Window";
            objective.CompletionText = "You have closed your kids window.";

            room.Objectives.Add(objective);

        }
    }
}
