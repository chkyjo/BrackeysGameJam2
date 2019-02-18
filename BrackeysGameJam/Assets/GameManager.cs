using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public GameObject interactUI;
    public GameObject journalPanel;
    public GameObject inventoryPanel;
    public GameObject pauseMenu;

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

    public void Quit() {
        Application.Quit();
    }
}
