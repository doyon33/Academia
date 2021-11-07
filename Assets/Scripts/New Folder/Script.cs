using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Script
{
    public Script(string __id, string __text, List<string> __next)
    {
        id = __id;
        text = __text;
        next = __next;
    }

    private string _id;
    private string _text;
    private List<string> _next;

    public string id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string text
    {
        get { return _text; }
        set { _text = value; }
    }
    public List<string> next
    {
        get { return _next; }
        set { _next = value; }
    }

    private void Awake() 
    {
        _next = new List<string>();
    }
}
