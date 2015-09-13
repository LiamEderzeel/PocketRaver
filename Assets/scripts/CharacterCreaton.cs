using UnityEngine;
using System.Collections;

public class CharacterCreaton : MonoBehaviour {

    public GameObject Interface
    {
        get { return _interface; }
        set { _interface = value; }
    }
    private GameObject _interface;
    private GameObject _raver;
    private Raver _raverScript;

    void Awake ()
    {
        _raver = GameObject.Find("Raver");
        _raverScript = GameObject.Find("Raver").GetComponent<Raver>();

        _interface = GameObject.Find("CharacterCreationCanvas");
        _interface.SetActive(false);
    }

    void Start ()
    {


    }

    void Update ()
    {

    }
    public void Reset()
    {
        _interface.SetActive(false);
        _raverScript.SetCharacterEgg();
    }

    public void OpenEgg()
    {
        _interface.SetActive(true);

        _raverScript.OpenEgg();
    }

    public void ChoseRaver()
    {
        GameObject childObject = Instantiate(_raver, transform.position, transform.rotation) as GameObject;          
        childObject.transform.parent = GameController._maingame.transform;
        childObject.transform.position = _raver.transform.position;
        GameController.ToMain();
        childObject.GetComponent<Animator>().SetBool ("clicked", true);
    }
}
