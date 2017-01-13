﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Statistik
{
	/// <summary>
	/// Description of FileHandler.
	/// </summary>
	public class FileHandler
	{
		public FileHandler()
		{
		}
		
		public Statistics read ()
		{
			int i=0;
			Statistics s = new Statistics();
			if (File.Exists(@"H:\Statistics.xml"))
			{
				try
				{
					XDocument doc = XDocument.Load(@"H:\Statistics.xml");
					foreach (XElement e in doc.Descendants("statisticsitem"))
					{
						i = 1;
						StatisticsItem si = new StatisticsItem(e.Value);
						i = 2;
						si.ItemCount = int.Parse(e.Attribute("count").Value);

						s.addItem(si);
					}
					return s;
				} catch (Exception e)
				{
					MessageBox.Show("Error reading file (" + i + ")\r\n\r\n"+ e.Message);
					return s;
				}
			}
			return null;
		}

		public void write (Statistics statistics)
		{
			try
			{
				XDocument doc = new XDocument();
				doc.Declaration = new XDeclaration("1.0", "utf8", "yes");
				XElement root = new XElement("statistics");

				doc.Add(root);
				foreach (StatisticsItem si in statistics.getItemList())
				{
					XElement stat = new XElement("statisticsitem", new XAttribute("count", si.ItemCount));
					stat.Value = si.ItemName;
					doc.Element("statistics").Add(stat);
				}
				doc.Save(@"H:\Statistics.xml");
			}catch(IOException e){
				MessageBox.Show("Error while writing statisticsfile\r\n\r\n" + e.Message, "");
			}
		}
	}
}