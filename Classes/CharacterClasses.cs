using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{

    public class Enemy
    {
        //default enemy class with only ground attacks

        public string name { get; set; }
        public int hp { get; set; }
        public int mana { get; set; }
        protected int level;

        protected int groundAttackMin = 1; //based on default level 1
        protected int groundAttackMax = 7;

        //default constructor with no params
        public Enemy(int clevel, int chp, int cmana)
        {
            name = "Ground Enemy";
            hp = chp;
            level = clevel;
            mana = cmana;
            alterValues();
        }

        public Enemy() : this (1,10,1)
        {
        }

        public Enemy(int clevel) : this(clevel, 10, 1)
        {
        }

        public Enemy(int clevel, int chp) : this (clevel, chp, 1)
        {
        }



        //set our attack values based on level
        private void alterValues()
        {
            //initialize our attack values based on min and max values
            groundAttackMin *= level;
            groundAttackMax *= level;
            hp *= level;
        }

        public virtual int attack()
        {
            Console.WriteLine(name + " is using ground attack!");
            var rnd = new Random(DateTime.Now.Millisecond);
            int dmg = rnd.Next(groundAttackMin,groundAttackMax);
            return dmg;
        }

    }


    public class AirEnemy : Enemy
    {
        //this class can do air attacks + weak ground attacks

        enum attackType
        {
            air,
            ground
        }

        protected int airAttackMin = 1;
        protected int airAttackMax = 11;

        public AirEnemy(int clevel, int chp, int cmana) : base(clevel, chp, cmana)
        {
            name = "Air Enemy";
            alterAttackValues();
        }

        public AirEnemy() : this(1, 7, 1)
        {
        }

        public AirEnemy(int clevel) : this(clevel, 7, 1)
        {
        }

        public AirEnemy(int clevel, int chp) : this(clevel, chp, 1)
        {
        }

        private void alterAttackValues()
        {
            //initialize our air attack values based on min and max values and nerf ground attack
            airAttackMin *= level;
            airAttackMax *= level;
            groundAttackMin /= 2;
            groundAttackMax /= 2;
        }

        private attackType getRandomAttackType()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(0, Enum.GetNames(typeof(attackType)).Length);

            return (attackType)ticks;
        }

        private int airAttack()
        {
            Console.WriteLine(name + " is using air attack!");
            var rnd = new Random(DateTime.Now.Millisecond);
            int dmg = rnd.Next(airAttackMin, airAttackMax);
            return dmg;
        }

        public override int attack()
        {
            attackType at = getRandomAttackType();

            int damage = 0;

            switch (at)
            {
                case attackType.ground:
                    damage = base.attack();
                    break;
                case attackType.air:
                    damage = airAttack();
                    break;
            }

            return damage;
        }
    }

    //interface for 2 subclasses of enemy (fire magic / ice magic)
    public interface IMagicEnemy
    {
        int magicAttackMin {get;set;}
        int magicAttackMax {get;set;}

        //different attack types that must be implemented
        int magicAttack();

    }

    public class iceEnemy : Enemy, IMagicEnemy
    {

        public int magicAttackMin
        {
            get;
            set;
        }
        public int magicAttackMax
        {
            get;
            set;
        }

        public iceEnemy(int clevel, int chp, int cmana)
            : base(clevel, chp, cmana)
        {
            magicAttackMin = 2;
            magicAttackMax = 10;
            name = "Ice Enemy";
            alterAttackValues();
        }

        private enum attackType
        {
            ground,
            ice
        }

        private void alterAttackValues()
        {
            //initialize our air attack values based on min and max values and nerf ground attack
            magicAttackMin *= level;
            magicAttackMax *= level;
            groundAttackMin /= 3;
            groundAttackMax /= 3;
        }

        public int magicAttack()
        {
            Console.WriteLine(name + " is using ice attack!");
            var rnd = new Random(DateTime.Now.Millisecond);
            int dmg = rnd.Next(magicAttackMin, magicAttackMax);
            return dmg;
        }

        private attackType getRandomAttackType()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(0, Enum.GetNames(typeof(attackType)).Length);

            return (attackType)ticks;
        }

        public override int attack()
        {
            attackType at = getRandomAttackType();

            int damage = 0;

            switch (at)
            {
                case attackType.ground:
                    damage = base.attack();
                    break;
                case attackType.ice:
                    damage = magicAttack();
                    break;
            }

            return damage;
        }

    }

    public class fireEnemy : Enemy, IMagicEnemy
    {

        public int magicAttackMin
        {
            get;
            set;
        }
        public int magicAttackMax
        {
            get;
            set;
        }

        public fireEnemy(int clevel, int chp, int cmana)
            : base(clevel, chp, cmana)
        {
            magicAttackMin = 5;
            magicAttackMax = 14;
            name = "Fire Enemy";
            alterAttackValues();
        }

        private enum attackType
        {
            ground,
            fire
        }

        private void alterAttackValues()
        {
            //initialize our air attack values based on min and max values and nerf ground attack
            magicAttackMin *= level;
            magicAttackMax *= level;
            groundAttackMin /= 3;
            groundAttackMax /= 3;
        }

        public int magicAttack()
        {
            Console.WriteLine(name + " is using fire attack!");
            var rnd = new Random(DateTime.Now.Millisecond);
            int dmg = rnd.Next(magicAttackMin, magicAttackMax);
            return dmg;
        }

        private attackType getRandomAttackType()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(0, Enum.GetNames(typeof(attackType)).Length);

            return (attackType)ticks;
        }

        public override int attack()
        {
            attackType at = getRandomAttackType();

            int damage = 0;

            switch (at)
            {
                case attackType.ground:
                    damage = base.attack();
                    break;
                case attackType.fire:
                    damage = magicAttack();
                    break;
            }

            return damage;
        }

    }

    
}
