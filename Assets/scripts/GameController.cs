using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public static GameObject _maingame;
    private static GameObject _minigame1;
    private static GameObject _minigame2;
    private static GameObject _characterCreation;
    private static GameObject _mainCamera;
    private static GameObject _raver;

    private enum GameState {Main, Minigame1, Minigame2, CharacterCreation}
    private static GameState _gameState;

    //Here is a private reference only this class can access
    private static GameController _instance;

    //This is the public reference that other classes will use
    public static GameController instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameController>();
            return _instance;
        }
    }

    void Awake ()
    {
        _raver = GameObject.Find("Raver");

        _maingame = GameObject.Find("MainGame");
        _maingame.SetActive(false);

        _minigame1 = GameObject.Find("MiniGame1");
        _minigame1.SetActive(false);

        _minigame2 = GameObject.Find("MiniGame2");
        _minigame2.SetActive(false);

        _characterCreation = GameObject.Find("CharacterCreation");
        _characterCreation.SetActive(false);
    } 

    void Start ()
    {
        ToCharacterCreation();
    }

    void Update ()
    {
        switch(_gameState)
        {
            case GameState.Main:
                _maingame.SetActive(true);
                break;
            case GameState.Minigame1:
                _minigame1.SetActive(true);
                break;
            case GameState.Minigame2:
                _minigame2.SetActive(true);
                break;
            case GameState.CharacterCreation:
                _characterCreation.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                    RaycastHit _hit;

                    if (Physics.Raycast (ray, out _hit))
                    {
                        if (_hit.transform.name == "Raver")
                        {
                            if(_raver.GetComponent<Raver>().CharacterState == Raver.CharacterStates.Egg)
                            {
                                _characterCreation.GetComponent<CharacterCreaton>().OpenEgg();
                            }
                        }
                    }
                }
                break;
        }
    }

    public static void ToMain ()
    {
        ResetState();
        _gameState = GameState.Main;
    }

    public void ToMinigame1 ()
    {
        ResetState();
        _gameState = GameState.Minigame1;
    }

    public void ToMinigame2 ()
    {
        ResetState();
        _gameState = GameState.Minigame2;
    }

    public void ToCharacterCreation ()
    {
        ResetState();
        _gameState = GameState.CharacterCreation;
    }

    private static void ResetState ()
    {
        _maingame.SetActive(false);
        _minigame1.SetActive(false);
        _minigame2.SetActive(false);
        _characterCreation.SetActive(false);
    }
}
