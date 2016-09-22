using System;

namespace DungeonCrawler
{
    public class Monster : Creature, IReadWritable
    {
        //Inheritted Members
        public override int ID { get; protected set; }

        public override int CurrentHP { get; protected set; }
        public override int MaxHP { get; protected set; }

        public override Dice DamageDie { get; protected set; }

        //Class Members
        public string Name { get; private set; }

        public void CreateFromDataFile(string[] dataProperties)
        {
            ID = int.Parse(dataProperties[0]);
            Name = dataProperties[1];

            //On the creature's creation; current HP will = Max Hp
            CurrentHP = int.Parse(dataProperties[2]);
            MaxHP = CurrentHP;

            string[] diceProperties = dataProperties[3].Split(',');
            //the Dice Property is another nested data structure
            //first value will be sides, followed by number of dice
            int sides = int.Parse(diceProperties[0]);
            int dice = int.Parse(diceProperties[1]);

            DamageDie = new Dice(sides, dice);
        }

        /// <summary>
        /// This will take everything that needs to be saved, and assign it to a string array,
        /// which will then be concatenated into a single line and then passed to the DataManager
        /// to be writ to the file.
        /// </summary>
        /// <returns></returns>
        public string FormatDataForSave()
        {
            string[] monsterData = new string[2];

            monsterData[0] = ID.ToString();
            monsterData[1] = Name;
            monsterData[2] = MaxHP.ToString();

            string[] dice = new string[2]
            {
                DamageDie.NumberOfSides.ToString(),
                DamageDie.NumberOfDice.ToString()
            };

            monsterData[3] = dice[0] + "," + dice[1];
            //Compress into a single line
            string dataInALine = "";
            for (int i = 0; i < monsterData.Length; i++)
            {
                dataInALine += monsterData[i] + ";";
            }
            return dataInALine;
        }

    }
}