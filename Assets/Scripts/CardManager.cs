using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Card _cardScriptableObject;
    private Transform _draggingParent;
    private Transform _previousParent;
    //private GameObject _draggingBuilding;
    //private Building _building;
    //private Vector2Int _gridSize = new Vector2Int(15, 10);
    //private bool _isAvialableToBuild;
    //private GridController _gridController;

    //public Card CardScriptableObject => _cardScriptableObject;

    //private void Awake()
    //{
    //    _gridController = GridController.Instance;
    //    _gridController.InstalGrid(_gridSize);
    //}

    public void InstalCard(Card card)
    {
        _cardScriptableObject = card;
    }

    public void Init(Transform dragingParent)
    {
        _draggingParent = dragingParent;
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (_draggingBuilding != null)
    //    {
    //        var groundPlane = new Plane(Vector3.up, Vector3.zero);
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if (groundPlane.Raycast(ray, out float position))
    //        {
    //            Vector3 worldPosition = ray.GetPoint(position);
    //            int x = Mathf.RoundToInt(worldPosition.x);
    //            int z = Mathf.RoundToInt(worldPosition.z);

    //            if (x < 0 || x > _gridSize.x - _building.BuildingSize.x)
    //            {
    //                _isAvialableToBuild = false;
    //            }
    //            else if (z < 0 || z > _gridSize.y - _building.BuildingSize.y)
    //            {
    //                _isAvialableToBuild = false;
    //            }
    //            else
    //            {
    //                _isAvialableToBuild = true;
    //            }

    //            if (_isAvialableToBuild && IsPlaceTaken(x,z))
    //            {
    //                _isAvialableToBuild = false;
    //            }

    //            if ((x % 2 == 1) || (z % 2 == 1))
    //            {
    //                _isAvialableToBuild = false;
    //            }

    //            _draggingBuilding.transform.position = new Vector3(x, 0, z);

    //            _building.SetColor(_isAvialableToBuild);
    //        }
    //    }
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    _draggingBuilding = Instantiate(_cardScriptableObject.Prefab, Vector3.zero, Quaternion.identity);

    //    _building = _draggingBuilding.GetComponent<Building>();

    //    var groundPlane = new Plane(Vector3.up, Vector3.zero);
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (groundPlane.Raycast(ray, out float position))
    //    {
    //        Vector3 worldPosition = ray.GetPoint(position);
    //        int x = Mathf.RoundToInt(worldPosition.x);
    //        int z = Mathf.RoundToInt(worldPosition.z);

    //        _draggingBuilding.transform.position = new Vector3(x, 0, z);
    //    }
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    if (!_isAvialableToBuild)
    //    {
    //        Destroy(_draggingBuilding);
    //    }
    //    else
    //    {
    //        _gridController.Grid[(int)_draggingBuilding.transform.position.x, (int)_draggingBuilding.transform.position.z] = _building;
    //        _building.ResetColor();
    //    }
    //}

    //private bool IsPlaceTaken(int x, int z)
    //{
    //    if (_gridController.Grid[x,z] != null)
    //    {
    //        return true;
    //    }

    //    return false;
    //}
    public void OnBeginDrag(PointerEventData eventData)
    {
        _previousParent = transform.parent;
        transform.parent = _draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = _previousParent;
    }
}
