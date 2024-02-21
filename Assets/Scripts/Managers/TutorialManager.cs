using UnityEngine;
using UnityEngine.UI;

internal sealed class TutorialManager : MonoBehaviour
{
    [field: SerializeField] Image FilledCircle;
    [field: SerializeField] float CircleFillLimit;
    [field: SerializeField] LoadingHandler Loader;
    [field: SerializeField] internal Transform PlayerTransform { get; private set; }
    [field: SerializeField] internal Vector2 MapRadius { get; private set; }

    float _filledAmount;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
            _filledAmount += Time.deltaTime;
        else
            _filledAmount = 0;


        if (_filledAmount < CircleFillLimit)
            UpdateCircleFillAmount();
        else
            Loader.Load("Overworld");
        
        if (PlayerTransform.position.x > MapRadius.x || PlayerTransform.position.x < -MapRadius.x || PlayerTransform.position.y > MapRadius.y || PlayerTransform.position.y < -MapRadius.y)
            PlayerTransform.position = Vector3.zero;

    }

    private void UpdateCircleFillAmount()
    {
        float _amount = _filledAmount / CircleFillLimit;

        FilledCircle.fillAmount = _amount;
    }
}