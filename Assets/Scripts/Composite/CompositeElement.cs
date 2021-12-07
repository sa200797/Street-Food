using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeElement : DrawingElement // MonoBehaviour
{
    [SerializeField]internal List<DrawingElement> elements = new List<DrawingElement>();
    // Constructor
    public CompositeElement(string name): base(name)
    {
    }
    public override void Add(DrawingElement d)
    {
        elements.Add(d);
    }
    public override void Remove(DrawingElement d)
    {
        elements.Remove(d);
    }
    public override void Display(int indent)
    {
        Console.WriteLine(new String('-', indent) +"+ " + name);
        // Display each child element on this node
        foreach (DrawingElement d in elements)
        {
            d.Display(indent + 2);
        }
    }
}
