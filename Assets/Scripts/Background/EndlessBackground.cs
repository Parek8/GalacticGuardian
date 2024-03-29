using System.Collections.Generic;
using UnityEngine;
internal class EndlessBackground : MonoBehaviour
{
    [field: SerializeField] Transform BackgroundParent;
    [field: SerializeField] float TileSize = 9;

    List<Transform> _backgrounds = new();
    Camera _mainCamera;
    Transform _player;
    private void Start()
    {
        _mainCamera = Camera.main;
        _player = GameManager.GameManagerInstance.PlayerTransform;
        Transform[] _bgs = BackgroundParent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < _bgs.Length; i++)
            if (!_backgrounds.Contains(_bgs[i]))
                _backgrounds.Add(_bgs[i]);
    }

    private void FixedUpdate()
    {
        foreach (Transform _bg in _backgrounds)
        {
            if(_player != null)
            {
                if (_bg.position.x < _player.position.x - GetDifference())
                    _bg.position = new Vector2(_bg.position.x + GetStep(), _bg.position.y);
                if (_bg.position.x > _player.position.x + GetDifference())
                    _bg.position = new Vector2(_bg.position.x - GetStep(), _bg.position.y);
                if (_bg.position.y < _player.position.y - GetDifference())
                    _bg.position = new Vector2(_bg.position.x, _bg.position.y + GetStep());
                if (_bg.position.y > _player.position.y + GetDifference())
                    _bg.position = new Vector2(_bg.position.x, _bg.position.y - GetStep());
            }
        }
    }

    private float GetDifference() => ((TileSize) + (TileSize/2));
    private float GetStep() => (3 * TileSize);
}