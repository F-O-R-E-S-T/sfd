using UnityEngine;
using UnityEngine.UI;

namespace ZombiesMinigame
{
    public class WeaponSelectorUI : MonoBehaviour
    {
        [SerializeField] private Button _gunButton;
        [SerializeField] private Button _orbsButton;

        [SerializeField] private CreateOrbs _createOrbs;
        [SerializeField] private SpawnOnHold _spawnOnHold;

        private void Awake()
        {
            Time.timeScale = 0;

            _gunButton.onClick.AddListener(() => {
                Time.timeScale = 1;
                _spawnOnHold.enabled = true;
                gameObject.SetActive(false);
            });

            _orbsButton.onClick.AddListener(() => {
                Time.timeScale = 1;
                _createOrbs.enabled = true;
                gameObject.SetActive(false);
            });


        }
    }
}


