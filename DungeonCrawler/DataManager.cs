using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DungeonCrawler
{
    /// <summary>
    /// This class has the helper functions for reading and writing data.
    /// The Writing function is not really used at this point - but implementing
    /// it does help serve to fully understand how the data is stored, and how
    /// it needs to be read in.
    /// </summary>
    public static class DataManager
    {
        //Super cool way to say: Hey, we're starting in the Project folder and then adding \DataFiles\ on to it.
        private static string dataFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\DataFiles\\";

        /// <summary>
        /// Read in the Room Data from the Rooms.txt file
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Room> LoadRooms()
        {
            //Create our dictionary to hold the information
            Dictionary<int, Room> idRoomMap = new Dictionary<int, Room>();
            try
            {
                //Set up the stream reader and delimiters
                StreamReader dataFile;
                dataFile = File.OpenText(dataFolderPath + "Rooms.txt");

                //Read and parse the file
                while (!dataFile.EndOfStream)
                {
                    /* All we are doing here is taking the current line of the file and assigning it to "line"
                     * 
                     * Then we cut up that line into smaller strings, using ";" as our guide.
                     * We then pass this information to that cool method defined in Room 
                     * and it handles assigning the data correctly (and parsing out the nested data) 
                     */
                    //All your data are belong to us
                    string line = dataFile.ReadLine(); 

                    //Character used to denote that everything before this belongs in its own string
                    char propertyDelimiter = ';'; 
                    //Take line, and cut it into pieces where ever we see ";"
                    string[] dataProperties = line.Split(propertyDelimiter);

                    //Create a holder for the room we just read
                    Room temp = new Room();
                    //Tell room to do our work for us
                    temp.CreateFromDataFile(dataProperties);

                    //Add the room to the map of Rooms
                    idRoomMap.Add(temp.ID, temp);
                }
                //We've read in all the data, close the file
                dataFile.Close();
                /* --------Note:--------
                 * If you forget this, like I've done for a couple hours,
                 * you'll continue to get "File not accessible" or "busy" errors
                 * because the system never got notified that you're done messing 
                 * with the file.
                 */ 
            }
            catch (Exception exceptionThrown)
            {
                //Uh oh... what happened?
                //Actually really useful to set this up, helps give some more details as to why it failed
                //Like an improper path
                System.Windows.Forms.MessageBox.Show("Load Rooms failed with: \n" + exceptionThrown.Message);
            }

            return idRoomMap;
        }


        /// <summary>
        /// Super cool method to write data regardless of class (Monster/Room);
        /// but totally not being used right now.
        /// 
        /// Good learning point though (and fun to figure out)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfDataToSave"></param>
        /// <param name="DataType"></param>
        public static void SaveData<T>(List<T> listOfDataToSave, string DataType) where T : IReadWritable
        {
            //You'll notice that Monster and Room both implement the IReadWritable interface
            //So, what we're doing here is basically saying - this function is going to be called by
            //someone who implements IReadWritable, so we can be pretty generic about who it is and what it does
            //but we know some stuff about it.
            try
            {
                StreamWriter dataFile = new StreamWriter(dataFolderPath + "\\" + DataType + "s.txt", true);
                //This will overwrite data in the file, if the file already exists
                //Useful, but dangerous
                
                string line = ""; //hello old friend

                //So, that List<T> listOfDataToSave would either be:
                //List<Room> or List<Monster>
                //But, how can we use this to our advantage?
                foreach (IReadWritable data in listOfDataToSave)
                {
                    //Oh... remember that kinda weird save method we implemented from IReadWritable?
                    line = data.FormatDataForSave();
                    //We're basically saying, I don't know exactly what "data" is, but I know that because
                    //it uses IReadWritable, it has this awesome method for saving data
                    //And this is also where the benefit of having that method format and store everything into
                    //one line, because this loop becomes a very simple 2 lines of code.
                    dataFile.WriteLine(line);
                }

                //Don't forget this:
                dataFile.Close();
            }
            catch (Exception exceptionThrown)
            {
                //The only problem here, which I need to do more research on
                //Is if the generic type fails, the exceptionThrown can be rather vague
                System.Windows.Forms.MessageBox.Show("Save Data failed with:\n" + DataType + "\n" + exceptionThrown.Message);
            }
        }

        /// <summary>
        /// Read in the Room Data from the Rooms.txt file
        /// </summary>
        /// <returns></returns>
        public static List<Monster> LoadMonsters()
        {
            //Check out LoadRooms for more detailed comments
            //and commentary (its 2:11 am, I'm lazy)
            List<Monster> Monsters = new List<Monster>();
            try
            {
                //Set up the stream reader and delimiters
                StreamReader dataFile;
                dataFile = File.OpenText(dataFolderPath + "Monsters.txt");

                //Read and parse the file
                while (!dataFile.EndOfStream)
                {
                    //Grab the line to parse
                    string line = dataFile.ReadLine();

                    //Split the line into segements using the "propertyDelimiter"
                    //All information separated by the ';' char denotes information
                    //that will be assigned to a property of Room
                    char propertyDelimiter = ';';
                    string[] dataProperties = line.Split(propertyDelimiter);
                    Monster temp = new Monster();
                    temp.CreateFromDataFile(dataProperties);
                    //Add the room to the map of Rooms
                    Monsters.Add( temp);
                }
                //We've read in all the data, close the file
                dataFile.Close();
            }
            catch (Exception exceptionThrown)
            {
                System.Windows.Forms.MessageBox.Show(exceptionThrown.Message);
                Monsters = null;
            }

            return Monsters;
        }
    }
}

/* Legacy Code for reading Room Data
//Initalize a new Room to hold all parsed information
                    Room tempRoom = new Room();
                    //First, the easy stuff
                    int roomID = int.Parse(roomProperties[0]);
                    string roomName = roomProperties[1];
                    string roomDescription = roomProperties[2];

                    //Now for nested Data
                    char listDelimiter = ',';

                    //Get the monsters
                    string[] monsterIDs = roomProperties[3].Split(listDelimiter);
                    List<Monster> monstersInRoom = new List<Monster>();
                    foreach (string monsterString in monsterIDs)
                    {
                        Monster monster = World.GetMonsterByID(int.Parse(monsterString));
                        if (monster != null)
                        {
                            monstersInRoom.Add(monster);
                        }
                        else
                        { //If monster == null
                          //Data was saved incorrectly
                            System.Windows.Forms.MessageBox.Show("Attempted to load monster for Room[" + roomID + "]\n"
                                + "with a Monster_ID of: " + monsterString);
                        }

                    }

                    //Get the neighbors
                    string[] accessibleNeighbors = roomProperties[4].Split(listDelimiter);
                    List<int> neighborIDs = new List<int>();
                    foreach (string neighbor in accessibleNeighbors)
                    {
                        neighborIDs.Add(int.Parse(neighbor));
                    }

                    //Create the room (room's constructor)
                    tempRoom.Create(roomID, roomName, roomDescription, monstersInRoom, neighborIDs);
 */
