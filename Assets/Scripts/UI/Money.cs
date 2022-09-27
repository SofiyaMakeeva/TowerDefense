using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _money;

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanded;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanded;
    }

    private void OnMoneyChanded(int value)
    {
        _money.text = value.ToString();
    }
}
