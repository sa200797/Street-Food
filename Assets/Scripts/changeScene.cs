using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(scenechangeTime());
    }

    public void Changescene()
    {
        SceneManager.LoadScene("VADA test1");
    }

    IEnumerator scenechangeTime()
    {
        yield return new WaitForSeconds(3f);
        Changescene();
    }
}
