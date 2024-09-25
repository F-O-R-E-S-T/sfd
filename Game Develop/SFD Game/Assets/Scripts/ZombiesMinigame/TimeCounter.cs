using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // Referencia al objeto de texto TextMeshPro
    private float elapsedTime = 0f;  // Tiempo transcurrido

    [SerializeField] private GameObject _habilityPanel;

    private float nextTimeToActivatePanel = 60f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimeText();

        if (elapsedTime >= nextTimeToActivatePanel)
        {
            _habilityPanel.SetActive(true);
            nextTimeToActivatePanel += 60f;  // Incrementar para esperar otro minuto
        }
    }

    public void SceneLoading(string sceneToLoad)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000F) % 1000F);

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}