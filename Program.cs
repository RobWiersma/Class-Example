using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ConsoleApplication1.Classes;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {   
            //create our enemy objects to fight
            Enemy e1 = new Enemy(8, 85, 0);
            AirEnemy e2 = new AirEnemy(10, 70, 0);

            fireEnemy e3 = new fireEnemy(11, 50, 50);
            iceEnemy e4 = new iceEnemy(10, 60, 55);

            enemyBattle(e1, e4);

            Console.ReadKey();
        }

        static void enemyBattle(Enemy e1, Enemy e2)
        {
            while (e1.hp > 0 && e2.hp > 0)
            {
                Console.WriteLine(e1.name + " is preparing to attack...");
                int e1AttackDmg = e1.attack();
                e2.hp -= e1AttackDmg;
                Console.WriteLine(e1.name + " hit " + e2.name + " for " + e1AttackDmg + " points of damage! " + e2.name + " has " + e2.hp + " left.");

                if (e2.hp <= 0)
                {
                    Console.WriteLine(e1.name + " has defeated " + e2.name + "!!!");
                    break;
                }

                Console.WriteLine(e2.name + " is preparing to attack...");
                int e2AttackDmg = e2.attack();
                e1.hp -= e2AttackDmg;
                Console.WriteLine(e2.name + " hit " + e1.name + " for " + e2AttackDmg + " points of damage! " + e1.name + " has " + e1.hp + " left.");

                if (e1.hp <= 0)
                {
                    Console.WriteLine(e2.name + " has defeated " + e1.name + "!!!");
                    break;
                }
            }
        }
    }

}

