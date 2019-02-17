using UnityEngine;

public class ItemPickUp : MonoBehaviour{

    public Item item;

    public void PickUpItem() {
        GameObject.Find("GameManager").GetComponent<InventoryManager>().AddItemToInventory(item);
    }
}
