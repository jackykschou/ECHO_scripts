using UnityEngine;
using System.Collections;

public class FlashLight : Interactable {
	
	public GameObject darkness;
	public GameObject flash_light;
	int battery_index;
	
	public override void StartInteractionHook()
	{
		Inventory.UseItem(battery_index);
		flash_light.SetActive(true);
		darkness.SetActive(false);
	}
	
	public override bool CheckInteractable()
	{
		int i = 0;
		bool own_battery = false;
		foreach(Collectable c in Inventory.items)
		{
			if(c != null && c.collectable_name == "battery")
			{
				own_battery = true;
				battery_index = i;
			}
			++i;
		}
		return own_battery;
	}
}
