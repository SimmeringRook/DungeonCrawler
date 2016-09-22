using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// So, we know two things about Monsters and the Player.
    /// They both have HP,
    /// they both use n-sided Die to deal damage (change if otherwise)
    /// and, they are both Killable, since they have HP.
    /// 
    /// IKillable makes defining that behavior simple, and at this point
    /// Taking damage and returning whether or not the Creature is dead,
    /// is very straight forward.
    /// 
    /// The beauty of polymorphism, is that if you have a Super Boss Monster,
    /// that initiates another phase or does something else when he "dies" the
    /// first time, you can just override the method in a BossMonster class.
    /// </summary>
    public abstract class Creature : IKillable
    {
        public abstract int ID { get; protected set; }
        public abstract int CurrentHP { get; protected set; }
        public abstract int MaxHP { get; protected set; }

        public abstract Dice DamageDie { get; protected set; }

        public virtual void TakeDamage(int amountOfDamage)
        {
            CurrentHP -= amountOfDamage;
        }

        public virtual bool HasTakenFatalDamage()
        {
            return (CurrentHP <= 0);
        }
    }


    public class Dice
    {
        public int NumberOfSides { get; private set; }
        public int NumberOfDice { get; private set; }

        public Dice(int numberSides, int numberDie)
        {
            NumberOfSides = numberSides;
            NumberOfDice = numberDie;
        }

        public int Roll()
        {
            int rollResult = 0;
            Random r = new Random();

            //roll range (1, sides), dice times
            for (int d = 0; d < NumberOfDice; d++)
            {
                rollResult += r.Next(1, NumberOfSides);
            }
            
            return rollResult;
        }
    }
}
