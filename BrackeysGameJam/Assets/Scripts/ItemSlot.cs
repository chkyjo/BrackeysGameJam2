using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour{

    ItemId itemId;

    private void Start() {
        itemId = ItemId.noTool;
    }

    public void SetItem(Item item) {
        itemId = item.itemId;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = item.icon;
    }

    public void ClearSlot() {
        itemId = 0;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    public bool IsEmpty() {
        if(itemId == ItemId.noTool) {
            return true;
        }

        return false;
    }
}
