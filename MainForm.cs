
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Statistik
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Statistics statistics = new Statistics();
		int i = 0;
		public MainForm()
		{
			InitializeComponent();
			statistics = new FileHandler().Read();
			populateStatistics();
		}

		void populateStatistics ()
		{
			foreach (StatisticsItem si in statistics.getItemList())
			{
				createNewStat(si);
			}
		}

		string createNewStat (StatisticsItem si)
		{
			string name = "";
			int count = 0;
			bool askForNewName = true;
			i++;
			if (si == null)
			{
				NewItemName nin = new NewItemName();

				while (askForNewName)
				{
					nin.ShowDialog();
					if (nin.DialogResult == DialogResult.Cancel)
					{
						return null;
					}
					if (!statistics.itemExists(nin.getName()))
					{
						name = nin.getName();
						count = 0;
						askForNewName = false;
					}
				}
			} else
			{
				name = si.ItemName;
				count = si.ItemCount;
			}

			Button newRemove = new Button();
			newRemove.Location = new Point(0, (i * 30) - 5);
			newRemove.Name = "rm" + name;
			newRemove.Text = "Remove";
			newRemove.Click += removeStat;
			newRemove.FlatStyle = FlatStyle.Flat;
			newRemove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			newRemove.AutoSize = true;

			Label newLabel = new Label();
			newLabel.Location = new Point(60, i * 30);
			newLabel.Size = new Size(25, 15);
			newLabel.TextAlign = ContentAlignment.MiddleCenter;
			newLabel.Text = count.ToString();
			newLabel.Name = "lb" + name;

			Button newButton = new Button();
			newButton.Location = new Point(120, (i * 30) - 5);
			newButton.Text = name;
			newButton.Name = "btn" + name;
			newButton.MouseDown += moreStatistics;
			newButton.FlatStyle = FlatStyle.Flat;
			newButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			newButton.AutoSize = true;

			SuspendLayout();
			flowLayoutPanel.Controls.Add(newRemove);
			flowLayoutPanel.Controls.Add(newLabel);
			flowLayoutPanel.Controls.Add(newButton);
			flowLayoutPanel.SetFlowBreak(newButton, true);
			ResumeLayout(false);
			return name;
		}

		void menuClose_Click (object sender, EventArgs e)
		{
			Application.Exit();
		}
		void menuNew_Click (object sender, EventArgs e)
		{
			statistics.addItem(createNewStat(null));
		}

		public void moreStatistics (object sender, MouseEventArgs e)
		{
			string labelName = "lb" + (sender as Button).Text;
			MouseEventArgs ea = (MouseEventArgs) e;
			if (e.Button == MouseButtons.Right)
				statistics.countSubtracted((sender as Button).Text);
			else
				statistics.countAdded((sender as Button).Text);
			
			int number = statistics.getCounts((sender as Button).Text);
			flowLayoutPanel.Controls.Find(labelName, true)[0].Text = number.ToString();
		}

		void menuSave_Click (object sender, EventArgs e)
		{
			new FileHandler().Write(statistics);
		}

		public void removeStat (object sender, EventArgs ea)
		{
			string statName = (sender as Button).Name.Substring(2);
			string labelName = "lb" + statName;
			string buttonName = "btn" + statName;
			string removeName = "rm" + statName;
			
			Control[] lbl = flowLayoutPanel.Controls.Find(labelName, true);
			Control[] btn = flowLayoutPanel.Controls.Find(buttonName, true);
			Control[] rm = flowLayoutPanel.Controls.Find(removeName, true);
			flowLayoutPanel.Controls.Remove(lbl[0]);
			flowLayoutPanel.Controls.Remove(btn[0]);
			flowLayoutPanel.Controls.Remove(rm[0]);
			lbl[0].Dispose();
			btn[0].Dispose();
			rm[0].Dispose();
			
			statistics.deleteItem(statName);
		}
	}
}
