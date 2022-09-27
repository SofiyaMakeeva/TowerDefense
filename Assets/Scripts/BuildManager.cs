using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private GameObject _towerToBuild;

    public static BuildManager Instance;

    public GameObject TowerToBuild => _towerToBuild;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void InstallTower(GameObject tower)
    {
        _towerToBuild = tower;
    }

    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }

    public void RemoveTower()
    {
        _towerToBuild = null;
    }
}
