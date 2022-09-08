using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardHolderManager : MonoBehaviour
{
    [SerializeField] private Transform _cardHolderPosition;
    [SerializeField] private GameObject _card;
    [SerializeField] private Card[] _cardScriptableObject;

    private GameObject[] _cards;

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

        _cards[index] = card;

        card.GetComponentInChildren<RawImage>().texture = _cardScriptableObject[index].Icon;
        card.GetComponentInChildren<TMP_Text>().text = _cardScriptableObject[index].Price.ToString();
    }
}
