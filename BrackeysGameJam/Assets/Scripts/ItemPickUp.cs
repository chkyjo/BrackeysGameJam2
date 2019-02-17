using UnityEngine;

public class ItemPickUp : MonoBehaviour{

    public ItemId itemToGet;
    public Item _item;

    private void Start() {
        //if there is an itemToGet assigned meaning an item needs to be grabbed from the itemsManager
        if(itemToGet != ItemId.noTool) {
            _item = GameObject.Find("GameManager").GetComponent<ItemsManager>().GetItem(itemToGet);
        }
    }

    public void SetItem(Item item) {
        _item = item;
    }

    public void PickUpItem() {

        //play pick up audio
        GameObject player = GameObject.Find("Player");
        player.GetComponent<AudioSource>().clip = GameObject.Find("GameManager").GetComponent<AudioManager>().GetAudio(ClipIds.ItemPickUp);
        player.GetComponent<AudioSource>().Play();

        GameObject.Find("GameManager").GetComponent<InventoryManager>().AddItemToInventory(_item);

        

        Destroy(gameObject);
        return;
    }
}
