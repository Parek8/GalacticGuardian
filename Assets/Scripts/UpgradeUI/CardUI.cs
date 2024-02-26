using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField]
    int _cardCount;

    [SerializeField]
    Transform _grid;

    [SerializeField]
    List<GameObject> _cardPrefab;

    EntityStats _pStats;
    List<GameObject> _cards = new List<GameObject>();

    private void Start()
    {
        _pStats = GameManager.GameManagerInstance.PlayerTransform.GetComponent<EntityStats>();
        InstantiateCards();
    }
    public void RerollCards()
    {
        for (int i = 0; i < _cards.Count; i++)
            Destroy(_cards[i]);

        _cards.Clear();
        InstantiateCards();
    }

    private void InstantiateCards()
    {
        for (int i = 0; i < _cardCount; i++)
        {
            _cards.Add(Instantiate(_cardPrefab[Random.Range(0, _cardPrefab.Count)], _grid));
        }
    }
}
