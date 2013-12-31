using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    static class Player
    {
        
        private static int posX;
        private static int posY;

        private static List<Item> inventoryItems;
        private static List<Objective> inventoryObjectives;
        private static int moves = 0;
        private static int weightCapacity = 3;

        #region properties
        //gives the player and x and y position
        public static int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public static int PosY
        {
            get { return posX; }
            set { posX = value; }
        }
        //counts the number of moves
        public static int Moves
        {
            get { return moves; }
            set { moves = value; }
        }
        //the total weight the character can carry
        public static int WeightCapacity
        {
            get { return weightCapacity; }
            set { weightCapacity = value; }
        }
        //how much the inventory weighs
        public static int InventoryWeight
        {
            get
            {
                int result = 0;
                foreach (Item item in inventoryItems)
                {
                    result += item.Weight;
                }
                return result;
            }
        }

        #endregion

        static Player()
        {
            inventoryItems = new List<Item>();
            inventoryObjectives = new List<Objective>();
        }

        #region Public Methods

        public static void Move(string direction)
        {
            Room room = Player.GetCurrentRoom();

            if (!room.CanExit(direction))
            {
                TextBuffer.Add("Invalid Direction");
                return;
            }
            //adds one to the move value
            Player.moves++;

            switch (direction)
            {
                    // this moves the player along the grid depending on which direction they move
                case Direction.North: //same thing as typing "north"
                    posY--;
                    break;
                case Direction.South:
                    posY++;
                    break;
                case Direction.East:
                    posX++;
                    break;
                case Direction.West:
                    posX--;
                    break;
            }
            //describes the room when you enter it
            Player.GetCurrentRoom().Describe();

        }

        public static void PickupItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = room.GetItem(itemName);

            if (item != null)
            {
                if (Player.InventoryWeight + item.Weight > Player.WeightCapacity)
                {
                    TextBuffer.Add("You must first drop some weight before you can pickup that item.");
                    return;
                }

                room.Items.Remove(item);
                Player.inventoryItems.Add(item);
                TextBuffer.Add(item.PickupText);
            }
            else
                TextBuffer.Add("There is no " + itemName + " in this room.");
        }

        public static void CompleteObjective(string objectiveName, Hero myhero)
        {
            Room room = Player.GetCurrentRoom();
            Objective objective = room.GetObjective(objectiveName);

            if (objective != null)
            {
                room.Objectives.Remove(objective);
                Player.inventoryObjectives.Add(objective);
                TextBuffer.Add(objective.CompletionText);
                myhero.Experience += 25;
                TextBuffer.Add("You have completed an objective and gained experience.");
            }
            else
                TextBuffer.Add("There is no " + objectiveName + " in this room.");
        }

        public static void DropItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = GetInventoryItem(itemName);

            if (item !=null)
            {
                Player.inventoryItems.Remove(item);
                room.Items.Add(item);
                TextBuffer.Add("The " + itemName + " has been dropped into this room.");
            }
            else
                TextBuffer.Add("There is no " + itemName + " in your inventory.");

        }

        public static void DropObjective(string objectiveName)
        {
            Room room = Player.GetCurrentRoom();
            Objective objective = GetObjective(objectiveName);

            if (objective != null)
            {
                Player.inventoryObjectives.Remove(objective);
                room.Objectives.Add(objective);
            }
            else
                TextBuffer.Add("There is no " + objectiveName + " in your inventory.");

        }

        public static void DisplayInventory()
        {
            string message = "Your inventroy contains:";
            string items = "";
            string underline = "";

            underline = underline.PadLeft(message.Length, '-');

            if (inventoryItems.Count > 0)
            {
                foreach (Item item in inventoryItems)
                {
                    items += "\n[" + item.Title + "] Wt: " + item.Weight.ToString();
                }
            }
            else
                items = "\n<no items>";

            items += "\n\nTotal Wt: " + Player.InventoryWeight + "/ " + Player.WeightCapacity;

            TextBuffer.Add(message + "\n" + underline + items);
        }

        public static Room GetCurrentRoom()
        {
            return Level.Rooms[posX, posY];
        }

        public static Item GetInventoryItem(string itemName)
        {
            foreach (Item item in inventoryItems)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                    return item;
            }
            return null;
        }

        public static Objective GetObjective(string objectiveName)
        {
            foreach (Objective objective in inventoryObjectives)
            {
                if (objective.Title.ToLower() == objectiveName.ToLower())
                    return objective;
            }
            return null;
        }

        #endregion Public Methods
    }
}
