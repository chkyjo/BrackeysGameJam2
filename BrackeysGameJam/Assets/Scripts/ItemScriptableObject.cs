using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class ItemScriptableObject : ScriptableObject{

    public ItemId itemId;
    public Texture2D icon;

}
