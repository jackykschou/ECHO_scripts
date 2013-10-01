using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static Collectable[] items = new Collectable[3];
	
	public static void UseItem(int index)
	{
		items[index] = null;
	}
	
	public static void ClearItmes()
	{
		for(int i = 0; i < 3; ++i)
		{
			items[i] = null;	
		}
	}
}
