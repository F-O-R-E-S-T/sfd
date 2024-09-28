using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSelectorUI : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private Transform[] _cardTransforms;

    [SerializeField] private GameObject[] _statsButtons;

    private List<GameObject> _instantiatedButtons = new List<GameObject>();

    private void OnEnable()
    {
        CreateButtons();
        Time.timeScale = 0;

    }

    private void CreateButtons()
    {
        foreach (var item in _cardTransforms)
        {
            int randomIndex = Random.Range(0, _statsButtons.Length);
            GameObject randomButton = _statsButtons[randomIndex];

            GameObject instantiatedButton = Instantiate(randomButton, item);

            instantiatedButton.transform.localPosition = Vector3.zero;

            _instantiatedButtons.Add(instantiatedButton);
        }
    }

    public void DestroyButtons()
    {
        foreach (var button in _instantiatedButtons)
        {
            Destroy(button);
        }

        _instantiatedButtons.Clear();
    }

    public void AddPlayerDamage(float percentage)
    {
        float multiplier = 1 + (percentage / 100f);
        _playerStats.Damage = _playerStats.Damage * multiplier;
    }

    public void AddPlayerAttackSpeed(float percentage)
    {
        float multiplier = 1 + (percentage / 100f);
        _playerStats.AttackSpeed = _playerStats.AttackSpeed * multiplier;
    }

    public void AddPlayerMoveSpeed(float percentage)
    {
        float multiplier = 1 + (percentage / 100f);
        _playerStats.MoveSpeed = _playerStats.MoveSpeed * multiplier;
    }
}
