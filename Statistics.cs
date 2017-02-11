using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Statistics
{
	public class Statistics
	{
		List<StatisticsItem> allstatistics;
		string comments = "";
		AutoCompleteStringCollection autocompletelist;

		public Statistics()
		{
			allstatistics = new List<StatisticsItem>();
			autocompletelist = new AutoCompleteStringCollection();
		}

		public string Comments {
			get {
				return comments;
			}
			set {
				comments = value;
			}
		}

		/// <summary>
		/// Adds a new item
		/// </summary>
		/// <param name="item">Statistics item to add</param>
		public void addItem(StatisticsItem item)
		{
			allstatistics.Add(item);
		}

		/// <summary>
		/// Creates and adds a new item
		/// </summary>
		/// <param name="name">Name of item to create</param>
		public void addItem(string name)
		{
			allstatistics.Add(new StatisticsItem(name,1));
			allstatistics = allstatistics.OrderBy(x => x.ItemName).ToList();
		}

		/// <summary>
		/// Compare the listitems for where to insert a new item alphabeticaly 
		/// </summary>
		/// <param name="text">New item to insert</param>
		public void addAutoCompleteItem(string text)
		{
			if (!autocompletelist.Contains(text)) {
				int i = 0;
				foreach (string item in autocompletelist) {
					// disable once StringCompareIsCultureSpecific
					if (string.Compare(text, item) == -1) {
						autocompletelist.Insert(i, text);
						return;
					}
					i++;
				}
			}
		}

		/// <summary>
		/// Adds a list of items to be used for autocompletion of statisticsnames
		/// </summary>
		/// <param name="l">The list of autocompletionitems</param>
		public void addAutoCompleteList(AutoCompleteStringCollection l)
		{
			autocompletelist = l;
		}

		/// <summary>
		/// Deletes an item
		/// </summary>
		/// <param name="name">Name of item to delete</param>
		public void deleteItem(string name)
		{
			int index = allstatistics.FindIndex(x => x.ItemName.Equals(name));
			if (index != -1)
				allstatistics.RemoveAt(index);
		}

		/// <summary>
		/// Returns the list for autocompletion
		/// </summary>
		/// <returns>The list</returns>
		public AutoCompleteStringCollection getAutoCompleteList()
		{
			return autocompletelist;
		}

		/// <summary>
		/// Returns total number of staticsitems
		/// Used for listing controls
		/// </summary>
		/// <returns>Total number of staticsitems</returns>
		public int numberOfItems()
		{
			return allstatistics.Count();
		}

		/// <summary>
		/// Statics has increased, add to the existing count
		/// </summary>
		/// <param name="name">Name of statistics to increase</param>
		/// <returns>New increased number of the statistics</returns>
		public int countAdded(string name)
		{
			int index = allstatistics.FindIndex(x => x.ItemName.Equals(name));
			
			allstatistics[index].AddItemCount();
			return allstatistics[index].ItemCount;
		}

		/// <summary>
		/// Statics has decreased, subtract to the existing count
		/// </summary>
		/// <param name="name">Name of statistics to decrease</param>
		/// <returns>New decreased number of the statistics</returns>
		public int countSubtracted(string name)
		{
			int index = allstatistics.FindIndex(x => x.ItemName.Equals(name));
			
			allstatistics[index].SubtractItemCount();
			return allstatistics[index].ItemCount;
		}

		/// <summary>
		/// Checks if a statics already exists
		/// </summary>
		/// <param name="name">Name of statistics to check</param>
		/// <returns>True if statistics exists, otherwise False</returns>
		public bool itemExists(string name)
		{
			return allstatistics.Exists(x => x.ItemName.Equals(name));
		}

		/// <summary>
		/// Returns the whole list of statistics
		/// </summary>
		/// <returns>List of statistics</returns>
		public List<StatisticsItem> getItemList()
		{
			return allstatistics;
		}

		/// <summary>
		/// Returns the number of occurences of a specific statistics
		/// </summary>
		/// <param name="name">Name of statistics</param>
		/// <returns>Numbers of occurrences of statistics</returns>
		public int getCounts(string name)
		{
			StatisticsItem item = allstatistics.Find(x => x.ItemName.Equals(name));
			return item.ItemCount;
		}

		/// <summary>
		/// Returns an integer with full total of all counts from all statisticsitems
		/// </summary>
		/// <returns>Totalcount</returns>
		public int getTotalCount()
		{
			int t = 0;
			foreach (StatisticsItem i in allstatistics) {
				t = t + i.ItemCount; 
			}
			return t;
		}

		/// <summary>
		/// Return an integer of number of statisticsitems
		/// </summary>
		/// <returns>Number of statisticsitems</returns>
		public int getTotalItemCount()
		{
			return allstatistics.Count();
		}

		/// <summary>
		/// Clears all statistics
		/// </summary>
		public void Clear()
		{
			allstatistics.Clear();
			Comments = "";
		}
	}
}
