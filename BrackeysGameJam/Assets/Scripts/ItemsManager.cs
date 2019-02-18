using UnityEngine;

public class ItemsManager : MonoBehaviour{

    int numItems = 9;
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

        itemsList[0] = new Item();
        itemsList[1] = new Tool();
        itemsList[2] = new Tool();
        itemsList[3] = new Tool();
        itemsList[4] = new Journal();
        itemsList[5] = new Journal();
        itemsList[6] = new Journal();
        itemsList[7] = new Throwable();
        itemsList[8] = new MusicPlayer();

        for (int index = 0; index < numItems; index++) {
            itemsList[index].itemConfig = itemObjectList[index];
        }

    }
}

public enum ItemType {
    Tool,
    Throwable,
    Journal,
    MusicPlayer
}

public enum ItemId {
    noTool,
    Tool1,
    Tool2,
    Tool3,
    Journal1,
    Journal2,
    Journal3,
    Flare,
    MusicPlayer
}
