using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    public void UpdateHealthUI(float value)
    {
        _healthSlider.value = value;
    }
}
