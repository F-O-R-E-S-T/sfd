using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private GameObject _objectToToggle;
    [SerializeField] private string _sceneToLoad;
    private bool _isPlayerInside = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _objectToToggle.SetActive(true);
            _isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _objectToToggle.SetActive(false);
            _isPlayerInside = false;
        }
    }

    void Update()
    {
        if (_isPlayerInside && Input.GetKeyDown(KeyCode.Space))
        {
            LoadGame(_sceneToLoad);
        }
    }

    public void LoadGame(string sceneToLoad)
    {
        StartCoroutine(LoadLobbyAsync(sceneToLoad));
    }

    private IEnumerator LoadLobbyAsync(string sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}