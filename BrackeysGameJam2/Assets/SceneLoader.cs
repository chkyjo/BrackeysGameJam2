using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour{

    public GameObject loadingPanel;
    public Slider loadingBar;
    public Text completionText;

    public void LoadLevel(int sceneIndex) {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex) {

        AsyncOperation load = SceneManager.LoadSceneAsync(sceneIndex);
        loadingPanel.SetActive(true);
        float progress;

        while (!load.isDone) {
            progress = Mathf.Clamp01(load.progress / 0.9f);
            loadingBar.value = progress;
            completionText.text = progress * 100f + "%";

            yield return null;
        }

    }

    public void Quit() {
        Application.Quit();
    }
}
