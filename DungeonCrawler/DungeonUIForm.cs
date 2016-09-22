using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public partial class DungeonUIForm : Form
    {
        //A list to hold references for the four movement buttons
        List<Button> MovementButtons;
        public DungeonUIForm()
        {
            InitializeComponent();

            //Populate the list
            MovementButtons = new List<Button>() { northButton, eastButton, southButton, westButton };

            //Tell the World to create itself
            World.Generate();

            //Load the first room and display
            UpdateUI();
        }

        /// <summary>
        /// This is used for saving data before the application closes
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
                //List<Room> rooms = World.MapOfRooms.Values.ToList();
                //DataManager.SaveData<Room>(rooms, "Room");
                //DataManager.SaveData<Monster>(World.Monsters, "Monster");
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The button event handler for any movement button being clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void movementButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender; //The button that was clicked
            CardinalDirection directionToMove; //Let's figure out which way we're going

            //Parse the Tag property into the direction we're heading
            switch (b.Tag.ToString())
            {
                case "North":
                    directionToMove = CardinalDirection.North;
                    break;
                case "East":
                    directionToMove = CardinalDirection.East;
                    break;
                case "South":
                    directionToMove = CardinalDirection.South;
                    break;
                case "West":
                    directionToMove = CardinalDirection.West;
                    break;
                default:
                    directionToMove = CardinalDirection.Error;
                    break;
            }

            //Tell the MovementManager that it needs to handle some movement
            MovementManager.ChangeRooms(directionToMove);

            //Display the new room's data
            UpdateUI();
        }

        private void UpdateUI()
        { 
            //Update labels
            roomNameLabel.Text = "Room: " + World.CurrentRoom.Name;
            roomDescriptionLabel.Text = "\"" + World.CurrentRoom.Description + "\"";
            monsterNameLabel.Text = "Monsters: " + World.CurrentRoom.Monsters[0].Name;

            //Activate Buttons for valid movements:
            ActivateValidMovementButtons();
        }

        /// <summary>
        /// This looks at the newly entered room's list of neighbors,
        /// neighbors are created and stored in the following order:
        ///     North
        ///     East
        ///     South
        ///     West
        ///     
        /// If the id returned of the neighbor is -1; this means there is no
        /// accessible neighbor in that direction.
        /// If the id is not -1; this is a valid move.
        /// </summary>
        private void ActivateValidMovementButtons()
        {
            //Note: If for some reason MovementButtons.Count is not 4; this will cause an error
            for (int b = 0; b < MovementButtons.Count; b++)       
            {
                MovementButtons[b].Enabled = false; //Default to button being disabled
                if (World.CurrentRoom.NeighborIDs[b] != -1) //Look at the corresponding direction to see if there is a neighbor
                    MovementButtons[b].Enabled = true; //Follow the yellow brick road!
            }
        }

        /// <summary>
        /// This doesn't do anything yet - concept was to have the PlayerForm open to the side,
        /// since I'm doing a minimal information approach on each form.
        /// You can ignore this.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DungeonUIForm_Load(object sender, EventArgs e)
        {
            PlayerForm pf = new PlayerForm();
            pf.Show();
        }
    }
}
