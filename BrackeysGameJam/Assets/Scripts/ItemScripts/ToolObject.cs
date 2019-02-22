using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Inventory/Tool")]
public class ToolObject : ItemObject{

    public float scanDelay;
    public Color scanColor;
    public AudioClip scanSound;
    

}
