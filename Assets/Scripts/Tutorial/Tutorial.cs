using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Saggatation saggatation;
    private void Awake()
    {
    }
    void Start()
    {
        GameManager.tagsFoodClickIndex += FindAndExecute;
    }
    void FindAndExecute(string tags, int index)
    {
        Debug.Log("tag Name : " + tags + "index : " + index);
    }

   


}

[System.Serializable]
public class Saggatation
{ 
    public List<GameObject> gameObjects;  
}