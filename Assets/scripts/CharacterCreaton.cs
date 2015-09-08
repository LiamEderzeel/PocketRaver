using UnityEngine;
using System.Collections;

public class CharacterCreaton : MonoBehaviour {

    public GameObject InterfaceNext
    {
        get { return _interfaceNext; }
        set { _interfaceNext = value; }
    }
    private GameObject _interfaceNext;

	void Awake ()
    {
        _interfaceNext = GameObject.Find("CharacterCreationCanvas");
        _interfaceNext.SetActive(false);
	}

	void Start ()
    {

	
	}
	
	void Update ()
    {
	
	}
}
