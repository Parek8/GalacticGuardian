using UnityEngine;
internal class EndlessBackground : MonoBehaviour
{
    Camera _mainCamera;
    Vector3 _screenBounds;
    Transform _player;
    private void Start()
    {
        _mainCamera = Camera.main;
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
        _player = GameManager.GameManagerInstance.PlayerTransform;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_player.position, transform.position) >= 450)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}