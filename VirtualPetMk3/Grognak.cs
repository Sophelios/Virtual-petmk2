using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace VirtualPetMk2
{
    //derived class with overrides for male 'pet'
    class Grognak : VirtualPet
    {
        //constructor
        public Grognak()
        {

        }
        Random rand = new Random();
        //Let's player know how their pet is doing.
        public override void GetStats()
        {
            string nameFiller = "";
            foreach (char c in name)
            {
                nameFiller += "_";
            }
            if (valor < 30)
            {
                Console.WriteLine($" ,#####,\n #_   _#\n |Ç` `Ç|   {nameFiller}________\n |' u '|  ({name} scared.)\n \\ ~~~ /  /\n |\\___/|\n/:     :\\\n");
            }
            else if (hunger > 70 && hunger > fatigue && hunger > bloodlust)
            {
                Console.WriteLine($" ,#####,\n #_   _#\n |~` `~|   {nameFiller}________\n |  u  |  ({name} hungry.)\n \\ ¬¬¬ /  /\n |\\___/|\n/:     :\\\n");
            }
            else if (bloodlust > 70 && bloodlust > hunger && bloodlust > fatigue)
            {
                Console.WriteLine($" ,#####,\n #_   _#\n |ò` `ó|   {nameFiller}_________\n |  u  |  ({name} angry!!!)\n \\ ^^^ /  /\n |\\___/|\n/:     :\\\n");
            }
            else if (fatigue > 70 && fatigue > bloodlust && fatigue > hunger)
            {
                Console.WriteLine($" ,#####,\n #_   _#\n |=` `=|   {nameFiller}_________\n |  u  |  ({name} tired...)\n \\ --- /  /\n |\\___/|\n/:     :\\\n");
            }
            else
            {
                Console.WriteLine($" ,#####,\n #_   _#\n |e` `e|   {nameFiller}_________\n |  u  |  ({name} feel ok.)\n \\  =  /  /\n |\\___/|\n/:     :\\\n");
            }
            //Console.WriteLine($"{name}'s hunger is currently {hunger}.");
            //Console.WriteLine($"{name}'s bloodlust is currently {bloodlust}.");
            //Console.WriteLine($"{name}'s valor is currently {valor}.");
            //Console.WriteLine($"{name}'s fatigue is currently {fatigue}");
        }
        //override to determine ending for male pet.
        public override string PetEnd()
        {
            if (valor <= 0)
            {
                Console.Clear();
                Console.WriteLine($"{name} turned coward and fled.\nRaise a new barbarian?");
            }
            else if (hunger >= 100)
            {
                Console.Clear();
                Console.WriteLine($"{name} is too weak to continue. He'll starve before he can find food.\nRaise a new barbarian?");
            }
            else if (fatigue >= 100)
            {
                Console.Clear();
                Console.WriteLine($"{name} is too tired to do anything, ever again.\nRaise a new barbarian?");
            }
            else if (bloodlust >= 100)
            {
                Console.Clear();
                Console.WriteLine($"{name}'s bloodlust is out of control. He will no longer accept your commands.\nRaise a new barbarian?");
            }
            Console.WriteLine("Would you like to play again?");
            return Console.ReadLine();
        }
        //override to alter SelfHelp's notification to reflect gender
        public override void SelfHelp()
        {
            do
            {
                Console.WriteLine("\nWhile he waits.\n");
                if (valor < 10)
                {
                    Epic();
                }
                if (hunger > 90)
                {
                    Hunt();
                }
                if (fatigue > 90)
                {
                    MeadHall();
                }
                if (bloodlust > 90)
                {
                    Pillage();
                }

                Thread.Sleep(20000);
            }
            while (valor > 0 && bloodlust < 100 && hunger < 100 && fatigue < 100);
        }

    }
}