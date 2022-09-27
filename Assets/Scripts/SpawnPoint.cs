using TMPro;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffset;

    private TMP_Text _textError;
    private GameObject _towerToBuild;
    private Color _startColor;
    private Renderer _renderer;
    private GameObject _tower;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    private void OnMouseDown()
    {
        if (_tower != null)
        {
            return;
        }

        _towerToBuild = BuildManager.Instance.GetTowerToBuild();

        if (_towerToBuild == null)
        {
            return;
        }

        _tower = Instantiate(_towerToBuild, transform.position + _positionOffset, Quaternion.identity);
        BuildManager.Instance.RemoveTower();
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
