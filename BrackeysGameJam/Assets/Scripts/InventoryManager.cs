using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour{
    public GameObject inventoryPanel;

    public void AddItemToInventory(ItemScriptableObject item) {

        Transform slotsPanel = inventoryPanel.transform.GetChild(0);
        for(int slotIndex = 0; slotIndex < slotsPanel.childCount; slotIndex++) {
            if (slotsPanel.GetChild(slotIndex).GetComponent<ItemSlot>().IsEmpty()) {
                slotsPanel.GetChild(slotIndex).GetComponent<ItemSlot>().SetItem(item);
                return;
            }
        }

        Debug.Log("No room");
    }
}
