using System.Collections.Generic;
using UnityEngine;
internal class EndlessBackground : MonoBehaviour
{
    [field: SerializeField] Transform BackgroundParent;

    List<Transform> _backgrounds = new();
    Camera _mainCamera;
    Vector3 _screenBounds;
    Transform _player;
    private void Start()
    {
        _mainCamera = Camera.main;
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
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
            if (_bg.position.x < _player.position.x - 9)
                _bg.position = new Vector3(_bg.position.x - 27, _bg.position.y, _bg.position.z);
            if (_bg.position.x > _player.position.x - 9)
                _bg.position = new Vector3(_bg.position.x + 27, _bg.position.y, _bg.position.z);
            if (_bg.position.y < _player.position.y + 9)
                _bg.position = new Vector3(_bg.position.x, _bg.position.y + 27, _bg.position.z);
            if (_bg.position.y > _player.position.y + 9)
                _bg.position = new Vector3(_bg.position.x, _bg.position.y - 27, _bg.position.z);
        }
    }
}