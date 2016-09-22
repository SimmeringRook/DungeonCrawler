using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public static class World
    {
        public static Dictionary<int, Room> MapOfRooms;
        public static List<Monster> Monsters;
        public static Room CurrentRoom { get; private set; }

        public static Player ActivePlayer { get; private set; }

        //Read in our saved data and assign to varriables
        public static void Generate()
        {
            /* !----------------------------------WARNING--------------------------------------------------!
             * Monsters -MUST- be loaded before Rooms, because LoadRooms uses the GetMonsterByID(int monsterID) 
             * function to save an instance of the monster to the Room data structure.
             * A null exeception should be thrown when the first room with a Monster is loaded if the Monster list 
             * was unable to populate; either by:
             *      A) The file doesn't exist
             *      B) The data file reading order was changed 
             */
            Monsters = DataManager.LoadMonsters();
            MapOfRooms = DataManager.LoadRooms();

            //Create a dummy player
            //since combat and any interaction with the monster does not exist at this time,
            //This really doesn't do anything
            ActivePlayer = new DungeonCrawler.Player(12, new DungeonCrawler.Dice(4, 2));

            //Set our starting point
            CurrentRoom = MapOfRooms[0];
            /* Note:
             * Since MapOfRooms is a Dictionary using RoomID as the key,
             * The starting room does not have to have an ID of 0.
             * This would be even more relevant if you are showing a simple x,y map,
             * and want the player to be in the same world x,y once they go up/down stairs
             */ 
        }

        /// <summary>
        /// This might be bad form, not checking to see if "newRoomID" is a vaild RoomID;
        /// but as long as neighbors are defined correctly, the disabling of movement buttons
        /// will prevent this function from ever being passed a value that will cause an IndexOutOfBoundsException
        /// 
        /// Probably worth having some sort of error checking, just in case of typos when creating/inputting the 
        /// dungeon layout.
        /// </summary>
        /// <param name="newRoomID"></param>
        public static void MoveRooms(int newRoomID)
        {
            CurrentRoom = MapOfRooms[newRoomID];
        }

        /// <summary>
        /// Takes the int ID of a monster, compares it to the Master List of Monsters, and
        /// returns the corresponding Monster.
        /// </summary>
        /// <param name="monsterID"></param>
        /// <returns></returns>
        public static Monster GetMonsterByID (int monsterID)
        {
            foreach (Monster m in Monsters)
            {
                if (m.ID == monsterID)
                {
                    return m;
                }
            }
            /*
            For the event the loop can't find the correct monster, we'll return the dreaded...
            "Empty" monster! This should probably have some error checking on the calling 
            function along the lines of:
            
            int monsterInRoomID;
            Monster monsterReturned = GetMonsterById( monsterInRoomID)
            if (monsterInRoomID != monsterReturned.ID) {
                // Divide everything by 0
            }

            So we know Empty was returned in error, and not that the room was supposed to be empty
            */
            return Monsters[0]; 
            
        }
    }
}
