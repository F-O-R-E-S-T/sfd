using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _moveSpeedText;
    [SerializeField] private TextMeshProUGUI _attackSpeedText;

    private void Update()
    {
        _damageText.text = "Damage = " + Mathf.Ceil(playerStats.Damage);
        _moveSpeedText.text = "Move Speed = " + Mathf.Ceil(playerStats.MoveSpeed);
        _attackSpeedText.text = "Attack Speed = " + Mathf.Ceil(playerStats.AttackSpeed);
    }
}
