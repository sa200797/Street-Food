using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class DrawingElement : MonoBehaviour
{
    [SerializeField]protected string name;
    // Constructor
    public DrawingElement(string name)
    {
        this.name = name;
    }
    public abstract void Add(DrawingElement d);
    public abstract void Remove(DrawingElement d);
    public abstract void Display(int indent);
}
