
using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistik
{
	public class Statistics
	{
		List<StatisticsItem> allstatistics;

		public Statistics()
		{
			allstatistics = new List<StatisticsItem>();
		}

		public void addItem(StatisticsItem item)
		{
			allstatistics.Add(item);
		}

		public void addItem(string name)
		{
			allstatistics.Add(new StatisticsItem(name));
		}

		public void deleteItem(string name)
		{
			int index = allstatistics.FindIndex(x => x.ItemName.Equals(name));
			if(index != -1)
				allstatistics.RemoveAt(index);
		}

		public int numberOfItems()
		{
			return allstatistics.Count();
		}

		public int countAdded(string name)
		{
			int index = allstatistics.FindIndex(x => x.ItemName.Equals(name));
			
			allstatistics[index].ItemCount++;
			return allstatistics[index].ItemCount;
		}

		public int countSubtracted (string name)
		{
			int index = allstatistics.FindIndex(x => x.ItemName.Equals(name));
			
			allstatistics[index].ItemCount--;
			return allstatistics[index].ItemCount;
		}

		public bool itemExists(string name)
		{
			return allstatistics.Exists(x => x.ItemName.Equals(name));
		}

		public List<StatisticsItem> getItemList ()
		{
			return allstatistics;
		}

		public int getCounts (string text)
		{
			StatisticsItem item = allstatistics.Find(x => x.ItemName.Equals(text));
			return item.ItemCount;
		}
	}
}
