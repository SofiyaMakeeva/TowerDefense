using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Tower _tower;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _text.text = _tower.Price.ToString();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (_player.Money >= _tower.Price && BuildManager.Instance.TowerToBuild == null)
        {
            BuildManager.Instance.InstallTower(_tower.gameObject);
            _player.ChangeMoneyValue(-_tower.Price);
        }
    }
}
