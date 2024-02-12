using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

internal sealed class TutorialManager : MonoBehaviour
{
    [field: SerializeField] Image FilledCircle;
    [field: SerializeField] float CircleFillLimit;


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
            SceneManager.LoadScene("Overworld");
        
    }

    private void UpdateCircleFillAmount()
    {
        float _amount = _filledAmount / CircleFillLimit;

        FilledCircle.fillAmount = _amount;
    }
}