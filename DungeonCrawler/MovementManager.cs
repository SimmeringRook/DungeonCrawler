using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    /// <summary>
    /// The sole purpose of this class is to talk between the World and the Form;
    /// allowing the Form to focus on UI changes
    /// and the World to focus on Runing the dungeon
    /// 
    /// This class -shouldn't- have to get too much more complicated than this.
    /// While not a lot of code, it does help serve to separate logic and keep
    /// relevant classes dealing with what they need to.
    /// </summary>
    public static class MovementManager
    {
        static Room currRoom; 
        //While not explicitly needed, this does serve as a nice short cut
        //to avoid writing "World.CurrentRoom" all the time - helps shorten lines and maintain
        //readability in more complicated calls

        /// <summary>
        /// Takes the direction the player is moving and tells World to head there.
        /// </summary>
        /// <param name="directionToMove"></param>
        public static void ChangeRooms(CardinalDirection directionToMove)
        {
            currRoom = World.CurrentRoom; 
            //Takes the new room's ID and tells the World the new room
            int newRoomID = GetRoomIDByDirection(directionToMove);
            World.MoveRooms(newRoomID);
        }

        /// <summary>
        /// Helper function to translate the Cardinal Direction into the destination Room's ID
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        static int GetRoomIDByDirection(CardinalDirection direction)
        {
            switch (direction)
            {
                case CardinalDirection.North:
                    return (currRoom.NeighborIDs[0]);
                case CardinalDirection.East:
                    return (currRoom.NeighborIDs[1]);
                case CardinalDirection.South:
                    return (currRoom.NeighborIDs[2]);
                case CardinalDirection.West:
                    return (currRoom.NeighborIDs[3]);
            }
            System.Windows.Forms.MessageBox.Show("Something horrible went wrong in GetRoomIDByDirection\n" + 
                direction.ToString() + " - CurrentRoom: " + currRoom.Name + "[" + currRoom.ID.ToString() + "]");
            return -26; //Maybe need a better error handle here
        }
    }

    public enum CardinalDirection
    {
        North,
        East,
        South,
        West,
        Error
    }
}
