
namespace Statistik
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuSave;
		private System.Windows.Forms.ToolStripMenuItem menuNew;
		private System.Windows.Forms.ToolStripMenuItem menuClose;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuSave,
			this.menuNew,
			this.menuClose});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(511, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuSave
			// 
			this.menuSave.Name = "menuSave";
			this.menuSave.Size = new System.Drawing.Size(43, 20);
			this.menuSave.Text = "Save";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuNew
			// 
			this.menuNew.Name = "menuNew";
			this.menuNew.Size = new System.Drawing.Size(43, 20);
			this.menuNew.Text = "New";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuClose
			// 
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(48, 20);
			this.menuClose.Text = "Close";
			this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
			// 
			// flowLayoutPanel
			// 
			this.flowLayoutPanel.AutoScroll = true;
			this.flowLayoutPanel.Location = new System.Drawing.Point(0, 27);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(511, 606);
			this.flowLayoutPanel.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 633);
			this.Controls.Add(this.flowLayoutPanel);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Statistik";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
