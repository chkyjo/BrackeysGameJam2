using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class ItemObject : ScriptableObject{

    public ItemId itemId;
    public Texture2D icon;
    public ItemType type;

}
