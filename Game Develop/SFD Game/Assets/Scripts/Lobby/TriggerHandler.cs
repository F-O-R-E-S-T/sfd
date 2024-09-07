using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerHandler : MonoBehaviour
{
    public GameObject objectToToggle;  // Objeto que aparecerá y desaparecerá
    public string sceneToLoad;  // Nombre de la escena que se cargará
    private bool isPlayerInside = false;  // Bandera para verificar si el jugador está dentro del trigger

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToToggle.SetActive(true);
            isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToToggle.SetActive(false);
            isPlayerInside = false;
        }
    }

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}