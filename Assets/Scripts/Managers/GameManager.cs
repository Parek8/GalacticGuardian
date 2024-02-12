using UnityEngine;

internal sealed class GameManager : MonoBehaviour
{
    private static GameManager _gameManagerInstance;
    internal static GameManager GameManagerInstance => _gameManagerInstance;
    [field: SerializeField] internal Transform PlayerTransform;

    private void Awake()
    {
        if (_gameManagerInstance == null)
            _gameManagerInstance = this;
    }

}