using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour{
    public GameObject winPanel;

    void OnTriggerEnter(Collider other) {
        //if(other.GetComponent<PlayerController>() != null) {
            winPanel.SetActive(true);
        //}
        
    }
}
