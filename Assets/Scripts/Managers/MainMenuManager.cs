using UnityEditor;
using UnityEngine;

internal sealed class MainMenuManager : MonoBehaviour
{
    [field: SerializeField] LoadingHandler Loader;


    private static MainMenuManager _mainMenuManagerInstance;
    internal static MainMenuManager MainMenuManagerInstance => _mainMenuManagerInstance;

    private void Awake()
    {
        if (_mainMenuManagerInstance == null)
            _mainMenuManagerInstance = this;
    }

    public void NewGame()
    {
        Loader.Load("Tutorial");
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