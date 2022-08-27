using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CreaturesSavageWorlds
{
    public class CreatureDescription
    {
        [Key]
        [Required]
        public string CreatureName { get; set; }
        public int Size { get; set; }
        [AllowNull]
        public string Notes { get; set; }

        public CreatureDescription()
        {
            Size = 0;
        }
    }
}
