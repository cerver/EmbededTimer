namespace EmbededTimer
{
    partial class TimerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.updateInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btReset = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cFrameTxt = new System.Windows.Forms.Label();
            this.btPlay = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.updateInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // updateInterval
            // 
            this.updateInterval.Location = new System.Drawing.Point(8, 88);
            this.updateInterval.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.updateInterval.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.updateInterval.Name = "updateInterval";
            this.updateInterval.Size = new System.Drawing.Size(111, 22);
            this.updateInterval.TabIndex = 7;
            this.updateInterval.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.updateInterval.ValueChanged += new System.EventHandler(this.updateInterval_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Speed (ms)";
            // 
            // btReset
            // 
            this.btReset.Appearance = System.Windows.Forms.Appearance.Button;
            this.btReset.AutoSize = true;
            this.btReset.Checked = true;
            this.btReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btReset.Image = global::EmbededTimer.Properties.Resources.player_reset_true;
            this.btReset.Location = new System.Drawing.Point(65, 12);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(54, 54);
            this.btReset.TabIndex = 2;
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.CheckedChanged += new System.EventHandler(this.btReset_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Frame:";
            // 
            // cFrameTxt
            // 
            this.cFrameTxt.AutoSize = true;
            this.cFrameTxt.Location = new System.Drawing.Point(122, 32);
            this.cFrameTxt.Name = "cFrameTxt";
            this.cFrameTxt.Size = new System.Drawing.Size(15, 14);
            this.cFrameTxt.TabIndex = 10;
            this.cFrameTxt.Text = "0";
            // 
            // btPlay
            // 
            this.btPlay.Appearance = System.Windows.Forms.Appearance.Button;
            this.btPlay.AutoSize = true;
            this.btPlay.Image = global::EmbededTimer.Properties.Resources.player_play;
            this.btPlay.Location = new System.Drawing.Point(8, 12);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(54, 54);
            this.btPlay.TabIndex = 11;
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.CheckedChanged += new System.EventHandler(this.btPlay_CheckedChanged);
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(196, 117);
            this.ControlBox = false;
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.cFrameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.updateInterval);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(212, 155);
            this.MinimumSize = new System.Drawing.Size(212, 155);
            this.Name = "TimerForm";
            this.ShowIcon = false;
            this.Text = "GC Timer";
            ((System.ComponentModel.ISupportInitialize)(this.updateInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox btReset;
        private System.Windows.Forms.NumericUpDown updateInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cFrameTxt;
        private System.Windows.Forms.CheckBox btPlay;
    }
}