namespace DungeonCrawler
{
    partial class DungeonUIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.roomDescriptionLabel = new System.Windows.Forms.Label();
            this.monsterNameLabel = new System.Windows.Forms.Label();
            this.westButton = new System.Windows.Forms.Button();
            this.eastButton = new System.Windows.Forms.Button();
            this.northButton = new System.Windows.Forms.Button();
            this.interactButton = new System.Windows.Forms.Button();
            this.southButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Location = new System.Drawing.Point(115, 30);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(74, 25);
            this.roomNameLabel.TabIndex = 0;
            this.roomNameLabel.Text = "Room:";
            // 
            // roomDescriptionLabel
            // 
            this.roomDescriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomDescriptionLabel.Location = new System.Drawing.Point(120, 77);
            this.roomDescriptionLabel.Name = "roomDescriptionLabel";
            this.roomDescriptionLabel.Size = new System.Drawing.Size(510, 61);
            this.roomDescriptionLabel.TabIndex = 1;
            this.roomDescriptionLabel.Text = "\"\"";
            // 
            // monsterNameLabel
            // 
            this.monsterNameLabel.AutoSize = true;
            this.monsterNameLabel.Location = new System.Drawing.Point(120, 158);
            this.monsterNameLabel.Name = "monsterNameLabel";
            this.monsterNameLabel.Size = new System.Drawing.Size(96, 25);
            this.monsterNameLabel.TabIndex = 2;
            this.monsterNameLabel.Text = "Monster!";
            // 
            // westButton
            // 
            this.westButton.Location = new System.Drawing.Point(120, 281);
            this.westButton.Name = "westButton";
            this.westButton.Size = new System.Drawing.Size(153, 46);
            this.westButton.TabIndex = 3;
            this.westButton.Tag = "West";
            this.westButton.Text = "West";
            this.westButton.UseVisualStyleBackColor = true;
            this.westButton.Click += new System.EventHandler(this.movementButton_Click);
            // 
            // eastButton
            // 
            this.eastButton.Location = new System.Drawing.Point(487, 281);
            this.eastButton.Name = "eastButton";
            this.eastButton.Size = new System.Drawing.Size(143, 46);
            this.eastButton.TabIndex = 4;
            this.eastButton.Tag = "East";
            this.eastButton.Text = "East";
            this.eastButton.UseVisualStyleBackColor = true;
            this.eastButton.Click += new System.EventHandler(this.movementButton_Click);
            // 
            // northButton
            // 
            this.northButton.Location = new System.Drawing.Point(288, 216);
            this.northButton.Name = "northButton";
            this.northButton.Size = new System.Drawing.Size(153, 46);
            this.northButton.TabIndex = 5;
            this.northButton.Tag = "North";
            this.northButton.Text = "North";
            this.northButton.UseVisualStyleBackColor = true;
            this.northButton.Click += new System.EventHandler(this.movementButton_Click);
            // 
            // interactButton
            // 
            this.interactButton.Enabled = false;
            this.interactButton.Location = new System.Drawing.Point(288, 281);
            this.interactButton.Name = "interactButton";
            this.interactButton.Size = new System.Drawing.Size(153, 46);
            this.interactButton.TabIndex = 6;
            this.interactButton.Tag = "";
            this.interactButton.Text = "Interact";
            this.interactButton.UseVisualStyleBackColor = true;
            // 
            // southButton
            // 
            this.southButton.Location = new System.Drawing.Point(288, 346);
            this.southButton.Name = "southButton";
            this.southButton.Size = new System.Drawing.Size(153, 46);
            this.southButton.TabIndex = 7;
            this.southButton.Tag = "South";
            this.southButton.Text = "South";
            this.southButton.UseVisualStyleBackColor = true;
            this.southButton.Click += new System.EventHandler(this.movementButton_Click);
            // 
            // DungeonUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 436);
            this.Controls.Add(this.southButton);
            this.Controls.Add(this.interactButton);
            this.Controls.Add(this.northButton);
            this.Controls.Add(this.eastButton);
            this.Controls.Add(this.westButton);
            this.Controls.Add(this.monsterNameLabel);
            this.Controls.Add(this.roomDescriptionLabel);
            this.Controls.Add(this.roomNameLabel);
            this.Name = "DungeonUIForm";
            this.Text = "DungeonUIForm";
            this.Load += new System.EventHandler(this.DungeonUIForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.Label roomDescriptionLabel;
        private System.Windows.Forms.Label monsterNameLabel;
        private System.Windows.Forms.Button westButton;
        private System.Windows.Forms.Button eastButton;
        private System.Windows.Forms.Button northButton;
        private System.Windows.Forms.Button interactButton;
        private System.Windows.Forms.Button southButton;
    }
}

