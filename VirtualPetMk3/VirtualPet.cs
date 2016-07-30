using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace VirtualPetMk2
{
    //base class is female
    public class VirtualPet
    {

        //initialize attributes
        protected int hunger;
        protected int bloodlust;
        protected int valor;
        protected int fatigue;
        protected string name = " ";
        //constuctor.
        public VirtualPet()
        {

        }
        //for randomization
        Random rand = new Random();
        //Let's them quit
        public void Quitter(string quitCheck)
        {
            if (quitCheck.ToLower() == "quit")
            {
                Environment.Exit(0);
            }
        }
        //method to name pet
        public void SetName(string newname)
        {
            name = newname;
        }
        //randomizes starting attributes
        public void StartStats()
        {
            Random rand = new Random();
            hunger = rand.Next(98) + 1;
            bloodlust = rand.Next(98) + 1;
            valor = rand.Next(98) + 1;
            fatigue = rand.Next(98) + 1;
        }
        //method for menu
        public string PetMenu()
        {
            Console.WriteLine($"What would you like {name} to do?");
            Console.WriteLine("1. Pillage a village."); ;
            Console.WriteLine("2. Visit the meadhall.");
            Console.WriteLine("3. Go hunting.");
            Console.WriteLine("4. Listen to the skald's epics.");
            Console.WriteLine("Ask for <help> if you need it");
            return Console.ReadLine();
        }
        //player chooses to pillage.
        public void Pillage()
        {
            int changer = rand.Next(15) + 10;
            bloodlust -= changer;
            Console.WriteLine($"{name} wreaks havoc on an unsuspecting hamlet.\n");
            //Console.WriteLine($"{name}'s bloodlust decreased by {changer-5}.\n");
        }
        //player chooses to hunt
        public void Hunt()
        {
            int changer = rand.Next(15) + 10;
            hunger -= changer;
            Console.WriteLine($"{name}'s hunt is a success.\n");
            //Console.WriteLine($"{name}'s hunger decreased by {changer-5}.\n");
        }
        //player chooses to listen to the skald
        public void Epic()
        {
            int changer = rand.Next(15) + 10;
            valor += changer;
            Console.WriteLine($"{name} is inspired to great valor by the skald's tales.\n");
            //Console.WriteLine($"{name}'s valor increased by {changer-5}.\n");
        }
        //player chooses to go to meadhall
        public void MeadHall()
        {
            int changer = rand.Next(15) + 10;
            fatigue -= changer;
            Console.WriteLine($"{name} relaxes in the meadhall for awhile.\n");
            //Console.WriteLine($"{name}'s fatigue decreased by {changer-5}.\n");
        }
        //run chosen task
        public void RunTask(string task)
        {
            if (task == "1")
            {
                Pillage();
                //Tick();
            }
            else if (task == "2")
            {
                MeadHall();
                //Tick();
            }
            else if (task == "3")
            {
                Hunt();
                //Tick();
            }
            else if (task == "4")
            {
                Epic();
                //Tick();
            }
            // Feedback for player to understand each task
            else if (task.ToLower() == "help")
            {
                Console.WriteLine($"{name} needs to maintain a balanced lifestyle.");
                Console.WriteLine($"Pillage villages to slake {name}'s Bloodlust");
                Console.WriteLine($"Go hunting, lest {name} starves");
                Console.WriteLine($"Visit the meadhall, on occasion, so {name} can get some needed rest");
                Console.WriteLine($"Listen to the skald's epic's, to inspire {name}");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Please enter a valid task\n");
            }
        }
        //Let's player know how their pet is doing.
        public virtual void GetStats()
        {
            string nameFiller = "";
            foreach (char c in name)
            {
                nameFiller += "_";
            }
            if (valor < 30)
            {
                Console.WriteLine($"   ,#####,\n  ,#_   _#,\n ,# Ç` `Ç #,   {nameFiller}________\n #@ ' u ' @#  ({name} scared.)\n ##  ~~~  ##  /\n,### ___ ###,\n####/   \\####\n");
            }
            else if (hunger > 70 && hunger > fatigue && hunger > bloodlust)
            {
                Console.WriteLine($"   ,#####,\n  ,#_   _#,\n ,# ~` `~ #,   {nameFiller}________\n #@   u   @#  ({name} hungry.)\n ##  ¬¬¬  ##  /\n,### ___ ###,\n####/   \\####\n");
            }
            else if (bloodlust > 70 && bloodlust > hunger && bloodlust > fatigue)
            {
                Console.WriteLine($"   ,#####,\n  ,#_   _#,\n ,# ò` `ó #,   {nameFiller}_________\n #@   u   @#  ({name} angry!!!)\n ##  ^^^  ##  /\n,### ___ ###,\n####/   \\####\n");
            }
            else if (fatigue > 70 && fatigue > bloodlust && fatigue > hunger)
            {
                Console.WriteLine($"   ,#####,\n  ,#_   _#,\n ,# =` `= #,   {nameFiller}_________\n #@   u   @#  ({name} tired...)\n ##  ---  ##  /\n,### ___ ###,\n####/   \\####\n");
            }
            else
            {
                Console.WriteLine($"   ,#####,\n  ,#_   _#,\n ,# e` `e #,   {nameFiller}_________\n #@   u   @#  ({name} feel ok.)\n ##   =   ##  /\n,### ___ ###,\n####/   \\####\n");
            }
            //Console.WriteLine($"{name}'s hunger is currently {hunger}.");
            //Console.WriteLine($"{name}'s bloodlust is currently {bloodlust}.");
            //Console.WriteLine($"{name}'s valor is currently {valor}.");
            //Console.WriteLine($"{name}'s fatigue is currently {fatigue}");
        }
        //determine ending
        public virtual string PetEnd()
        {
            if (valor <= 0)
            {
                Console.Clear();
                Console.WriteLine($"{name} turned coward and fled.\nRaise a new barbarian?");
            }
            else if (hunger >= 100)
            {
                Console.Clear();
                Console.WriteLine($"{name} is too weak to continue. She'll starve before she can find food.\nRaise a new barbarian?");
            }
            else if (fatigue >= 100)
            {
                Console.Clear();
                Console.WriteLine($"{name} is too tired to do anything, ever again.\nRaise a new barbarian?");
            }
            else if (bloodlust >= 100)
            {
                Console.Clear();
                Console.WriteLine($"{name}'s bloodlust is out of control. She will no longer accept your commands.\nRaise a new barbarian?");
            }
            Console.WriteLine("Would you like to play again?");
            return Console.ReadLine();
        }
        //periodic state adjustment
        public void Tick()
        {
            do
            {
                this.hunger = hunger + 5;
                this.bloodlust = bloodlust + 5;
                this.valor = valor - 5;
                this.fatigue = fatigue + 5;
                //places caps on attributes
                if (valor > 100)
                {
                    valor = 100;
                }
                if (bloodlust < 0)
                {
                    bloodlust = 0;
                }
                if (hunger < 0)
                {
                    hunger = 0;
                }
                if (fatigue < 0)
                {
                    fatigue = 0;
                }

                Thread.Sleep(5000);
            }
            while (valor > 0 && bloodlust < 100 && hunger < 100 && fatigue < 100);
        }
        //Returns pet's name
        public string Getname()
        {
            return name;
        }
        //Property for pet's valor
        public int GetValor
        {
            get { return valor; }
            set { this.valor = value; }
        }
        //Property for pet's hunger
        public int GetHunger
        {
            get { return hunger; }
            set { this.hunger = value; }
        }
        //Property for pet's fatigue
        public int GetFatigue
        {
            get { return fatigue; }
            set { this.fatigue = value; }
        }
        //Property for pet's bloodlust
        public int GetBloodlust
        {
            get { return bloodlust; }
            set { this.bloodlust = value; }
        }
        //Thread for pet AI
        public virtual void SelfHelp()
        {
            do
            {
                Console.WriteLine("While she waited.\n");
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