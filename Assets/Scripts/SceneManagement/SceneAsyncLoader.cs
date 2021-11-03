using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneAsyncLoader : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnSceneLoadStarted;
    [SerializeField]
    private UnityEvent OnSceneLoadFinished;

    public void ReloadScene()
    {        
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        OnSceneLoadStarted?.Invoke();

        yield return new WaitForSeconds(0.3f);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        OnSceneLoadFinished?.Invoke();
        yield break;
    }

}
