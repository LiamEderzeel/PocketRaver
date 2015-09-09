using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pill : MonoBehaviour
{
    private List<GameObject> _children;

    void Awake ()
    {
        _children = new List<GameObject>();
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            _children.Add(child);
        }

        foreach(GameObject child in _children)
        {
            print(child);
        }
    }

	void Start ()
    {
	}
	
	void Update ()
    {
	}
}
