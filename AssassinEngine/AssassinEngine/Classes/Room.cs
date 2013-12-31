using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Room
    {
        private string title;
        private string description;

        private List<string> exits;
        private List<Item> items;
        private List<Objective> objectives;
        private List<Character> monster;

        #region properties
        //gives rooms properties
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        public List<Objective> Objectives
        {
            get { return objectives; }
            set { objectives = value; }
        }
        public List<Character> Monster
        {
            get { return monster; }
            set { monster = value; }
        }


        #endregion

        public Room()
        {
            exits = new List<string>();
            items = new List<Item>();
            objectives = new List<Objective>();
            monster = new List<Character>();
        }

        #region public methods

        //adds the description/title to the text buffer and displays
        public void Describe()
        {
            //TextBuffer.Add(this.GetCoordinates());
            TextBuffer.Add(this.description);
            TextBuffer.Add(this.GetItemList());
            TextBuffer.Add(this.GetExitList());

        }

        public void ShowTitle()
        {
            TextBuffer.Add(this.title);
        }

        public Item GetItem(string itemName)
        {
            //does the loop for each item in the items list, converts it to lower and returns the item to be seen 
            foreach (Item item in this.items)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                    return item;
            }
            //will return nothing if there is not item of the name
            return null;
        }
        public Objective GetObjective(string objectiveName)
        {
            //does the loop for each item in the items list, converts it to lower and returns the item to be seen 
            foreach (Objective objective in this.Objectives)
            {
                if (objective.Title.ToLower() == objectiveName.ToLower())
                    return objective;
            }
            //will return nothing if there is not objective of the name
            return null;
        }

        public void AddExit(string direction)
        {
            //checks to see which directions are available
            if (this.exits.IndexOf(direction) == -1)
                this.exits.Add(direction);
        }

        public void RemoveExit(string direction)
        {
            //gets rid of exits that are not available
            if (this.exits.IndexOf(direction) != -1)
                this.exits.Remove(direction);
        }

        public bool CanExit(string direction)
        {
            //tells us if the exit is valid
            foreach (string ValidExit in this.exits)
            {
                if (direction == ValidExit)
                    return true;
            }
            return false;
        }

        public void AddItem(string item)
        {
            //checks to see the other items arent the same are available
            if (this.exits.IndexOf(item) == -1)
                this.exits.Add(item);
        }

        public void RemoveItem(string item)
        {
            //gets rid of exits that are not available
            if (this.exits.IndexOf(item) != -1)
                this.exits.Remove(item);
        }

        #endregion

        
        #region private methods


        private string GetItemList()
        {
            
            string itemString = "";
            string message = "Items in Room:";
            string underline = "";
            //underlines items in room the number of characters it is.
            underline = underline.PadLeft(message.Length, '-');

            if (this.items.Count > 0)
            {
                // checks each item if there are items in the room. Displays the items in the room.
                foreach (Item item in this.items)
                {
                    itemString += "\n[" + item.Title + "]";
                }
            }
            else
                //iff there are no items
            {
                itemString = "\n<none>";
            }

            //give the text buffer all of this 
            return "\n" + message + "\n" + underline + itemString;

        }

        //read above, but for exits
        private string GetExitList()
        {
            string exitString = "";
            string message = "Possible directions:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.exits.Count > 0)
            {
                foreach (string exitDirection in this.exits)
                {
                    exitString += "\n[" + exitDirection + "]";
                }
            }
            else
            {
                exitString = "\n<none>";
            }

            return "\n" + message + "\n" + underline + exitString;
        }

        //checks if you can get the y = 0 coordinates and then checks all of the x values in that row.
        //once there is no more x values (collumns) in the row then it  checks the next row (y value) and checks all of those x values
        private string GetCoordinates()
        {
            for (int y = 0; y < Level.Rooms.GetLength(1); y++)
            {
                for (int x = 0; x < Level.Rooms.GetLength(0); x++)
                {
                    if (this == Level.Rooms[x, y])
                        return "[" + x.ToString() + "," + y.ToString() + "]";

                }
            }
            return "This room is not within the Rooms grid.";
        }


        #endregion

    }
}
