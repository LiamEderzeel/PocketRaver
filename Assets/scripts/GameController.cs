using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static GameObject _maingame;
    private static GameObject _minigame1;
    private static GameObject _minigame2;
    private static GameObject _characterCreation;
    private static GameObject _mainCamera;

    private enum GameState {Main, Minigame1, Minigame2, CharacterCreation}
    private static GameState _gameState;

    void Awake ()
    {
        _maingame = GameObject.Find("MainGame");
        _maingame.SetActive(false);

        _minigame1 = GameObject.Find("MiniGame1");
        _minigame1.SetActive(false);

        _minigame2 = GameObject.Find("MiniGame2");
        _minigame2.SetActive(false);

        _characterCreation = GameObject.Find("CharacterCreation");
        _characterCreation.SetActive(false);

        _mainCamera = GameObject.Find("Main Camera");
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
                break;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit _hit;

            if (Physics.Raycast (ray, out _hit))
            {
                if (_hit.transform.name == "Egg")
                {
                    print("yomama");
                }
            }
        }
    }

    public void ToMain ()
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

    private void ResetState ()
    {
        _maingame.SetActive(false);
        _minigame1.SetActive(false);
        _minigame2.SetActive(false);
        _characterCreation.SetActive(false);
    }
}
