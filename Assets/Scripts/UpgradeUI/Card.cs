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
        _pStats = GameManager.GameManagerInstance.PlayerStats;
        SetAmount();
        SelectRandomType();
        _cardClick.onClick.AddListener(OnCardClick);
        SetTitle();
        ChangeTextBasedOnType();
    }

    void OnCardClick()
    {
        _pStats.IncreaseStat(_type, _amount);
    }
    void SetAmount()
    {
        _amount = UnityEngine.Random.Range(0.25f, 1.25f);
        _amount = (float)Math.Round(_amount, 2);
    }
    void SetTitle()
    {
        _cardTitleElement.text = _type.ToString() + "++";
    }
    void SelectRandomType()
    {
        Array values = Enum.GetValues(typeof(StatType));
        _type = (StatType)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        Debug.Log(_type.ToString());
    }
    void ChangeTextBasedOnType()
    {
        _cardTextElement.text = $"Increase the stat ({_type}) by {_amount}";
    }
}
