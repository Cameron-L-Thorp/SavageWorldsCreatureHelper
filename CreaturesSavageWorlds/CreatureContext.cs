using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaturesSavageWorlds
{
    public class CreatureContext :DbContext
    {
        public DbSet<CreatureAttribute> CreatureAttributes { get; set; }
        public DbSet<CreatureDerivedStat> CreatureDerivedStats { get; set; }
        public DbSet<CreatureDescription> CreatureDescriptions { get; set; }
        public DbSet<CreatureSkill> CreatureSkills { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CAMERONDESKTOP;Database=SavageWorldCreatures;trusted_connection=true;");
        }
    }
}
