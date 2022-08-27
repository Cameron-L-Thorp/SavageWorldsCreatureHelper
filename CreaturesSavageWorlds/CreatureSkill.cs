using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesSavageWorlds
{
    public class CreatureSkill
    {
        [Key]
        [Required]
        public string CreatureName { get; set; }
        public int Academics { get; set; }
        public int Athletics { get; set; }
        public int Battle { get; set; }
        public int Boating { get; set; }
        public int CommonKnowledge { get; set; }
        public int Driving { get; set; }
        public int Electronics { get; set; }
        public int Faith { get; set; }
        public int Fighting { get; set; }
        public int Focus { get; set; }
        public int Gambling { get; set; }
        public int Hacking { get; set; }
        public int Healing { get; set; }
        public int Intimidation { get; set; }
        public int Language { get; set; }
        public int Notice { get; set; }
        public int Occult { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }
        public int Piloting { get; set; }
        public int Psionics { get; set; }
        public int Repair { get; set; }
        public int Research { get; set; }
        public int Riding { get; set; }
        public int Science { get; set; }
        public int Shooting { get; set; }
        public int Spellcasting { get; set; }
        public int Stealth { get; set; }
        public int Survival { get; set; }
        public int Taunt { get; set; }
        public int Thievery { get; set; }
        public int WeirdScience { get; set; }

        public CreatureSkill()
        {
            Athletics = 4;
            CommonKnowledge = 4;
            Notice = 4;
            Persuasion = 4;
            Stealth = 4;
            Academics = 2;
            Battle = 2;
            Boating = 2;
            Driving = 2;
            Electronics = 2;
            Faith = 2;
            Fighting = 2;
            Focus = 2;
            Gambling = 2;
            Hacking = 2;
            Healing = 2;
            Intimidation = 2;
            Language = 2;
            Occult = 2;
            Performance = 2;
            Piloting = 2;
            Psionics = 2;
            Repair = 2;
            Research = 2;
            Riding = 2;
            Science = 2;
            Shooting = 2;
            Spellcasting = 2;
            Survival = 2;
            Taunt = 2;
            Thievery = 2;
            WeirdScience = 2;

        }    
    }
}
