using UnityEngine;
using UnityEngine.UI;

internal sealed class TutorialManager : MonoBehaviour
{
    [field: SerializeField] Image FilledCircle;
    [field: SerializeField] float CircleFillLimit;
    [field: SerializeField] LoadingHandler Loader;

    float _filledAmount;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Escape))
            _filledAmount += Time.deltaTime;
        else
            _filledAmount = 0;


        if (_filledAmount < CircleFillLimit)
            UpdateCircleFillAmount();
        else
            Loader.Load("Overworld");
    }

    private void UpdateCircleFillAmount()
    {
        float _amount = _filledAmount / CircleFillLimit;

        FilledCircle.fillAmount = _amount;
    }
}