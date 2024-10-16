using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    private float _elapsedTime = 0f;

    [SerializeField] private GameObject _habilityPanel;

    private float _nextTimeToActivatePanel = 60f;

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        UpdateTimeText();

        if (_elapsedTime >= _nextTimeToActivatePanel)
        {
            _habilityPanel.SetActive(true);
            _nextTimeToActivatePanel += 60f;
        }
    }

    public void SceneLoading(string sceneToLoad)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(_elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60F);
        int milliseconds = Mathf.FloorToInt((_elapsedTime * 1000F) % 1000F);

        _timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}