using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private static GridController _instance;
    private Building[,] _grid;

    public static GridController Instance => _instance;
    public Building[,] Grid => _grid;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void InstalGrid(Vector2Int gridSize)
    {
        _grid = new Building[gridSize.x, gridSize.y];
    }
}
