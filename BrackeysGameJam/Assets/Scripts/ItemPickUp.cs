using UnityEngine;

public class ItemPickUp : MonoBehaviour{

    public ItemScriptableObject item;

    public void PickUpItem() {

        //play pick up audio
        GameObject player = GameObject.Find("Player");
        player.GetComponent<AudioSource>().clip = GameObject.Find("GameManager").GetComponent<AudioManager>().GetAudio(ClipIds.ItemPickUp);
        player.GetComponent<AudioSource>().Play();

        GameObject.Find("GameManager").GetComponent<InventoryManager>().AddItemToInventory(item);

        

        Destroy(gameObject);
        return;
    }
}
