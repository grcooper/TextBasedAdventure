using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    /// <summary>
    /// A collection of static methods used in our battle loop
    /// </summary>
    class BattleHelper
    {
        static int damage;
        static Random rand;

        #region CheckHealth
        /// <summary>
        /// This method should be called for each character to determine if they are alive
        /// A dead character should not be allowed to do any actions       
        /// </summary>
        /// <param name="health"> the characters current health int</param>
        /// <returns>Returns if the character is alive</returns>
        public static bool CheckHealth(int health)
        {
            bool alive;
            if (health > 0)
            {
                alive = true;
            }
            else
            {
                alive = false;

            }
            return alive;
        }
        #endregion

        #region DealDamage
        /// <summary>
        /// This method calculates the damage based on the attackers attack power
        /// vs the defenders defence stat
        /// </summary>
        /// <param name="attacker">The attacking character</param>
        /// <param name="defender">The defending character</param>
        /// <returns></returns>
        public static int DealDamage(Character attacker, Character defender)
        {
            int max;
            int min;
            rand = new Random();
            max = attacker.AttackDamage - defender.Defense;
            if (max <= 0)
            {
                max = 1;
            }
            min = (int)(attacker.AttackDamage * .8) - defender.Defense;
            if (min <= 0)
            {
                min = 1;
            }
            damage = rand.Next(min, max);
            if (attacker.increaseAttack == true)
            {
                damage = (int)(damage * 1.5);
            }
            if (defender.defending == true)
            {
                damage = damage / 2;
            }
            return damage;
        }
        #endregion

        #region ProcessChoice
        /// <summary>
        /// This method is used to take the choice and determine the right action for it
        /// </summary>
        /// <param name="choice"> the attackers choice</param>
        /// <param name="attacker">The active character</param>
        /// <param name="defender">The target character the attacker is attacking</param>
        public static void ProcessChoice(string choice, Character attacker, Character defender, string spellchoice)
        {
            switch (choice)
            {
                case "A":
                case "a":
                    Console.WriteLine();
                    Console.WriteLine("{0} attacks!", attacker.Identifier);
                    DealDamage(attacker, defender);
                    defender.CurrentHealth -= damage;
                    Console.WriteLine("{0} hits {1} for {2}hp of damage"
                        , attacker.Identifier, defender.Identifier, damage);
                    break;
                case "D":
                case "d":
                    Console.WriteLine();
                    Console.WriteLine("{0} defends!", attacker.Identifier);
                    break;
                //case "F":
                //case "f":
                //    Console.WriteLine();
                //    Console.WriteLine("{0} flees!", attacker.Identifier);
                //    attacker.fled = true;
                //    attacker.isAlive = false;
                //    break;
                case "S":
                case "s":
                    Console.WriteLine();
                    CastSpell(attacker, defender, spellchoice);
                    break;
                default:
                    Console.WriteLine("I'm sorry, I didn't recognize that.");
                    Console.WriteLine();
                    choice = PrintChoice();
                    Console.WriteLine();
                    ProcessChoice(choice, attacker, defender, spellchoice);
                    break;
            }
        }
        #endregion

        #region PrintStatus
        /// <summary>
        /// This method is used to print the status of both characters
        /// </summary>
        /// <param name="hero">Our hero character</param>
        /// <param name="monster">the monster character</param>
        public static void PrintStatus(Character hero)
        {
            Console.Write(@"    HP/MaxHP   MP/MaxMP 
{0}:   {1}/{2}hp    {3}/{4}mp
********************************
", hero.Identifier, hero.CurrentHealth, hero.MaxHealth,
 hero.CurrentMagic, hero.MaxMagic);
        }
        #endregion

        #region PrintChoice
        /// <summary>
        /// This method prints our choices and gets the choice.
        /// </summary>
        /// <returns>returns the string of the hero's choice</returns>
        public static string PrintChoice()
        {
            string choice;
            Console.WriteLine();
            Console.Write(@"
_____________________
Please choose an action:
(A)ttack:
(D)efend:
(S)pell:
_____________________");
            Console.WriteLine();
            choice = Console.ReadLine();
            return choice;
        }
        #endregion

        #region CheckDefence
        /// <summary>
        /// This method should be called for each active character.  This sets
        /// the bools defending and increase attack for the character.
        /// This method should be called prior to any processchoice.
        /// </summary>
        /// <param name="choice">input the string choice to check for defence</param>
        /// <param name="attacker">input the active character we are checking</param>
        public static void CheckDefence(string choice, Character attacker)
        {
            if (choice == "D" || choice == "d")
            {
                attacker.defending = true;
            }
            else
            {
                attacker.defending = false;
            }
            if (attacker.defending == true)
            {
                attacker.increaseAttack = true;
            }

            else
            {
                attacker.increaseAttack = false;
            }

        }
        #endregion

        #region CastSpell
        /// <summary>
        /// Here we going to "cast" the spell
        /// </summary>
        /// <param name="attacker">The attacker</param>
        /// <param name="defender">The defender</param>
        /// <param name="spell">The spell they've chosen to cast</param>
        public static void CastSpell(Character attacker, Character defender, string spellchoice)
        {
            Spell spell;
            spell = ProcessSpellChoice(spellchoice, attacker);
            int spellpower = spell.SpellCast(attacker);
            if (spell.isOnSelf == true)
            {
                attacker.CurrentHealth += spellpower;
                if (attacker.CurrentHealth > attacker.MaxHealth)
                {
                    attacker.CurrentHealth = attacker.MaxHealth;
                }
            }
            else if (spell.multipleHits == true)
            {
                defender.CurrentHealth -= spellpower;
                //To Do: make it hit multiple enemies
            }
            else if (spell.singleTarget == true)
            {
                defender.CurrentHealth -= spellpower;
            }
        }
        #endregion

        #region PrintSpells
        /// <summary>
        /// A method to print out the spells to choose from
        /// </summary>
        /// <returns>A string of the spell choice</returns>
        public static string PrintSpells()
        {
            Console.WriteLine();
            string spellchoice;
            Console.Write(@"
Please choose a spell:
***********************
(H)eal
(F)ireball
(I)cebolt
***********************");
            Console.WriteLine();
            spellchoice = Console.ReadLine();
            return spellchoice;
        }
        #endregion

        #region ProcessSpellChoice
        /// <summary>
        /// A method to determine which spell should be cast
        /// </summary>
        /// <param name="spellchoice">The spellchoice</param>
        /// <param name="attacker">the attacker</param>
        /// <param name="defender">the defender</param>
        public static Spell ProcessSpellChoice(string spellchoice, Character attacker)
        {
            Spell spell;
            switch (spellchoice)
            {
                case "H":
                case "h":
                    Heal heal = new Heal();
                    return heal;
                case "F":
                case "f":
                    Fireball fireball = new Fireball();
                    return fireball;
                case "I":
                case "i":
                    Icebolt icebolt = new Icebolt();
                    return icebolt;
                default:
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry that wasn't a valid choice");
                    spellchoice = PrintSpells();
                    spell = ProcessSpellChoice(spellchoice, attacker);
                    break;
            }
            return spell;
        }
        #endregion

        #region CheckMonsters
        /// <summary>
        /// This method makes sure at least one monster is alive to continue the battle
        /// </summary>
        /// <param name="Monsters"></param>
        public static bool CheckMonsters(List<Character> Monsters)
        {
            bool foundone = false;
            foreach (Character monster in Monsters)
            {
                if (monster.isAlive)
                {
                    foundone = true;

                }
            }
            if (foundone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ChooseTarget
        /// <summary>
        /// This method will print out the current monster with an index
        /// so the attacker can choose which one to target.
        /// </summary>
        /// <param name="Monster">This is the list of monsters</param>
        /// <returns>Returns an index of the character to attack</returns>
        public static int ChooseTarget(List<Character> Monster)
        {
            Console.WriteLine("Please choose the monster you are facing.");
            string choice;
            int x = 0;
            foreach (Character monster in Monster)
            {
                x++;
                if (monster.isAlive)
                {
                    Console.WriteLine("{0}: {1}", x, monster.Identifier);
                }
            }
            Console.WriteLine();
            choice = Console.ReadLine();
            try//try this stuff
            {
                x = int.Parse(choice);
            }
            catch (Exception)//if problem try this
            {
                Console.WriteLine("Invalid choice");
                x = ChooseTarget(Monster);
                x++;
            }
            finally//finally when it works do this
            {
                x -= 1;
            }
            return x;

        }
        #endregion

        #region LevelUp
        /// <Summary>
        /// This method will be activated when the hero level's up
        /// it will allow for the character to place points on his skills
        /// </Summary>
        public static void LevelUp(Character hero)
        {
            if (hero.Experience >= ( 2 * (hero.ExpMod * 100)))
            {

                    hero.CurrentHealth = hero.MaxHealth;

                    string UserChoice;
                    int SkillPoints = 5;

                    Console.Clear();
                    Console.WriteLine("{0} has leveled up!", hero.Identifier);
                    Console.ReadLine();
                    hero.LevelCount += 1;
                    hero.ExpMod += 1;
                    while (SkillPoints > 0)
                    {
                        Console.Clear();
                        Console.Write(@"
Name:{0}
Level:{9}
Hitpoints: {1}/{2}
Strength:{3}
Dexterity:{4}
Constitution:{5}
Intelligence:{6}
Experience:{7}", hero.Identifier, hero.CurrentHealth, hero.MaxHealth, hero.Strength
             , hero.Dexterity, hero.Constitution, hero.Intelligence, hero.Experience
             , hero.LevelCount);
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("You have {0} Skill Points.", SkillPoints);
                        Console.WriteLine("What would you like to Assign them to?");
                        Console.WriteLine("---------------------------------------");
                        Console.Write(@"
(S)trength
(D)exterity
(C)onstitution
(I)ntelligence");
                        Console.WriteLine();
                        UserChoice = Console.ReadLine();
                        switch (UserChoice)
                        {
                            case "S":
                            case "s":
                                hero.Strength += 1;
                                SkillPoints -= 1;
                                break;
                            case "D":
                            case "d":
                                hero.Dexterity += 1;
                                SkillPoints -= 1;
                                break;
                            case "C":
                            case "c":
                                hero.Constitution += 1;
                                SkillPoints -= 1;
                                hero.MaxHealth = 20 + ( 2 * (hero.Constitution - 10));
                                hero.CurrentHealth = hero.MaxHealth;
                                break;
                            case "I":
                            case "i":
                                hero.Intelligence += 1;
                                SkillPoints -= 1;
                                break;
                            default:
                                Console.WriteLine();
                                Console.WriteLine("I'm sorry that wasn't a valid choice");
                                Console.ReadLine();
                                break;
                        }
                        Console.Clear();
                    }
                
                
            }

        }
        #endregion

    }

}
