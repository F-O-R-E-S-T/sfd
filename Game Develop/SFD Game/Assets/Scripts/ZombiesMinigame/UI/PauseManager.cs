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

    // M�todo p�blico para iniciar la carga as�ncrona de la escena
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    // Corrutina que se encarga de cargar la escena de forma as�ncrona
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // Inicia la carga as�ncrona de la escena
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Espera hasta que la carga est� completa
        while (!asyncLoad.isDone)
        {
            // Aqu� puedes actualizar una barra de carga o mostrar el progreso de alguna manera
            Debug.Log("Progreso de la carga: " + (asyncLoad.progress * 100) + "%");
            yield return null; // Espera hasta el siguiente frame
        }
    }
}
