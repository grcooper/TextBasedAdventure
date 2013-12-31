using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    static class Monster
    {

        private static List<Item> inventoryItems;
        private static List<Objective> inventoryObjectives;

        #region Public Methods

        static Monster()
        {
            inventoryItems = new List<Item>();
            inventoryObjectives = new List<Objective>();
        }

        public static void PickupItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = room.GetItem(itemName);

            if (item != null)
            {
                room.Items.Remove(item);
                Monster.inventoryItems.Add(item);
            }
           
        }

        public static void CompleteObjective(string objectiveName, Hero myhero)
        {
            Room room = Player.GetCurrentRoom();
            Objective objective = room.GetObjective(objectiveName);

            if (objective != null)
            {
                room.Objectives.Remove(objective);
                Monster.inventoryObjectives.Add(objective);
            }
        }

        public static void DropItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = GetInventoryItem(itemName);

            if (item !=null)
            {
                Monster.inventoryItems.Remove(item);
                room.Items.Add(item);
            }
        }

        public static void DropObjective(string objectiveName)
        {
            Room room = Player.GetCurrentRoom();
            Objective objective = GetObjective(objectiveName);

            if (objective != null)
            {
                Monster.inventoryObjectives.Remove(objective);
                room.Objectives.Add(objective);
            }

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
