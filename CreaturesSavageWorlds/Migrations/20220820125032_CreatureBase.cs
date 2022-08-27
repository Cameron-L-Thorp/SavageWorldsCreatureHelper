using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreaturesSavageWorlds.Migrations
{
    public partial class CreatureBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreatureAttributes",
                columns: table => new
                {
                    CreatureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Smarts = table.Column<int>(type: "int", nullable: false),
                    Spirit = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Vigor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureAttributes", x => x.CreatureName);
                });

            migrationBuilder.CreateTable(
                name: "CreatureDerivedStats",
                columns: table => new
                {
                    CreatureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pace = table.Column<int>(type: "int", nullable: false),
                    Parry = table.Column<int>(type: "int", nullable: false),
                    Toughness = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureDerivedStats", x => x.CreatureName);
                });

            migrationBuilder.CreateTable(
                name: "CreatureDescriptions",
                columns: table => new
                {
                    CreatureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureDescriptions", x => x.CreatureName);
                });

            migrationBuilder.CreateTable(
                name: "CreatureSkills",
                columns: table => new
                {
                    CreatureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Academics = table.Column<int>(type: "int", nullable: false),
                    Athletics = table.Column<int>(type: "int", nullable: false),
                    Battle = table.Column<int>(type: "int", nullable: false),
                    Boating = table.Column<int>(type: "int", nullable: false),
                    CommonKnowledge = table.Column<int>(type: "int", nullable: false),
                    Driving = table.Column<int>(type: "int", nullable: false),
                    Electronics = table.Column<int>(type: "int", nullable: false),
                    Faith = table.Column<int>(type: "int", nullable: false),
                    Fighting = table.Column<int>(type: "int", nullable: false),
                    Focus = table.Column<int>(type: "int", nullable: false),
                    Gambling = table.Column<int>(type: "int", nullable: false),
                    Hacking = table.Column<int>(type: "int", nullable: false),
                    Healing = table.Column<int>(type: "int", nullable: false),
                    Intimidation = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Notice = table.Column<int>(type: "int", nullable: false),
                    Occult = table.Column<int>(type: "int", nullable: false),
                    Performance = table.Column<int>(type: "int", nullable: false),
                    Persuasion = table.Column<int>(type: "int", nullable: false),
                    Piloting = table.Column<int>(type: "int", nullable: false),
                    Psionics = table.Column<int>(type: "int", nullable: false),
                    Repair = table.Column<int>(type: "int", nullable: false),
                    Research = table.Column<int>(type: "int", nullable: false),
                    Riding = table.Column<int>(type: "int", nullable: false),
                    Science = table.Column<int>(type: "int", nullable: false),
                    Shooting = table.Column<int>(type: "int", nullable: false),
                    Spellcasting = table.Column<int>(type: "int", nullable: false),
                    Stealth = table.Column<int>(type: "int", nullable: false),
                    Survival = table.Column<int>(type: "int", nullable: false),
                    Taunt = table.Column<int>(type: "int", nullable: false),
                    Thievery = table.Column<int>(type: "int", nullable: false),
                    WeirdScience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSkills", x => x.CreatureName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureAttributes");

            migrationBuilder.DropTable(
                name: "CreatureDerivedStats");

            migrationBuilder.DropTable(
                name: "CreatureDescriptions");

            migrationBuilder.DropTable(
                name: "CreatureSkills");
        }
    }
}
