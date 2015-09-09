using UnityEngine;
using System.Collections;

public class AppController : MonoBehaviour
{
    private static GameObject _menuMain;
    private static GameObject _menuTicket;
    private static GameObject _menuInfo;
    
    private enum AppState {Main, Ticket, Info}
    private static AppState _appState;

    void Awake () 
    {
        _menuMain = GameObject.Find("MenuMain");
        _menuMain.SetActive(false);

        _menuTicket = GameObject.Find("MenuTicket");
        _menuTicket.SetActive(false);

        _menuInfo = GameObject.Find("MenuInfo");
        _menuInfo.SetActive(false);
    }

	void Start () 
    {
        ToMenuMain();
	
	}
	
	void Update ()
    {
        switch(_appState)
        {
            case AppState.Main:
                break;
            case AppState.Ticket:
                break;
            case AppState.Info:
                break;
        }
	}
    
    public void ToMenuMain ()
    {
        ResetState();
        _menuMain.SetActive(true);
    }

    public void ToMenuTicket ()
    {
        ResetState();
        _menuTicket.SetActive(true);
    }
    
    public void ToMenuInfo ()
    {
        ResetState();
        _menuInfo.SetActive(true);
    }

    private static void ResetState()
    {
        _menuMain.SetActive(false);
        _menuTicket.SetActive(false);
        _menuInfo.SetActive(false);
    }
}
