namespace ShinraCo.Settings.Forms
{
    partial class ShinraOverlay
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
            this.ShinraBorder = new System.Windows.Forms.Panel();
            this.ShinraContainer = new System.Windows.Forms.Panel();
            this.CRStatusLabel = new System.Windows.Forms.Label();
            this.CooldownModeLabel = new System.Windows.Forms.Label();
            this.ShinraLogo = new System.Windows.Forms.PictureBox();
            this.TankModeLabel = new System.Windows.Forms.Label();
            this.RotationModeLabel = new System.Windows.Forms.Label();
            this.ShinraBorder.SuspendLayout();
            this.ShinraContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShinraLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // ShinraBorder
            // 
            this.ShinraBorder.BackColor = System.Drawing.Color.GreenYellow;
            this.ShinraBorder.Controls.Add(this.ShinraContainer);
            this.ShinraBorder.Location = new System.Drawing.Point(3, 1);
            this.ShinraBorder.Name = "ShinraBorder";
            this.ShinraBorder.Size = new System.Drawing.Size(248, 104);
            this.ShinraBorder.TabIndex = 0;
            this.ShinraBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShinraOverlay_MouseDown);
            // 
            // ShinraContainer
            // 
            this.ShinraContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ShinraContainer.Controls.Add(this.CRStatusLabel);
            this.ShinraContainer.Controls.Add(this.CooldownModeLabel);
            this.ShinraContainer.Controls.Add(this.ShinraLogo);
            this.ShinraContainer.Controls.Add(this.TankModeLabel);
            this.ShinraContainer.Controls.Add(this.RotationModeLabel);
            this.ShinraContainer.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ShinraContainer.Location = new System.Drawing.Point(1, 1);
            this.ShinraContainer.Name = "ShinraContainer";
            this.ShinraContainer.Size = new System.Drawing.Size(246, 102);
            this.ShinraContainer.TabIndex = 0;
            this.ShinraContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.ShinraContainer_Paint);
            this.ShinraContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShinraOverlay_MouseDown);
            // 
            // CRStatusLabel
            // 
            this.CRStatusLabel.AutoSize = true;
            this.CRStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRStatusLabel.ForeColor = System.Drawing.Color.White;
            this.CRStatusLabel.Location = new System.Drawing.Point(49, 74);
            this.CRStatusLabel.Name = "CRStatusLabel";
            this.CRStatusLabel.Size = new System.Drawing.Size(90, 25);
            this.CRStatusLabel.TabIndex = 4;
            this.CRStatusLabel.Text = "CR Status";
            // 
            // CooldownModeLabel
            // 
            this.CooldownModeLabel.AutoSize = true;
            this.CooldownModeLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CooldownModeLabel.ForeColor = System.Drawing.Color.White;
            this.CooldownModeLabel.Location = new System.Drawing.Point(49, 23);
            this.CooldownModeLabel.Name = "CooldownModeLabel";
            this.CooldownModeLabel.Size = new System.Drawing.Size(183, 25);
            this.CooldownModeLabel.TabIndex = 3;
            this.CooldownModeLabel.Text = "[Cooldown] Enabled";
            this.CooldownModeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShinraOverlay_MouseDown);
            // 
            // ShinraLogo
            // 
            this.ShinraLogo.Location = new System.Drawing.Point(2, 26);
            this.ShinraLogo.Name = "ShinraLogo";
            this.ShinraLogo.Size = new System.Drawing.Size(47, 47);
            this.ShinraLogo.TabIndex = 2;
            this.ShinraLogo.TabStop = false;
            this.ShinraLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShinraOverlay_MouseDown);
            // 
            // TankModeLabel
            // 
            this.TankModeLabel.AutoSize = true;
            this.TankModeLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TankModeLabel.ForeColor = System.Drawing.Color.White;
            this.TankModeLabel.Location = new System.Drawing.Point(49, 48);
            this.TankModeLabel.Name = "TankModeLabel";
            this.TankModeLabel.Size = new System.Drawing.Size(101, 25);
            this.TankModeLabel.TabIndex = 1;
            this.TankModeLabel.Text = "[Tank] DPS";
            this.TankModeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShinraOverlay_MouseDown);
            // 
            // RotationModeLabel
            // 
            this.RotationModeLabel.AutoSize = true;
            this.RotationModeLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationModeLabel.ForeColor = System.Drawing.Color.White;
            this.RotationModeLabel.Location = new System.Drawing.Point(49, -2);
            this.RotationModeLabel.Name = "RotationModeLabel";
            this.RotationModeLabel.Size = new System.Drawing.Size(151, 25);
            this.RotationModeLabel.TabIndex = 0;
            this.RotationModeLabel.Text = "[Rotation] Single";
            this.RotationModeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShinraOverlay_MouseDown);
            // 
            // ShinraOverlay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(253, 107);
            this.Controls.Add(this.ShinraBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(205, 71);
            this.Name = "ShinraOverlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ShinraOverlay";
            this.Load += new System.EventHandler(this.ShinraOverlay_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShinraOverlay_MouseDown);
            this.ShinraBorder.ResumeLayout(false);
            this.ShinraContainer.ResumeLayout(false);
            this.ShinraContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShinraLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ShinraBorder;
        private System.Windows.Forms.Panel ShinraContainer;
        private System.Windows.Forms.Label RotationModeLabel;
        private System.Windows.Forms.Label TankModeLabel;
        private System.Windows.Forms.PictureBox ShinraLogo;
        private System.Windows.Forms.Label CooldownModeLabel;
        private System.Windows.Forms.Label CRStatusLabel;
    }
}