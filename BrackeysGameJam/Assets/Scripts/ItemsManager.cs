using UnityEngine;

public class ItemsManager : MonoBehaviour{

    ItemScriptableObject[] itemsList;

    // Start is called before the first frame update
    void Awake(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ItemId {
    noTool,
    Tool1,
    Tool2,
    Tool3
}
