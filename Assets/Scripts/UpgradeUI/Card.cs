using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;
using System;

public class Card : MonoBehaviour
{
    [SerializeField]
    Button _cardClick;

    [SerializeField]
    TMP_Text _cardTextElement;
    [SerializeField]
    TMP_Text _cardTitleElement;

    EntityStats _pStats;

    [SerializeField]
    string _cardText;
    [SerializeField]
    string _cardTitle;
    float _amount;
    [SerializeField]
    StatType _type;

    // Start is called before the first frame update
    void Start()
    {
        _pStats = GameManager.GameManagerInstance.GetComponent<EntityStats>();
        _amount = UnityEngine.Random.Range(0.25f, 1.25f);
        _cardClick.onClick.AddListener(OnCardClick);
    }

    void OnCardClick()
    {
        _pStats.IncreaseStat(_type, _amount);
    }
}
