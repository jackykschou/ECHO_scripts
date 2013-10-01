using UnityEngine;
using System.Collections;

public class Nest : Interactable {
	
	public int food_num;
	public GameObject food_prefab1;
	public GameObject food_prefab2;
	
	public override void StartInteractionHook()
	{
		int food_count = 0;
		int i = 0;
		foreach(Collectable c in Inventory.items)
		{
			if(c != null && c.collectable_name == "food")
			{
				++food_count;
				Inventory.UseItem(i);
			}
			++i;
		}
		if(food_count == 1)
		{
			food_prefab1.SetActive(true);
		}
		else if(food_count == 2)
		{
			food_prefab1.SetActive(true);
			food_prefab2.SetActive(true);
		}
		food_num = food_count;
	}
	
	public override bool CheckInteractable()
	{
		int food_count = 0;
		foreach(Collectable c in Inventory.items)
		{
			if(c != null && c.collectable_name == "food")
			{
				++food_count;
			}
		}
		return food_count != 0;
	}
}
