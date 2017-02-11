
namespace Statistics
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuSave;
		private System.Windows.Forms.ToolStripMenuItem menuClose;
		private System.Windows.Forms.FlowLayoutPanel controlsPanel;
		private System.Windows.Forms.ToolStripMenuItem menuSaveAsSubmenu;
		private System.Windows.Forms.TextBox txtStatisticsName;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.ToolStripMenuItem menuClear;
		private System.Windows.Forms.Label lblTotNum;
		private System.Windows.Forms.Label lblTotItems;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem menuSaveAt;
		private System.Windows.Forms.ToolStripMenuItem menuSaveAsText;
		private System.Windows.Forms.Button btnShowList;
		private System.Windows.Forms.ContextMenuStrip cmenuItemList;
		
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
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSaveAsSubmenu = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSaveAt = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSaveAsText = new System.Windows.Forms.ToolStripMenuItem();
			this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.controlsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.txtStatisticsName = new System.Windows.Forms.TextBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.lblTotNum = new System.Windows.Forms.Label();
			this.lblTotItems = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnShowList = new System.Windows.Forms.Button();
			this.cmenuItemList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuSave,
			this.menuSaveAsSubmenu,
			this.menuClear,
			this.menuClose});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.MinimumSize = new System.Drawing.Size(511, 24);
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
			// menuSaveAsSubmenu
			// 
			this.menuSaveAsSubmenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuSaveAt,
			this.menuSaveAsText});
			this.menuSaveAsSubmenu.Name = "menuSaveAsSubmenu";
			this.menuSaveAsSubmenu.Size = new System.Drawing.Size(52, 20);
			this.menuSaveAsSubmenu.Text = "Save...";
			// 
			// menuSaveAt
			// 
			this.menuSaveAt.Name = "menuSaveAt";
			this.menuSaveAt.Size = new System.Drawing.Size(161, 22);
			this.menuSaveAt.Text = "at other location";
			this.menuSaveAt.Click += new System.EventHandler(this.menuSaveAt_Click);
			// 
			// menuSaveAsText
			// 
			this.menuSaveAsText.Name = "menuSaveAsText";
			this.menuSaveAsText.Size = new System.Drawing.Size(161, 22);
			this.menuSaveAsText.Text = "as textfile";
			this.menuSaveAsText.Click += new System.EventHandler(this.menuSaveAsText_Click);
			// 
			// menuClear
			// 
			this.menuClear.Name = "menuClear";
			this.menuClear.Size = new System.Drawing.Size(94, 20);
			this.menuClear.Text = "Clear statistics";
			this.menuClear.Click += new System.EventHandler(this.menuClear_Click);
			// 
			// menuClose
			// 
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(48, 20);
			this.menuClose.Text = "Close";
			this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
			// 
			// controlsPanel
			// 
			this.controlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.controlsPanel.AutoScroll = true;
			this.controlsPanel.Location = new System.Drawing.Point(0, 175);
			this.controlsPanel.Name = "controlsPanel";
			this.controlsPanel.Size = new System.Drawing.Size(511, 458);
			this.controlsPanel.TabIndex = 1;
			// 
			// txtStatisticsName
			// 
			this.txtStatisticsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtStatisticsName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtStatisticsName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtStatisticsName.Location = new System.Drawing.Point(0, 28);
			this.txtStatisticsName.Name = "txtStatisticsName";
			this.txtStatisticsName.Size = new System.Drawing.Size(379, 20);
			this.txtStatisticsName.TabIndex = 0;
			this.txtStatisticsName.TextChanged += new System.EventHandler(this.txtStatisticsName_TextChanged);
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.AutoSize = true;
			this.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnNew.Location = new System.Drawing.Point(385, 26);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(61, 23);
			this.btnNew.TabIndex = 2;
			this.btnNew.Text = "New item";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// lblTotNum
			// 
			this.lblTotNum.Location = new System.Drawing.Point(271, 51);
			this.lblTotNum.Name = "lblTotNum";
			this.lblTotNum.Size = new System.Drawing.Size(117, 13);
			this.lblTotNum.TabIndex = 3;
			this.lblTotNum.Text = "label1";
			// 
			// lblTotItems
			// 
			this.lblTotItems.Location = new System.Drawing.Point(394, 51);
			this.lblTotItems.Name = "lblTotItems";
			this.lblTotItems.Size = new System.Drawing.Size(117, 13);
			this.lblTotItems.TabIndex = 4;
			this.lblTotItems.Text = "label1";
			// 
			// txtComment
			// 
			this.txtComment.Location = new System.Drawing.Point(0, 66);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(511, 103);
			this.txtComment.TabIndex = 5;
			this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Comments:";
			// 
			// btnShowList
			// 
			this.btnShowList.AutoSize = true;
			this.btnShowList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnShowList.Location = new System.Drawing.Point(452, 27);
			this.btnShowList.Name = "btnShowList";
			this.btnShowList.Size = new System.Drawing.Size(59, 23);
			this.btnShowList.TabIndex = 7;
			this.btnShowList.Text = "Show list";
			this.btnShowList.UseVisualStyleBackColor = true;
			this.btnShowList.Click += new System.EventHandler(this.btnShowList_Click);
			// 
			// cmenuItemList
			// 
			this.cmenuItemList.Name = "cmenuItemList";
			this.cmenuItemList.Size = new System.Drawing.Size(61, 4);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 633);
			this.Controls.Add(this.btnShowList);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.lblTotItems);
			this.Controls.Add(this.lblTotNum);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.txtStatisticsName);
			this.Controls.Add(this.controlsPanel);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(523, 665);
			this.Name = "MainForm";
			this.Text = "Statistics";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
