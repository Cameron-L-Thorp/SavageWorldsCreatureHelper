using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesSavageWorlds
{
    public class CreatureDerivedStat
    {
        [Key]
        [Required]
        public string CreatureName { get; set; }
        public int Pace { get; set; }
        public int Parry { get; set; }
        public int Toughness { get; set; }

        public CreatureDerivedStat()
        {
            Pace = 6;
            Parry = 3;
            Toughness = 4;
        }
    }
}
