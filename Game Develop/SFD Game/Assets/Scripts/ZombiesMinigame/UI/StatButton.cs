using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButton : StatsUI
{
    public enum StatType
    {
        Damage,
        AttackSpeed,
        MoveSpeed
    }

    public StatType statType = StatType.Damage;


    [SerializeField] private Button _statButton;
    [SerializeField] private float _statPercentage;
    [SerializeField] private StatSelectorUI _statSelector;

    private void Awake()
    {
        _statButton.onClick.AddListener(() => AddStatValue(_statPercentage));
        _statSelector = FindObjectOfType<StatSelectorUI>();
    }

    public override void AddStatValue(float percentage)
    {
        if(statType == StatType.Damage)
        {
            _statSelector.AddPlayerDamage(percentage);
        }
        else if(statType == StatType.AttackSpeed)
        {
            _statSelector.AddPlayerAttackSpeed(percentage);

        }else if(statType == StatType.MoveSpeed)
        {
            _statSelector.AddPlayerMoveSpeed(percentage);
        }

        _statSelector.DestroyButtons();
        _statSelector.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
