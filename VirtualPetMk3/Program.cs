using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VirtualPetMk2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string to check for repeat play
            string ender = "yes";
            //start the game loop
            do
            {
                //clears leftover text
                Console.Clear();
                //greeting
                Console.WriteLine("Congratulations. You have been selected to raise your very own Barbarian!\nYou can <quit> anytime.\n\nIs your barbarian a boy, or a girl?\n");
                //players response for gender
                string boyGirl = Console.ReadLine();
                //conditional for boy barbarian
                if (boyGirl.ToLower() == "boy")
                {
                    //creates the object, calling the derived class
                    Grognak Pet = new Grognak();
                    //ask the user to name their pet
                    Console.WriteLine("What will he be called?");
                    //call class/method to set the name
                    Pet.SetName(Console.ReadLine());
                    //runs quitcheck
                    Pet.Quitter(Pet.Getname());
                    //clears greeting text
                    Console.Clear();
                    //displays user feedback for the name
                    Console.WriteLine($"{Pet.Getname()} has been born!");
                    //tick start. runs every 5s
                    Thread tick = new Thread(Pet.Tick);
                    Thread selfhelp = new Thread(Pet.SelfHelp);
                    selfhelp.Start();
                    tick.Start();
                    Pet.StartStats();
                    do
                    {
                        Pet.GetStats();
                        string task = Pet.PetMenu();
                        Console.Clear();
                        Pet.Quitter(task);
                        Pet.RunTask(task);
                    }
                    while (Pet.GetValor > 0 && Pet.GetHunger < 100 && Pet.GetFatigue < 100 && Pet.GetBloodlust < 100);
                    ender = Pet.PetEnd();

                }
                else if (boyGirl.ToLower() == "girl")
                {
                    VirtualPet Pet = new VirtualPet();
                    Console.WriteLine("What will she be called?");
                    Pet.SetName(Console.ReadLine());
                    Pet.Quitter(Pet.Getname());
                    Console.Clear();
                    Console.WriteLine($"{Pet.Getname()} has been born!");

                    //initial display

                    Thread tick = new Thread(Pet.Tick);
                    tick.Start();
                    Thread selfhelp = new Thread(Pet.SelfHelp);
                    selfhelp.Start();
                    Pet.StartStats();
                    do
                    {
                        Pet.GetStats();
                        string task = Pet.PetMenu();
                        Console.Clear();
                        Pet.Quitter(task);
                        Pet.RunTask(task);
                    }
                    while (Pet.GetValor > 0 && Pet.GetHunger < 100 && Pet.GetFatigue < 100 && Pet.GetBloodlust < 100);
                    ender = Pet.PetEnd();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your barbarian must be either a <BOY> or a <GIRL>");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

            }
            while (ender.ToLower() == "yes");

        }
    }
}