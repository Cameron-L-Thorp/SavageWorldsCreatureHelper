using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;

namespace CreaturesSavageWorlds
{
    public static class CreatureAddFunctions
    {
        public static void AddCreature()
        {
            bool contUse = true;
            while (contUse)
            {
                Console.WriteLine("In order to add a creature, you must provide the description first.");
                Console.WriteLine("Which aspect of a creature would you like to add or edit?");
                Console.WriteLine("1. Description | 2. Attributes | 3. Skills | 4. Derived Stats");
                Console.WriteLine("WARNING: Selecting to edit the skills or derived stats of a creature will reset its values to the standard values.");
                string userEntry = Console.ReadLine().ToLower();
                switch (userEntry)
                {
                    case "1":
                        AddCreatureDescription.AddDescription();
                        Console.Clear();
                        break;
                    case "2":
                        AddCreatureAttributes.AddAttributes();
                        Console.Clear();
                        break;
                    case "3":
                        AddCreatureSkills.AddSkills();
                        Console.Clear();
                        break;
                    case "4":
                        AddCreatureDerivedStats.AddDerivedStats();
                        Console.Clear();
                        break;
                    case "description":
                        AddCreatureDescription.AddDescription();
                        Console.Clear();
                        break;
                    case "attributes":
                        AddCreatureAttributes.AddAttributes();
                        Console.Clear();
                        break;
                    case "skills":
                        AddCreatureSkills.AddSkills();
                        Console.Clear();
                        break;
                    case "derived stats":
                        AddCreatureDerivedStats.AddDerivedStats();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter the number or the name of the aspect of a creature you would like to add or edit.");
                        break;
                }
                Console.WriteLine("Would you like to add to or edit another creature? [ y / n ]");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "y" || userInput == "yes")
                {
                    continue;
                }
                else
                {
                    contUse = false;
                    break;
                }
            }
            

            
            
            

