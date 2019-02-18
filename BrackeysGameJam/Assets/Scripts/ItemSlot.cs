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

    public void Interact() {
        if(_item != null) {
            if(_item.itemConfig.type == ItemType.Tool) {
                //equip tool
                PlayerController.instance.EquipTool((Tool)_item);
                PlayerController.instance.SendScan();
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateScanLocation(PlayerController.instance.transform.position);
            }
            else if(_item.itemConfig.type == ItemType.Throwable) {
                PlayerController.instance.EquipThrowable((Throwable)_item);
            }
            else if (_item.itemConfig.type == ItemType.Journal) {
                GameObject.Find("GameManager").GetComponent<GameManager>().OpenJournal((Journal)_item);
            }
            else if (_item.itemConfig.type == ItemType.MusicPlayer) {
                if(PlayerController.instance.GetComponent<AudioSource>().clip == ((MusicPlayerObject)_item.itemConfig).clip) {
                    PlayerController.instance.StopAudio();
                }
                else {
                    PlayerController.instance.PlayClip((MusicPlayer)_item);
                }
            }
        }
    }

    public bool IsEmpty() {
        if(_item == null) {
            return true;
        }

        return false;
    }
}
