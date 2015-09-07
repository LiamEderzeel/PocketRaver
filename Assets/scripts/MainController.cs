using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

    private static GameObject _gameController;
    private static GameObject _menu;
    // Use this for initialization
    void Awake () {
        _gameController = GameObject.Find("GameController");
        _gameController.SetActive(false);
    }
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
