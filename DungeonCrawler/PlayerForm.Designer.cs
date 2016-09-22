namespace DungeonCrawler
{
    partial class PlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hitpointLabeldescription = new System.Windows.Forms.Label();
            this.playerCurrentHPLabel = new System.Windows.Forms.Label();
            this.playerMaxHPLabel = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hitpointLabeldescription
            // 
            this.hitpointLabeldescription.AutoSize = true;
            this.hitpointLabeldescription.Location = new System.Drawing.Point(6, 52);
            this.hitpointLabeldescription.Name = "hitpointLabeldescription";
            this.hitpointLabeldescription.Size = new System.Drawing.Size(110, 25);
            this.hitpointLabeldescription.TabIndex = 0;
            this.hitpointLabeldescription.Text = "Hit Points:";
            // 
            // playerCurrentHPLabel
            // 
            this.playerCurrentHPLabel.AutoSize = true;
            this.playerCurrentHPLabel.Location = new System.Drawing.Point(122, 52);
            this.playerCurrentHPLabel.Name = "playerCurrentHPLabel";
            this.playerCurrentHPLabel.Size = new System.Drawing.Size(36, 25);
            this.playerCurrentHPLabel.TabIndex = 1;
            this.playerCurrentHPLabel.Text = "10";
            // 
            // playerMaxHPLabel
            // 
            this.playerMaxHPLabel.AutoSize = true;
            this.playerMaxHPLabel.Location = new System.Drawing.Point(164, 52);
            this.playerMaxHPLabel.Name = "playerMaxHPLabel";
            this.playerMaxHPLabel.Size = new System.Drawing.Size(48, 25);
            this.playerMaxHPLabel.TabIndex = 2;
            this.playerMaxHPLabel.Text = "/ 10";
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(79, 11);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(155, 25);
            this.playerLabel.TabIndex = 3;
            this.playerLabel.Text = "PC Name Here";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(6, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.playerLabel);
            this.splitContainer1.Panel1.Controls.Add(this.hitpointLabeldescription);
            this.splitContainer1.Panel1.Controls.Add(this.playerCurrentHPLabel);
            this.splitContainer1.Panel1.Controls.Add(this.playerMaxHPLabel);
            this.splitContainer1.Size = new System.Drawing.Size(609, 297);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 4;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 327);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label hitpointLabeldescription;
        private System.Windows.Forms.Label playerCurrentHPLabel;
        private System.Windows.Forms.Label playerMaxHPLabel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}