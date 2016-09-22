using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Room : IReadWritable
    {
        //Unique ID
        public int ID { get; private set; }

        //Descriptors
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Monster> Monsters { get; private set; }

        //Neighbors (e.g. valid movements)
        public List<int> NeighborIDs { get; private set; }

        [Obsolete("This requires pre-parsed information to create a Room; CreateFromDataFile should be used instead.", false)]
        /// <summary>
        /// This Exists for Legacy reasons. Simple constructor that takes already parsed information and builds a Room.
        /// </summary>
        public void Create(int id, string name, string description, List<Monster> monsters, List<int> neighborIDs)
        {
            //ID = id;
            //Name = name;
            //Description = description;

            //Monsters = monsters;
            //NeighborIDs = neighborIDs;
        }

        /// <summary>
        /// This Constructor takes in the raw strings read from the file, parses it, and creates a Room.
        /// </summary>
        /// <returns></returns>
        public void CreateFromDataFile(string[] roomProperties)
        {

            /// ~~ Personal Note: ~~
            /// I found using this, slightly more complicated, method a little bit easier
            /// Since, writing data to text files can get ugly if you forget to update 
            /// the read/writing to reflect any reordering or other structural changes in
            /// the class.
            ///
            /// Given the growning complixety at this stage, I would probably starting switching
            /// the DataManager class from Text IO to XML.

            ///How the data will be read in:
            ///Property Name     data type   index nested data
            ///-------------------------------------------------
            ///ID           int         0       false
            ///Name         string      1       false
            ///Description  string      2       false
            ///Monsters     int         3       true
            ///Neighbors    int         4       true
            ID = int.Parse(roomProperties[0]);
            Name = roomProperties[1];
            Description = roomProperties[2];

            //Parse Nested Data:
            char listDelimiter = ',';

            //Get the monsters
            Monsters = new List<Monster>();
            string[] monsterIDs = roomProperties[3].Split(listDelimiter);
            foreach (string monsterString in monsterIDs)
            {
                Monster monster = World.GetMonsterByID(int.Parse(monsterString));
                if (monster == null) //If monster == null; Data was saved incorrectly
                    System.Windows.Forms.MessageBox.Show("Attempted to load monster for Room[" + ID + "]\n" + "with a Monster_ID of: " + monsterString);
                Monsters.Add(monster);
            }

            //Get the neighbors
            NeighborIDs = new List<int>();
            string[] accessibleNeighbors = roomProperties[4].Split(listDelimiter);
            foreach (string neighbor in accessibleNeighbors)
            {
                NeighborIDs.Add(int.Parse(neighbor));
            }
        }

        /// <summary>
        /// This will take everything that needs to be saved, and assign it to a string array,
        /// which will then be concatenated into a single line and then passed to the DataManager
        /// to be writ to the file.
        /// </summary>
        /// <returns></returns>
        public string FormatDataForSave()
        {

            ///How the data will be read in is also the order in which it must be saved;
            ///Property Name     data type   index nested data
            ///-------------------------------------------------
            ///roomID           int         0       false
            ///roomName         string      1       false
            ///roomDescription  string      2       false
            ///monstersInRoom   int         3       true
            ///neighborIDs      int         4       true
            ///
            string[] roomData = new string[5];

            roomData[0] = ID.ToString();
            roomData[1] = Name;
            roomData[2] = Description;

            for(int m=0; m < Monsters.Count; m++)
            {
                roomData[3] += Monsters[m].ID.ToString();
                if (m +1 < Monsters.Count)
                    roomData[3] += ",";
            }

            for(int n=0; n < NeighborIDs.Count; n++)
            {
                roomData[4] += NeighborIDs[n].ToString();
                if (n + 1 < NeighborIDs.Count)
                    roomData[4] += ",";
            }

            //Compress into a single line
            string dataInALine = "";
            for (int i=0; i < roomData.Length; i++)
            {
                dataInALine += roomData[i] + ";";
            }

            return dataInALine;
        }
    }
}