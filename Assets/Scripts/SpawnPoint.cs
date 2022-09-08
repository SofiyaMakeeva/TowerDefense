using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffset;

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
            Debug.Log("Cant build there");
            return;
        }

        _towerToBuild = BuildManager.Instance.GetTowerToBuild();
        _tower = Instantiate(_towerToBuild, transform.position + _positionOffset, Quaternion.identity);
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
