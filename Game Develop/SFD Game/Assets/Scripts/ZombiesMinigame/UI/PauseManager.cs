using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button _goToMainMenuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _configurationButton;

    [SerializeField] private Button _reloadGameButton;

    [SerializeField] private GameObject _configurationPanel;

    private void Awake()
    {
        _goToMainMenuButton.onClick.AddListener(() => LoadSceneAsync("Lobby"));
        _restartButton.onClick.AddListener(() => LoadSceneAsync("1. ZombiesGame"));
        _configurationButton.onClick.AddListener(() => _configurationPanel.SetActive(true));
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            Debug.Log("Progreso de la carga: " + (asyncLoad.progress * 100) + "%");
            yield return null;
        }
    }

    public void SetExecutionTime(float time)
    {
        Time.timeScale = time;
    }
}
