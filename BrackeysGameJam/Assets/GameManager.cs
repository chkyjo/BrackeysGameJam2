using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public GameObject interactUI;
    public GameObject journalPanel;
    public GameObject inventoryPanel;
    public GameObject pauseMenu;

    public GameObject floor;

    private void Update() {
        if (Input.GetKeyDown("escape")) {
            if (pauseMenu.activeInHierarchy) {
                pauseMenu.SetActive(false);
                PlayerController.instance.ResumeRotation();
            }
            else {
                pauseMenu.SetActive(true);
                PlayerController.instance.StopRotation();
            }
        }
        if (Input.GetKeyDown("i")) {
            if (inventoryPanel.activeInHierarchy) {
                inventoryPanel.SetActive(false);
                PlayerController.instance.ResumeRotation();
            }
            else {
                inventoryPanel.SetActive(true);
                PlayerController.instance.StopRotation();
            }
        }
    }

    public void EnableInteractUI() {
        interactUI.SetActive(true);
    }

    public void DisableInteractUI() {
        interactUI.SetActive(false);
    }

    public void OpenJournal(Journal journal) {
        journalPanel.SetActive(true);
        journalPanel.transform.GetChild(0).GetComponent<Text>().text = ((JournalObject)journal.itemConfig).text;
    }

    public void UpdateScanLocation(Vector3 location) {
        Debug.Log("Updating scan location to " + location);
        Vector4 newLocation = new Vector4(location.x, location.y, location.z, 1);
        floor.GetComponent<Renderer>().sharedMaterial.SetVector("_Center", location);
    }

    public void Quit() {
        Application.Quit();
    }

}