            //Console.WriteLine("Would you like to enter another creature description? [ y / n ]");
            //string userEntry2 = Console.ReadLine();
            //if (userEntry2 == "y")
            //{
            //    continue;
            //}
            //else
            //{
            //    break;
            //}
        }
    }

    public static class AddCreatureDescription
    {
        public static void AddDescription()
        {
            while (true)
            {
                Console.WriteLine("You will be asked to provide the unique Name, Size (-4 - 20), and Notes on the creature.");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Size: ");
                int size = Convert.ToInt32(Console.ReadLine());
                Console.Write("Notes: ");
                string notes = Console.ReadLine();
                Console.WriteLine($"Are the following entries accurate? \nName: {name} \nSize: {size} \nNotes: {notes} ? \n(entering yes will create a new entry for this creature) \n[ y / n ]");
                string userEntry = Console.ReadLine();
                if (userEntry.ToLower() == "y")
                {
                    using (var context = new CreatureContext())
                    {
                        var crtDesc = new CreatureDescription()
                        {
                            CreatureName = name.ToLower().Trim(),
                            Size = size,
                            Notes = notes,
                        };
                        context.CreatureDescriptions.Add(crtDesc);
                       

                        var crtAtt = new CreatureAttribute()
                        {
                            CreatureName = name.ToLower().Trim()
                        };
                        context.CreatureAttributes.Add(crtAtt);
                  

                        var crtSkl = new CreatureSkill()
                        {
                            CreatureName = name.ToLower().Trim()
                        };
                        context.CreatureSkills.Add(crtSkl);
                        

                        var crtDerStat = new CreatureDerivedStat()
                        {
                            CreatureName = name.ToLower().Trim()
                        };
                        context.CreatureDerivedStats.Add(crtDerStat);
                        context.SaveChanges();
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }
            
        }
    }

    public static class AddCreatureAttributes
    {
        public static void AddAttributes()
        {
            bool contUse = true;
            while (contUse)
            {

                Console.WriteLine("You have selected to add creature attributes.");
                Console.WriteLine("Enter the creature name you wish to add attributes to.");
                string name = Console.ReadLine().ToLower().Trim();
                using (var context = new CreatureContext())
                {
                    bool nameTrue = context.CreatureDescriptions.Where(c => c.CreatureName.Contains(name)).Any();
                    if (nameTrue)
                    {
                        Console.Write("Please enter the AGILITY die value (d4 = 4, d12+2 = 14): ");
                        int agility = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter the SMARTS die value (d4 = 4, d12+2 = 14): ");
                        int smarts = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter the SPIRIT die value (d4 = 4, d12+2 = 14): ");
                        int spirit = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter the STRENGTH die value (d4 = 4, d12+2 = 14): ");
                        int strength = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter the VIGOR die value (d4 = 4, d12+2 = 14): ");
                        int vigor = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"The values you entered are...\nAgility: d{agility} \nSmarts: d{smarts} \nSpirit: d{spirit} \nStrength: d{strength} \nVigor: d{vigor}");
                        Console.WriteLine("Are these values correct? [y/n]");
                        string userEntry = Console.ReadLine();
                        if (userEntry.ToLower() == "y")
                        {
                            var crtAtt = new CreatureAttribute()
                            {
                                CreatureName = name,
                                Agility = agility,
                                Smarts = smarts,
                                Spirit = spirit,
                                Strength = strength,
                                Vigor = vigor
                            };
                            context.CreatureAttributes.Update(crtAtt);
                            context.SaveChanges();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("This creature does not exist in the current database.");
                        Console.WriteLine("Would you like to try a different name? [ y / n ]");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() != "y" || userInput.ToLower() != "yes")
                        {
                            continue;
                        }
                        else
                        {
                            contUse = false;
                            break;
                        }
                    }
                }
            }
        }
    }

    public class AddCreatureSkills
    {
        public static void AddSkills()
        {
            bool contUse = true;
            while (contUse)
            {
                Console.WriteLine("Enter the name of a creature you would like to see or edit the skills for. (n to exit)");
                Console.Write("Creature Name: ");
                string nameReal = Console.ReadLine();
                string name = nameReal.ToLower().Trim();

                using (var creatureContext = new CreatureContext())
                {
                    bool nameTrue = creatureContext.CreatureDescriptions.Where(c => c.CreatureName.Contains(name)).Any();

                    if (nameTrue)
                    {
                        Console.WriteLine($"The automatic skill values are 2 (d4 - 2) and 4 (d4) for core skills.");
                        bool contUse2 = true;
                        CreatureSkill creature = new CreatureSkill() { CreatureName = name };
                        Console.WriteLine("Enter the name of the skill you would like to change. (n to end)");
                        while (contUse2)
                        {
                            Console.WriteLine("Enter the next skill or n if complete.");
                            string skillRaw = Console.ReadLine();
                            string skill = skillRaw.ToLower().Trim();
                            skill = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(skill);
                            if (skill == "Common Knowledge")
                                skill = "CommonKnowledge";
                            else if (skill == "Commonknowledge")
                                skill = "CommonKnowledge";
                            if (skill == "Wierd Science")
                                skill = "WeirdScience";
                            else if (skill == "Wierdscience")
                                skill = "WierdScience";
                            else if (skill.ToLower() == "n" || skill.ToLower() == "no")
                            {
                                contUse2 = false;
                                break;
                            }
                            var skillValue = ReflectPropertyValue(creature, skill);
                            var creatureSelected = creatureContext.CreatureSkills.Where(c => c.CreatureName == name);
                            if (creatureSelected.Where(c => c.CreatureName.Contains(name)).Any())
                            {
                                //CreatureSkill creature = new CreatureSkill() { CreatureName = name};
                                //var skillSelect = creatureContext.GetType().GetProperty(skill).GetValue(creatureContext, null);
                                //PropertyInfo skillSelection = typeof(string).GetProperty(skill);
                                //object skillSelect = skillSelection.GetValue(creature, null);
                                //var skillNames = creatureContext.CreatureSkills.Where(c => c.CreatureName == name);
                                //var skillName = skillNames.Where(c => c.Equals(skill));
                                
                                //var skillValue = creature.selectSkill;

                                //The lesson here is there is a time and place for lambda, and instantiating objects with user inputs is not one of them!
                                Console.WriteLine($"The current value for {skill}: {skillValue}");
                                Console.Write($"What is the new value for {skill}:");
                                int newSkillValue = Int32.Parse(Console.ReadLine());

                                switch (skill)
                                {
                                    case "Academics":
                                        creature.Academics = newSkillValue;
                                        break;
                                    case "Athletics":
                                        creature.Athletics = newSkillValue;
                                        break;
                                    case "Battle":
                                        creature.Battle = newSkillValue;
                                        break;
                                    case "Boating":
                                        creature.Boating = newSkillValue;
                                        break;
                                    case "CommonKnowledge":
                                        creature.CommonKnowledge = newSkillValue;
                                        break;
                                    case "Driving":
                                        creature.Driving = newSkillValue;
                                        break;
                                    case "Hacking":
                                        creature.Hacking = newSkillValue;
                                        break;
                                    case "Healing":
                                        creature.Healing = newSkillValue;
                                        break;
                                    case "Intimidation":
                                        creature.Intimidation = newSkillValue;
                                        break;
                                    case "Language":
                                        creature.Language = newSkillValue;
                                        break;
                                    case "Notice":
                                        creature.Notice = newSkillValue;
                                        break;
                                    case "Occult":
                                        creature.Occult = newSkillValue;
                                        break;
                                    case "Performance":
                                        creature.Performance = newSkillValue;
                                        break;
                                    case "Persuasion":
                                        creature.Persuasion = newSkillValue;
                                        break;
                                    case "Piloting":
                                        creature.Piloting = newSkillValue;
                                        break;
                                    case "Psionics":
                                        creature.Psionics = newSkillValue;
                                        break;
                                    case "Repair":
                                        creature.Repair = newSkillValue;
                                        break;
                                    case "Research":
                                        creature.Research = newSkillValue;
                                        break;
                                    case "Riding":
                                        creature.Riding = newSkillValue;
                                        break;
                                    case "Science":
                                        creature.Science = newSkillValue;
                                        break;
                                    case "Shooting":
                                        creature.Shooting = newSkillValue;
                                        break;
                                    case "Spellcasting":
                                        creature.Spellcasting = newSkillValue;
                                        break;
                                    case "Stealth":
                                        creature.Stealth = newSkillValue;
                                        break;
                                    case "Survival":
                                        creature.Survival = newSkillValue;
                                        break;
                                    case "Taunt":
                                        creature.Taunt = newSkillValue;
                                        break;
                                    case "Thievery":
                                        creature.Thievery = newSkillValue;
                                        break;
                                    case "WeirdScience":
                                        creature.WeirdScience = newSkillValue;
                                        break;
                                    default:
                                        break;
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("The skill you entered is not recognized.");
                                break;
                            }
                            
                        }
                        if (nameTrue)
                        {
                            var crtSkl = creature;
                            {

                            };
                            creatureContext.Update(crtSkl);
                            creatureContext.SaveChanges();
                        }
                        else
                        {
                            var crtSkl = creature;
                            {
                                
                            };
                            creatureContext.CreatureSkills.Add(crtSkl);
                            creatureContext.SaveChanges();
                        }

                    }
                    else
                    {
                        Console.WriteLine("This creature does not exist in the current database.");
                        Console.WriteLine("Would you like to try a different name? [ y / n ]");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() != "y" || userInput.ToLower() != "yes")
                        {
                            continue;
                        }
                        else
                        {
                            contUse = false;
                            break;
                        }
                    }
                }
                Console.WriteLine("Would you like to create or edit skills for another creature? [y / n]");
                string contUse3 = Console.ReadLine();
                if (contUse3.ToLower() != "y" || contUse3.ToLower() != "yes")
                    break;
            }
        }
        public static object ReflectPropertyValue(object source, string property)
        {
            return source.GetType().GetProperty(property).GetValue(source, null);
        }

    }

    public static class AddCreatureDerivedStats
    {
        public static void AddDerivedStats()
        {
            bool contUse = true;
            while (contUse)
            {
                Console.WriteLine("Enter the name of a creature you would like to see or edit the Derived Stats for. (n to exit)");
                Console.WriteLine("(Entering a creature's name will return their stats to default value before editing)");
                Console.Write("Creature Name: ");
                string name = Console.ReadLine();
                int pace;
                int parry;
                int toughness;

                using (var creatureContext = new CreatureContext())
                {
                    bool nameTrue = creatureContext.CreatureDescriptions.Where(c => c.CreatureName.Contains(name)).Any();

                    if (nameTrue)
                    {
                        pace = 6;
                        parry = creatureContext.CreatureSkills.Where(c => c.CreatureName == name).Sum(c => (c.Fighting / 2) + 2);
                        toughness = creatureContext.CreatureAttributes.Where(c => c.CreatureName == name).Sum(c => (c.Vigor / 2) + 2);
                        Console.WriteLine($"The automatic derived stats are Pace: {pace}, Parry: {parry}, Toughness: {toughness}");
                        bool contUse2 = true;
                        while (contUse2)
                        {
                            Console.WriteLine($"The current values are Pace: {pace}, Parry: {parry}, Toughness: {toughness}");
                            Console.WriteLine("Would you like to override any of these? [Pace / Parry / Toughness / n]");
                            string userInput = Console.ReadLine();
                            if (userInput.ToLower() == "pace")
                            {
                                Console.Write("Please enter the new Pace: ");
                                pace = Int32.Parse(Console.ReadLine());
                            }
                            else if (userInput.ToLower() == "parry")
                            {
                                Console.Write("Please enter the new Parry: ");
                                parry = Int32.Parse(Console.ReadLine());
                            }
                            else if (userInput.ToLower() == "toughness")
                            {
                                Console.Write("Please enter the new Toughness: ");
                                toughness = Int32.Parse(Console.ReadLine());
                            }
                            else if (userInput.ToLower() == "n" || userInput.ToLower() == "no")
                            {
                                contUse2 = false;
                                break;
                            }
                            else
                                Console.WriteLine("Input invalid, please enter one of the following: [Pace / Parry / Toughness / n]");
                        }
                        if (nameTrue)
                        {
                            var crtDerAtt = new CreatureDerivedStat()
                            {
                                CreatureName = name,
                                Pace = pace,
                                Parry = parry,
                                Toughness = toughness
                            };
                            creatureContext.Update(crtDerAtt);
                            creatureContext.SaveChanges();
                        }
                        else
                        {
                            var crtDerAtt = new CreatureDerivedStat()
                            {
                                CreatureName = name,
                                Pace = pace,
                                Parry = parry,
                                Toughness = toughness
                            };
                            creatureContext.CreatureDerivedStats.Add(crtDerAtt);
                            creatureContext.SaveChanges();
                        }

                    }
                    else
                    {
                        Console.WriteLine("This creature does not exist in the current database.");
                        Console.WriteLine("Would you like to try a different name? [ y / n ]");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
                        {
                            continue;
                        }
                        else
                        {
                            contUse = false;
                            break;
                        }
                    }
                }
                Console.WriteLine("Would you like to create or edit derived stats for another creature? [y / n]");
                string contUse3 = Console.ReadLine();
                if (contUse3.ToLower() != "y" || contUse3.ToLower() != "yes")
                    break;
            }
        }
    }
}
