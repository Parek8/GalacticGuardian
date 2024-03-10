using UnityEditor;
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
    public void Exit()
    {
        Application.Quit();
        //Exit the editor playmode -> checking, if you're using UNITY_EDITOR
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        //EditorApplication.Exit(200);
#endif
    }
}
