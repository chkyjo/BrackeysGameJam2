using UnityEngine;

public class ItemsManager : MonoBehaviour{

    int numItems = 7;
    Item[] itemsList;
    public ItemObject[] itemObjectList;

    // Start is called before the first frame update
    void Awake(){
        InitializeItemsList();
    }

    public Item GetItem(ItemId itemId) {
        return itemsList[(int)itemId];
    }

    void InitializeItemsList() {
        itemsList = new Item[numItems];

        for(int index = 0; index < numItems; index++) {
            Debug.Log(index);
            itemsList[index] = new Item();
            itemsList[index].itemConfig = itemObjectList[index];
        }

    }
}

public enum ItemType {
    Tool,
    Throwable,
    Journal
}

public enum ItemId {
    noTool,
    Tool1,
    Tool2,
    Tool3,
    Journal1,
    Journal2,
    Journal3,

}
