using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private GameObject _towerPrefab;

    public static BuildManager Instance;

    private GameObject _towerToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one BuildManager in scene");
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _towerToBuild = _towerPrefab;
    }

    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }
}
