using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public GameObject interactUI;

    public void EnableInteractUI() {
        interactUI.SetActive(true);
    }

    public void DisableInteractUI() {
        interactUI.SetActive(false);
    }
}
