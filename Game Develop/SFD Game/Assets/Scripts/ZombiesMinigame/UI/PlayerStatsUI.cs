using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _moveSpeedText;
    [SerializeField] private TextMeshProUGUI _attackSpeedText;

    private void Update()
    {
        _damageText.text = "Damage = " + Mathf.Ceil(_playerStats.Damage);
        _moveSpeedText.text = "Move Speed = " + Mathf.Ceil(_playerStats.MoveSpeed);
        _attackSpeedText.text = "Attack Speed = " + Mathf.Ceil(_playerStats.AttackSpeed);
    }
}
