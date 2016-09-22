using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    interface IKillable
    {
        void TakeDamage(int amountOfDamage);

        bool HasTakenFatalDamage();
    }
}
