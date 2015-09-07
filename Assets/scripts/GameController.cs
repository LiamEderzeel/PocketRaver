using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static GameObject _maingame;
    private static GameObject _minigame1;
    private static GameObject _minigame2;

    private enum GameState {maingame, minigame1, minigame2}
    private static GameState _gameState;

    void Awake () {
        _maingame = GameObject.Find("MainGam");
        _maingame.SetActive(false);

        _minigame1 = GameObject.Find("MiniGame1");
        _minigame1.SetActive(false);

        _minigame2 = GameObject.Find("MiniGame2");
        _minigame2.SetActive(false);
    } 
    // Use this for initialization
    void Start () {

        _gameState = GameState.maingame;
    }
    // Use this for initialization

    // Update is called once per frame
    void Update () {

        switch(_gameState)
        {
            case GameState.maingame:
                ResetState();
                _maingame.SetActive(true);
                break;
            case GameState.minigame1:
                 ResetState();
                _minigame1.SetActive(true);
                break;
            case GameState.minigame2:
                 ResetState();
                _minigame2.SetActive(true);
                break;
        }
    }

    private void ResetState () {
        _maingame.SetActive(false);
        _minigame1.SetActive(false);
        _minigame2.SetActive(false);
    }
}
