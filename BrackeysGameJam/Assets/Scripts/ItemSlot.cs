using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour{

    Item _item;

    public void SetItem(Item item) {
        _item = item;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = item.itemConfig.icon;
    }

    public void ClearSlot() {
        _item = null;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    public bool IsEmpty() {
        if(_item == null) {
            return true;
        }

        return false;
    }
}
