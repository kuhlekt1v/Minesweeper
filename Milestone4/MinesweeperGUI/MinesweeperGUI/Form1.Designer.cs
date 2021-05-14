
namespace MinesweeperGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpSelectLevel = new System.Windows.Forms.GroupBox();
            this.btnPlayGame = new System.Windows.Forms.Button();
            this.rdoDifficult = new System.Windows.Forms.RadioButton();
            this.rdoModerate = new System.Windows.Forms.RadioButton();
            this.rdoEasy = new System.Windows.Forms.RadioButton();
            this.grpSelectLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSelectLevel
            // 
            this.grpSelectLevel.Controls.Add(this.btnPlayGame);
            this.grpSelectLevel.Controls.Add(this.rdoDifficult);
            this.grpSelectLevel.Controls.Add(this.rdoModerate);
            this.grpSelectLevel.Controls.Add(this.rdoEasy);
            this.grpSelectLevel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.grpSelectLevel.Location = new System.Drawing.Point(12, 12);
            this.grpSelectLevel.Name = "grpSelectLevel";
            this.grpSelectLevel.Size = new System.Drawing.Size(220, 200);
            this.grpSelectLevel.TabIndex = 0;
            this.grpSelectLevel.TabStop = false;
            this.grpSelectLevel.Text = "Select Level";
            // 
            // btnPlayGame
            // 
            this.btnPlayGame.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlayGame.Location = new System.Drawing.Point(107, 158);
            this.btnPlayGame.Name = "btnPlayGame";
            this.btnPlayGame.Size = new System.Drawing.Size(100, 28);
            this.btnPlayGame.TabIndex = 3;
            this.btnPlayGame.Text = "Play Game";
            this.btnPlayGame.UseVisualStyleBackColor = true;
            this.btnPlayGame.Click += new System.EventHandler(this.btnPlayGame_Click);
            // 
            // rdoDifficult
            // 
            this.rdoDifficult.AutoSize = true;
            this.rdoDifficult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoDifficult.Location = new System.Drawing.Point(12, 124);
            this.rdoDifficult.Name = "rdoDifficult";
            this.rdoDifficult.Size = new System.Drawing.Size(82, 25);
            this.rdoDifficult.TabIndex = 2;
            this.rdoDifficult.Text = "Difficult";
            this.rdoDifficult.UseVisualStyleBackColor = true;
            // 
            // rdoModerate
            // 
            this.rdoModerate.AutoSize = true;
            this.rdoModerate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoModerate.Location = new System.Drawing.Point(12, 79);
            this.rdoModerate.Name = "rdoModerate";
            this.rdoModerate.Size = new System.Drawing.Size(95, 25);
            this.rdoModerate.TabIndex = 1;
            this.rdoModerate.Text = "Moderate";
            this.rdoModerate.UseVisualStyleBackColor = true;
            // 
            // rdoEasy
            // 
            this.rdoEasy.AutoSize = true;
            this.rdoEasy.Checked = true;
            this.rdoEasy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoEasy.Location = new System.Drawing.Point(12, 33);
            this.rdoEasy.Name = "rdoEasy";
            this.rdoEasy.Size = new System.Drawing.Size(59, 25);
            this.rdoEasy.TabIndex = 0;
            this.rdoEasy.TabStop = true;
            this.rdoEasy.Text = "Easy";
            this.rdoEasy.UseVisualStyleBackColor = true;
            // 
            // SelectLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 227);
            this.Controls.Add(this.grpSelectLevel);
            this.Name = "SelectLevel";
            this.Text = "Select Level";
            this.grpSelectLevel.ResumeLayout(false);
            this.grpSelectLevel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelectLevel;
        private System.Windows.Forms.Button btnPlayGame;
        private System.Windows.Forms.RadioButton rdoDifficult;
        private System.Windows.Forms.RadioButton rdoModerate;
        private System.Windows.Forms.RadioButton rdoEasy;
    }
}

