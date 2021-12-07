using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public static Tutorial tutorial;

    [SerializeField] UnityEvent OnTutorialClick;
    [SerializeField] int CurrountOrderIndex;
    [SerializeField] internal int OrderIndex;
    [SerializeField] GameObject[] OrderList;

    [SerializeField] bool restart;
    [SerializeField] Saggatation vadapov;
    [SerializeField] Saggatation sandwich;
    [SerializeField] Saggatation pizza;

    Sequence moveUpDown;

    void Awake()
    {
        if (tutorial == null)
        {
            tutorial = this;
        }
        else
        {
            Destroy(tutorial);
        }
    }
    void Start()
    {
        if (GameManager.instance.isTutorialOn == true)
        {
            GameManager.tagsFoodClickIndex += FindAndExecute;
        }

        if (GameManager.instance.isTutorialOn == false)
        {
            for (int i = 0; i < vadapov.gameObjects.Count; i++) { vadapov.gameObjects[i].gameObject.SetActive(false); }
            for (int i = 0; i < sandwich.gameObjects.Count; i++) { sandwich.gameObjects[i].gameObject.SetActive(false); }
            for (int i = 0; i < pizza.gameObjects.Count; i++) { pizza.gameObjects[i].gameObject.SetActive(false); }
        }
    }
    void OnDisable()
    {
        GameManager.tagsFoodClickIndex -= FindAndExecute;
    }

    internal void SetupSaggatation(int orderIndex)
    {
        if (GameManager.instance.isTutorialOn == false) { return; }

        if (CurrountOrderIndex != orderIndex)
        {
            CurrountOrderIndex = orderIndex;
            for (int i = 0; i < OrderList.Length; i++)
            {
                OrderList[i].SetActive(false);
            }
            OrderList[orderIndex].SetActive(true);
        }

    }
    internal void SetupOrderIndexSaggatation()
    {
        if (GameManager.instance.isTutorialOn == false)
        {
            return;
        }

        Debug.Log("CurrountOrderIndex : " + CurrountOrderIndex);

        if (CurrountOrderIndex == 0)
        {
            for (int i = 0; i < vadapov.gameObjects.Count; i++) { vadapov.gameObjects[i].gameObject.SetActive(false); }
            for (int i = 0; i < vadapov.gameObjects.Count; i++)
            {
                vadapov.gameObjects[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                //vadapov.gameObjects[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            }
            vadapov.gameObjects[OrderIndex].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            animationSuggestion(vadapov.gameObjects[OrderIndex]);
        }
        if (CurrountOrderIndex == 1)
        {
            for (int i = 0; i < sandwich.gameObjects.Count; i++) { sandwich.gameObjects[i].gameObject.SetActive(false); }
            for (int i = 0; i < sandwich.gameObjects.Count; i++)
            {
                sandwich.gameObjects[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                //vadapov.gameObjects[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            }
            sandwich.gameObjects[OrderIndex].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            animationSuggestion(sandwich.gameObjects[OrderIndex]);
        }

        if (CurrountOrderIndex == 2)
        {
            for (int i = 0; i < pizza.gameObjects.Count; i++) { pizza.gameObjects[i].gameObject.SetActive(false); }
            for (int i = 0; i < pizza.gameObjects.Count; i++)
            {
                pizza.gameObjects[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                //vadapov.gameObjects[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            }
            pizza.gameObjects[OrderIndex].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            animationSuggestion(pizza.gameObjects[OrderIndex]);
        }

    }
    void animationSuggestion(GameObject MoveGameObject)
    {
        MoveGameObject.SetActive(true);
        moveUpDown = DOTween.Sequence();
        moveUpDown
            .Append(DOTween.Sequence().Append(MoveGameObject.transform.DOMoveY(5f, 1f))
            .Append(MoveGameObject.transform.DOMoveY(4f, 1f))
            .Play());
        moveUpDown.SetLoops(-1, LoopType.Restart);
    }
    void FindAndExecute(string tags, int index, GameObject hit)
    {
        Debug.Log("tag : " + tags + " is work" + "OrderIndex : " + OrderIndex + "   foodvalue  : " + hit.GetComponent<ItemCount>().foodvalue);

        if (tags == "VadaPav" && OrderIndex == hit.GetComponent<ItemCount>().foodvalue - 1)
        {
            moveUpDown.Kill();
            restart = true;
            if (OrderIndex != vadapov.gameObjects.Count - 1)
            {
                OrderIndex++;
                SetupSaggatation(0);
                SetupOrderIndexSaggatation();
            }
        }
        if (tags == "sandwich" && OrderIndex == hit.GetComponent<ItemCount>().foodvalue - 1)
        {
            moveUpDown.Kill();
            restart = true;
            if (OrderIndex != sandwich.gameObjects.Count - 1)
            {
                OrderIndex++;
                SetupSaggatation(1);
                SetupOrderIndexSaggatation();
            }
        }

        if (tags == "pizza" && OrderIndex == hit.GetComponent<ItemCount>().foodvalue - 1)
        {
            moveUpDown.Kill();
            restart = true;
            if (OrderIndex != pizza.gameObjects.Count - 1)
            {
                OrderIndex++;
                SetupSaggatation(2);
                SetupOrderIndexSaggatation();
            }
        }

    }
}

[System.Serializable]
public class Saggatation
{
    public List<GameObject> gameObjects;
}