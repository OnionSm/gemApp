using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeToNextScene());
    }

    IEnumerator ChangeToNextScene()
    {
        yield return new WaitForSeconds(3f);
        ScenesTrasitionManager.Instance.NextLevel("Scene1");
    }
}
