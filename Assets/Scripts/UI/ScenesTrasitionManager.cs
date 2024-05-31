using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTrasitionManager : MonoBehaviour
{
    private static ScenesTrasitionManager instance;
    public static ScenesTrasitionManager Instance => instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("More than one ScenesTrasitionManager");
        }
        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel(string nameScenes)
    {
        StartCoroutine(WaitingLoadNextScenes(nameScenes));
    }


    public void BackLevel(string nameScenes)
    {
        StartCoroutine(WaitingLoadBackScenes(nameScenes));
    }

    IEnumerator WaitingLoadNextScenes(string nameScenes)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(nameScenes);
    }

    IEnumerator WaitingLoadBackScenes(string nameScenes)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(nameScenes);

    }
}
