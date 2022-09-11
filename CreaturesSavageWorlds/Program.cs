using CreaturesSavageWorlds;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        //using (var context = new CreatureContext())
        //{

        //}
        Console.WriteLine("Welcome to the alpha of Savage Worlds Creature Helper!");
        bool userCont = true;
        while (userCont)
        {
            Console.WriteLine("Would you like to view [1] or edit/add [2] a creature? ( 0 to quit)");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "1":

                    break;
                case "2":
                    CreatureAddFunctions.AddCreature();
                    break;
                case "view":

                    break;
                case "edit":
                    CreatureAddFunctions.AddCreature();
                    break;
                case "add":
                    CreatureAddFunctions.AddCreature();
                    break;
                case "edit/add":
                    CreatureAddFunctions.AddCreature();
                    break;
                default:
                    userCont = false;
                    return;
            }

            if (userCont)
            {
                Console.WriteLine("Do you have another creature you wish to view or add/edit? [ y / n ]");
                string userInput2 = Console.ReadLine().ToLower();
                if (userInput2 != "y" || userInput2 != "yes")
                    break;
                else
                {
                    userCont = false;
                    break;
                }
            }
        }
    }
}