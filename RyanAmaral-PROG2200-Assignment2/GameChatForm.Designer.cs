namespace RyanAmaral_PROG2200_Assignment2
{
    partial class GameChatForm
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
            this.groupBoxConversation = new System.Windows.Forms.GroupBox();
            this.textBoxConversation = new System.Windows.Forms.TextBox();
            this.groupBoxMessage = new System.Windows.Forms.GroupBox();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.menuStripNetworkGame = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxConversation.SuspendLayout();
            this.groupBoxMessage.SuspendLayout();
            this.menuStripNetworkGame.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConversation
            // 
            this.groupBoxConversation.Controls.Add(this.textBoxConversation);
            this.groupBoxConversation.Location = new System.Drawing.Point(12, 314);
            this.groupBoxConversation.Name = "groupBoxConversation";
            this.groupBoxConversation.Size = new System.Drawing.Size(674, 233);
            this.groupBoxConversation.TabIndex = 0;
            this.groupBoxConversation.TabStop = false;
            this.groupBoxConversation.Text = "Conversation";
            // 
            // textBoxConversation
            // 
            this.textBoxConversation.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxConversation.Location = new System.Drawing.Point(6, 19);
            this.textBoxConversation.Multiline = true;
            this.textBoxConversation.Name = "textBoxConversation";
            this.textBoxConversation.ReadOnly = true;
            this.textBoxConversation.Size = new System.Drawing.Size(662, 208);
            this.textBoxConversation.TabIndex = 2;
            this.textBoxConversation.TabStop = false;
            // 
            // groupBoxMessage
            // 
            this.groupBoxMessage.Controls.Add(this.buttonSendMessage);
            this.groupBoxMessage.Controls.Add(this.textBoxMessage);
            this.groupBoxMessage.Location = new System.Drawing.Point(12, 256);
            this.groupBoxMessage.Name = "groupBoxMessage";
            this.groupBoxMessage.Size = new System.Drawing.Size(674, 52);
            this.groupBoxMessage.TabIndex = 1;
            this.groupBoxMessage.TabStop = false;
            this.groupBoxMessage.Text = "Type your message here.";
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(593, 17);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(75, 23);
            this.buttonSendMessage.TabIndex = 1;
            this.buttonSendMessage.Text = "Send";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(6, 19);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(581, 20);
            this.textBoxMessage.TabIndex = 0;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
            // 
            // menuStripNetworkGame
            // 
            this.menuStripNetworkGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.networkToolStripMenuItem});
            this.menuStripNetworkGame.Location = new System.Drawing.Point(0, 0);
            this.menuStripNetworkGame.Name = "menuStripNetworkGame";
            this.menuStripNetworkGame.Size = new System.Drawing.Size(698, 24);
            this.menuStripNetworkGame.TabIndex = 2;
            this.menuStripNetworkGame.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.gameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.networkToolStripMenuItem.Text = "Network";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 223);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(159, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Goes Here";
            // 
            // GameChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxMessage);
            this.Controls.Add(this.groupBoxConversation);
            this.Controls.Add(this.menuStripNetworkGame);
            this.MainMenuStrip = this.menuStripNetworkGame;
            this.Name = "GameChatForm";
            this.Text = "Network Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameChatForm_FormClosing);
            this.Load += new System.EventHandler(this.GameChatForm_Load);
            this.groupBoxConversation.ResumeLayout(false);
            this.groupBoxConversation.PerformLayout();
            this.groupBoxMessage.ResumeLayout(false);
            this.groupBoxMessage.PerformLayout();
            this.menuStripNetworkGame.ResumeLayout(false);
            this.menuStripNetworkGame.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConversation;
        private System.Windows.Forms.TextBox textBoxConversation;
        private System.Windows.Forms.GroupBox groupBoxMessage;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.MenuStrip menuStripNetworkGame;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

