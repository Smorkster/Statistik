using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Statistics
{

	/// <summary>
	/// Description of FileHandler.
	/// </summary>
	public class FileHandler
	{
		AutoCompleteStringCollection autocompletelist = new AutoCompleteStringCollection();

		/// <summary>
		/// Reads XML-file with saved statisticts
		/// </summary>
		/// <returns>Statisticsobject from data in file</returns>
		public static Statistics Read()
		{
			string file = @"H:\Statistics.xml";
			Statistics s = new Statistics();
			if (File.Exists(file)) {
				try {
					XDocument doc = XDocument.Load(file);
					foreach (XElement e in doc.Descendants("statisticsitem")) {
						StatisticsItem si = new StatisticsItem(e.Value, int.Parse(e.Attribute("count").Value));

						s.addItem(si);
					}
					foreach (XElement e in doc.Descendants("comments")) {
						s.Comments = e.Value;
					}

					return s;
				} catch (IOException e) {
					MessageBox.Show("Error reading file (" + file + ")\r\n\r\n" + e.Message);
					return s;
				}
			}
			return null;
		}

		/// <summary>
		/// Reads the file for a list of items to be used for autocompletion
		/// </summary>
		/// <returns>A list of autocompletionitems</returns>
		public AutoCompleteStringCollection getAutoCompleteList()
		{
			string file = @"H:\StatisticsAutoComplete.xml";
			if (File.Exists(file)) {
				try {
					XDocument doc = XDocument.Load(file);
					foreach (XElement e in doc.Descendants("sacitem")) {
						autocompletelist.Add(e.Value);
					}
				} catch (IOException e) {
					MessageBox.Show("Error reading file (" + file + ")\r\n\r\n" + e.Message);
				}
			}
			return autocompletelist;
		}

		/// <summary>
		/// Writes the statistics to an XML-file
		/// </summary>
		/// <param name="statistics">All statistics</param>
		public void Write(Statistics statistics)
		{
			Write(statistics, @"H:\Statistics.xml");
		}

		/// <summary>
		/// Writing all files
		/// </summary>
		/// <param name="stats">The statistics to be saved</param>
		/// <param name="filename">Name and location of where to save the statistics</param>
		public static void Write(Statistics stats, string filename)
		{
			try {
				XDocument doc = new XDocument(), autocompletedoc = new XDocument();
				doc.Declaration = new XDeclaration("1.0", "utf8", "yes");
				autocompletedoc.Declaration = new XDeclaration("1.0", "utf8", "yes");

				XElement root = new XElement("statistics"),
				rootautocomplete = new XElement("saclist");

				doc.Add(root);
				autocompletedoc.Add(rootautocomplete);

				foreach (StatisticsItem si in stats.getItemList()) {
					XElement stat = new XElement("statisticsitem", new XAttribute("count", si.ItemCount));
					stat.Value = si.ItemName;
					doc.Element("statistics").Add(stat);
				}
				if (!stats.Comments.Equals("")) {
					XElement comments = new XElement("comments");
					comments.Value = stats.Comments;
					doc.Element("statistics").Add(comments);
				}

				foreach (var item in stats.getAutoCompleteList()) {
					XElement aci = new XElement("sacitem");
					aci.Value = item.ToString();
					autocompletedoc.Element("saclist").Add(aci);
				}

				doc.Save(filename);
				autocompletedoc.Save(@"H:\StatisticsAutoComplete.xml");
			} catch (IOException e) {
				MessageBox.Show("Error while writing statisticsfile:\r\n\r\n" + e.Message, string.Empty);
			}
		}

		/// <summary>
		/// Write the statistics to a readable textfile
		/// </summary>
		public static void WriteTextFile(Statistics stats)
		{
			string text = stats.Comments + "\n";
			text = text + "********************************\n\n===== Collected statistics =====";
			foreach (StatisticsItem si in stats.getItemList()) {
				text = text + si.ItemName + ": " + si.ItemCount + "\n";
			}
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Where to save textfile?";
			sfd.FileName = "Statistics.txt";
			sfd.DefaultExt = "txt";
			sfd.ShowDialog();
			
			File.WriteAllText(sfd.FileName, text);
		}
	}
}
