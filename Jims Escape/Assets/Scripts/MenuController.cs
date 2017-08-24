using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void StartGame(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
        loadingScreen.SetActive(true);

    }

    IEnumerator LoadAsync(int sceneIndex) {
        AsyncOperation operaiton = SceneManager.LoadSceneAsync(sceneIndex);
        while (operaiton.isDone == false)
        {
            float progress = Mathf.Clamp01(operaiton.progress /.09f);
            Debug.Log(progress);
            slider.value = progress;
            progressText.text = progress.ToString("R");
            yield return null;
        }

    }

}
