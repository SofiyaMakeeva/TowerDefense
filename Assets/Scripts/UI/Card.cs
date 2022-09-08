using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Card/New card", fileName = "New Card", order = 51)]
public class Card : ScriptableObject
{
    [SerializeField] private Texture _icon;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _price;

    public GameObject Prefab => _prefab;
    public Texture Icon => _icon;
    public int  Price => _price;
}
