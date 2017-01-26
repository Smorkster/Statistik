using System;
using System.Drawing;
using System.Windows.Forms;

namespace Statistics
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Statistics statistics = new Statistics();

		public MainForm()
		{
			InitializeComponent();
			statistics = new FileHandler().Read();
			statistics.addAutoCompleteList(new FileHandler().getAutoCompleteList());
			txtStatisticsName.AutoCompleteCustomSource = statistics.getAutoCompleteList();
			
			populateStatisticsControls();
		}

		/// <summary>
		/// Creates controls for an statisticsitem
		/// If the si-item is 'null' a new item is created from the textbox
		/// </summary>
		/// <param name="si">Name and count is fetched from the StatisticsItem</param>
		/// <returns>Name of the statisticsitem for use when adding to statisticscollection</returns>
		string createNewStatControls(StatisticsItem si)
		{
			string name;
			int count;

			if (si == null) {
				name = txtStatisticsName.Text;
				count = 1;
			} else {
				name = si.ItemName;
				count = si.ItemCount;
			}

			Button newRemove = new Button();
			newRemove.Name = "rm" + name;
			newRemove.Text = "Remove";
			newRemove.Click += removeStat;
			newRemove.FlatStyle = FlatStyle.Flat;
			newRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			newRemove.AutoSize = true;
			newRemove.TabStop = false;

			Label newLabel = new Label();
			newLabel.Size = new Size(25, 15);
			newLabel.TextAlign = ContentAlignment.MiddleCenter;
			newLabel.Text = count.ToString();
			newLabel.Name = "lb" + name;

			Button newButton = new Button();
			newButton.Text = name;
			newButton.Name = "btn" + name;
			newButton.MouseDown += moreStatistics;
			newButton.FlatStyle = FlatStyle.Flat;
			newButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			newButton.AutoSize = true;
			newButton.TabStop = false;

			SuspendLayout();
			controlsPanel.Controls.Add(newRemove);
			controlsPanel.Controls.Add(newLabel);
			controlsPanel.Controls.Add(newButton);
			controlsPanel.SetFlowBreak(newButton, true);
			ResumeLayout(false);

			updateCountLabel();
			updateItemCountLabel();
			menuSave.Enabled = true;
			return name;
		}

		/// <summary>
		/// Adds or subtracts to the count of the statistics
		/// Is based on which mousebutton i used
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic MouseEventArgs</param>
		public void moreStatistics(object sender, MouseEventArgs e)
		{
			string labelName = "lb" + (sender as Button).Text;
			MouseEventArgs ea = (MouseEventArgs)e;
			if (e.Button == MouseButtons.Right)
				statistics.countSubtracted((sender as Button).Text);
			else
				statistics.countAdded((sender as Button).Text);
			
			int number = statistics.getCounts((sender as Button).Text);
			controlsPanel.Controls.Find(labelName, true)[0].Text = number.ToString();
			updateCountLabel();
			ActiveControl = txtStatisticsName;
			menuSave.Enabled = true;
		}

		/// <summary>
		/// Loop through collection and call for creating the controls
		/// </summary>
		void populateStatisticsControls()
		{
			foreach (StatisticsItem si in statistics.getItemList()) {
				createNewStatControls(si);
			}
			txtComment.Text = statistics.Comments;
			updateCountLabel();
			updateItemCountLabel();
			menuSave.Enabled = false;
		}

		/// <summary>
		/// Removes a specified statistics
		/// Is based on which button is pressed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="ea">Generic EventArgs</param>
		public void removeStat(object sender, EventArgs ea)
		{
			string statName = (sender as Button).Name.Substring(2);
			string labelName = "lb" + statName;
			string buttonName = "btn" + statName;
			string removeName = "rm" + statName;
			
			Control[] lbl = controlsPanel.Controls.Find(labelName, true);
			Control[] btn = controlsPanel.Controls.Find(buttonName, true);
			Control[] rm = controlsPanel.Controls.Find(removeName, true);
			controlsPanel.Controls.Remove(lbl[0]);
			controlsPanel.Controls.Remove(btn[0]);
			controlsPanel.Controls.Remove(rm[0]);
			lbl[0].Dispose();
			btn[0].Dispose();
			rm[0].Dispose();

			updateCountLabel();
			updateItemCountLabel();
			statistics.deleteItem(statName);
			ActiveControl = txtStatisticsName;
			menuSave.Enabled = true;
		}

		/// <summary>
		/// Statistics have changed, update total count
		/// </summary>
		void updateCountLabel()
		{
			lblTotNum.Text = "Total count: " + statistics.getTotalCount();
		}

		/// <summary>
		/// Statistics have changed, update total count
		/// </summary>
		void updateItemCountLabel()
		{
			lblTotItems.Text = "Total itemcount: " + statistics.getTotalItemCount();
		}

		/// <summary>
		/// Create a new statisticsitem based on text given i textbox
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnNew_Click(object sender, EventArgs e)
		{
			statistics.addItem(createNewStatControls(null));
			statistics.addAutoCompleteItem(txtStatisticsName.Text);
			txtStatisticsName.Text = "";
			controlsPanel.Controls.Clear();
			populateStatisticsControls();
			updateCountLabel();
			updateItemCountLabel();
			menuSave.Enabled = true;
		}

		/// <summary>
		/// Save statistics when application is closing
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic FormClosingEventArgs</param>
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			statistics.Comments = txtComment.Text;
			new FileHandler().Write(statistics);
		}

		/// <summary>
		/// Removes all existing statistics and saves a new file
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuClear_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Sure to clear all statistics?", "Clear?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				statistics.Clear();
				txtComment.Text = "";
			}
			new FileHandler().Write(statistics);
			controlsPanel.Controls.Clear();
			updateCountLabel();
			updateItemCountLabel();
			menuSave.Enabled = false;
		}

		/// <summary>
		/// Closes the application
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Saves the current statistics
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuSave_Click(object sender, EventArgs e)
		{
			statistics.Comments = txtComment.Text;
			new FileHandler().Write(statistics);
			menuSave.Enabled = false;
		}

		/// <summary>
		/// Open a dialog to save all statistics to a separate file
		/// Clears statistics after saving
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuSaveAt_Click(object sender, EventArgs e)
		{
			DateTime today = DateTime.Today;
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Title = "Location for saving statistics";
			dialog.FileName = "Statistics of " + today.Year + " " + today.ToString("MMM") + ".xml";
			
			if (dialog.ShowDialog() == DialogResult.OK) {
				new FileHandler().Write(statistics, dialog.FileName);
				if (MessageBox.Show("Clear statistics?", "Clear?", MessageBoxButtons.YesNo) == DialogResult.Yes)
					statistics.Clear();
			}
			
			menuSave.Enabled = false;
		}

		/// <summary>
		/// A comment have been added/change, enable menuitem for saving
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtComment_TextChanged(object sender, EventArgs e)
		{
			menuSave.Enabled = true;
		}

		/// <summary>
		/// A new name is entered, enable button for creating statistics
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtStatisticsName_TextChanged(object sender, EventArgs e)
		{
			btnNew.Enabled = txtStatisticsName.Text.Length > 0;
		}

		/// <summary>
		/// Save the statistics as a readable textfile
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuSaveAsText_Click(object sender, EventArgs e)
		{
			statistics.Comments = txtComment.Text;
			new FileHandler().WriteTextFile(statistics);
		}
	}
}
