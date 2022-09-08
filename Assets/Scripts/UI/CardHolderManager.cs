using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CardManager))]
public class CardHolderManager : MonoBehaviour
{
    [SerializeField] private Transform _cardHolderPosition;
    [SerializeField] private GameObject _card;
    [SerializeField] private Card[] _cardScriptableObject;
    [SerializeField] private Transform _draggingParent;

    private GameObject[] _cards;
    private int _price;
    private Texture _icon;
    private CardManager _cardManager;

    private void Start()
    {
        _cards = new GameObject[_cardScriptableObject.Length];

        for (int i = 0; i < _cardScriptableObject.Length; i++)
        {
            CreateCard(i);
        }
    }

    private void CreateCard(int index)
    {
        var card = Instantiate(_card, _cardHolderPosition);

        _cardManager = card.GetComponent<CardManager>();
        _cardManager.InstalCard(_cardScriptableObject[index]);
        _cardManager.Init(_draggingParent);

        _cards[index] = card;

        _icon = _cardScriptableObject[index].Icon;
        _price = _cardScriptableObject[index].Price;

        card.GetComponentInChildren<RawImage>().texture = _icon;
        card.GetComponentInChildren<TMP_Text>().text = _price.ToString();
    }
}
