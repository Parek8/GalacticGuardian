using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
