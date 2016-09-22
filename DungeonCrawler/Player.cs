using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// Nothing really cool to show off here yet, other than in the World class
    /// See if on the ActivePlayer you can call
    /// TakeDamage(int amount)
    ///  or
    /// HasTakenFatalDamage()
    /// 
    /// Do you understand why that works?
    /// </summary>
    public class Player : Creature
    {
        public override int ID { get; protected set; }
        //You can use this field for differentiating different players, ie, save slot 1 etc

        public override int CurrentHP { get; protected set; }
        public override int MaxHP { get; protected set; }

        public override Dice DamageDie { get; protected set; }

        public Player(int hp, Dice playerDice)
        {
            MaxHP = hp;
            CurrentHP = hp;
            DamageDie = playerDice;
        }
    }
}
