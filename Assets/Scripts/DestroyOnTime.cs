using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    [field: SerializeField] float TimeAlive = 5f;

    float _currentRemainingTime = 0;

    private void Start() => _currentRemainingTime = TimeAlive;

    private void Update()
    {
        _currentRemainingTime -= TimeAlive;

        if (TimeAlive < 0)
            Destroy(gameObject);
    }
}