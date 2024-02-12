using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager _mainMenuManagerInstance;
    internal static MainMenuManager MainMenuManagerInstance => _mainMenuManagerInstance;

    private void Awake()
    {
        if (_mainMenuManagerInstance == null)
            _mainMenuManagerInstance = this;
    }

    public static void NewGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public static void Exit()
    {
        Application.Quit();
        //Exit the editor playmode -> checking, if you're using UNITY_EDITOR
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        //EditorApplication.Exit(200);
#endif
    }
}