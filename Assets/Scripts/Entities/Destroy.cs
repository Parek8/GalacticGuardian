using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [field: SerializeField] float MaxTimeRemaining = 5f;

    float _currentTimeRemaining = 0;

    private void Start() => _currentTimeRemaining = MaxTimeRemaining;
    private void Update()
    {
        _currentTimeRemaining -= Time.deltaTime;
        if (_currentTimeRemaining <= 0)
            Destroy(gameObject);
    }
}
