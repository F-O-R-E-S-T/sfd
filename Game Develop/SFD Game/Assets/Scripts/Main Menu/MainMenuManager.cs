using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        StartCoroutine(LoadLobbyAsync());
    }

    private IEnumerator LoadLobbyAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Lobby");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
