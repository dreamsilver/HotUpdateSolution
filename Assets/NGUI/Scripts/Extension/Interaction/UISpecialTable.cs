﻿using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// All children added to the game object with this script will be repositioned to be on a table of specified dimensions.
/// If you want the cells to automatically set their scale based on the dimensions of their content, take a look at UITable.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Special Table")]
public class UISpecialTable : UITable {

	/// <summary>
	/// Get the current list of the table's children.
	/// </summary>

	public override List<Transform> GetChildList()
	{
		Transform myTrans = transform;
		List<Transform> list = new List<Transform>();

		for (int i = 0; i < myTrans.childCount; ++i)
		{
			Transform t = myTrans.GetChild(i);
			if (!hideInactive || (t && NGUITools.GetActive(t.gameObject) && NGUITools.IsOpaque(t.gameObject)))
				list.Add(t);
		}

		// Sort the list using the desired sorting logic
		if (sorting != Sorting.None)
		{
			if (sorting == Sorting.Alphabetic) list.Sort(UIGrid.SortByName);
			else if (sorting == Sorting.Horizontal) list.Sort(UIGrid.SortHorizontal);
			else if (sorting == Sorting.Vertical) list.Sort(UIGrid.SortVertical);
			else if (onCustomSort != null) list.Sort(onCustomSort);
			else Sort(list);
		}
		return list;
	}
}
