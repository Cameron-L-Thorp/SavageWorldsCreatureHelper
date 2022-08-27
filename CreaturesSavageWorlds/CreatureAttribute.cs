using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesSavageWorlds
{
    public class CreatureAttribute
    {
        [Key]
        [Required]
        public string CreatureName { get; set; }
        public int Agility { get; set; }
        public int Smarts { get; set; }
        public int Spirit { get; set; }
        public int Strength { get; set; }
        public int Vigor { get; set; }

        public CreatureAttribute()
        {
            Agility = 4;
            Smarts = 4;
            Spirit = 4;
            Strength = 4;
            Vigor = 4;
        }
    }
}
