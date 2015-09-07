using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

    private static GameObject _gameController; 
    private static GameObject _appController;

    private enum State {App, Game}
    private static State _currentState;

    void Awake () 
    {
        _gameController = GameObject.Find("GameController");
        _gameController.SetActive(false);

        _appController = GameObject.Find("AppController");
        _appController.SetActive(false);
    }
    void Start () 
    {
        ToApp();
    }

    void Update ()
    {
        switch(_currentState)
        {
            case State.App:
                _appController.SetActive(true);
                break;
            case State.Game:
                _gameController.SetActive(true);
                break;
        }
    }

    public void ToApp ()
    {
        ResetState();
        _currentState = State.App;
    }
    
    public void ToGame ()
    {        
        ResetState();
        _currentState = State.Game;
    }

    private static void ResetState () 
    {
        _gameController.SetActive(false);
        _appController.SetActive(false);
    }
}
