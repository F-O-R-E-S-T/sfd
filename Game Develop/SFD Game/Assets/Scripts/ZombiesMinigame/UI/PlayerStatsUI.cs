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
        _damageText.text = "Damage = " + playerStats.Damage;
        _moveSpeedText.text = "Move Speed = " + playerStats.MoveSpeed;
        _attackSpeedText.text = "Attack Speed = " + playerStats.AttackSpeed;
    }
}
