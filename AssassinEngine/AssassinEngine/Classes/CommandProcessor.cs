using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    static class CommandProcessor
    {

        //this will proccess all of the commands
        public static void ProcessCommand(string line, Hero myhero)
        {
            DataHandler dh = new DataHandler();

            //this checks the command, and takes the command and converts it to lowercase
            string command = TextUtils.ExtractCommand(line.Trim()).Trim().ToLower();
            //this takes the argument, and takes the command and converts it to lowercase
            string arguments = TextUtils.ExtractArguments(line.Trim()).Trim().ToLower();

            //this is the switch, if statment, that tells the program what to do when a certain word is entered.
            if (Direction.IsValidDirection(command))
            {
                Player.Move(command); 
            }
            else
            {
                switch (command)
                {
                    case "exit":
                        Program.quit = true;
                        return;
                    case "help":
                        ShowHelp();
                        break;
                    case "move":
                        Player.Move(arguments);
                        if (myhero.CurrentMagic <= myhero.MaxMagic)
                        {
                        myhero.CurrentMagic += 1;
                        }
                        break;
                    case "look":
                        Player.GetCurrentRoom().Describe();
                        break; 
                    case "pickup":
                        Player.PickupItem(arguments);
                        break;
                    case "drop":
                        Player.DropItem(arguments);
                        break;
                    case "use":
                        Player.CompleteObjective(arguments, myhero);
                        break;
                    case "inventory":
                        Player.DisplayInventory();
                        break;
                    case "whereami":
                        Player.GetCurrentRoom().ShowTitle();
                        break;
                    default:
                        TextBuffer.Add("Input not understood.");
                        break;
                }
            }
            //this makes sure that the game rules are applied and that display what is in the text buffer
            GameManager.ApplyRules(myhero);
            TextBuffer.Display();

        }

        //the show help command with all of the available commands.
        public static void ShowHelp()
        {
            TextBuffer.Add("Available Commands:");
            TextBuffer.Add("--------------------");
            TextBuffer.Add("help");
            TextBuffer.Add("exit");
            TextBuffer.Add("move (north, south, east, west)");
            TextBuffer.Add("look");
            TextBuffer.Add("pickup");
            TextBuffer.Add("drop");
            TextBuffer.Add("use");
            TextBuffer.Add("inventory");
            TextBuffer.Add("whereami");
        }
    }
}
