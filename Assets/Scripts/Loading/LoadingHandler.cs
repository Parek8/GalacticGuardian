using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class LoadingHandler : MonoBehaviour
{
    [field: SerializeField] GameObject LoadingScreen;

    private void OnEnable()
    {
        LoadingScreen.SetActive(false);
    }

    internal void Load(string sceneName)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(Load(sceneName, 0));
    }

    private IEnumerator Load(string sceneName, int x)
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOp.allowSceneActivation = true;
        while (!asyncOp.isDone)
        {
            Debug.Log(asyncOp.progress);
            yield return new WaitForSeconds(0.1f);
        }
    }
}