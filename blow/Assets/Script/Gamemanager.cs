using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Gamemanager : MonoBehaviour
{
    public enum state 
    { 
        Login, 
        MainGame, 
        PlayGame,
        Lank
    }
    public state State;
    private bool IsLogin;
    public UnityEvent OnLogin;
    public UnityEvent OnLogout;
    public UnityEvent OnMainGameScene;
    
    void Start()
    {
        IsLogin = false;
        State = state.Login;
    }

    void Update()
    {
        
    }
    public void Login()
    {
        IsLogin = true;
        OnLogin.Invoke();
    }
    public void Logout()
    {
        IsLogin = false;
        OnLogout.Invoke();
    }
    public void MainGameScene()
    {
        State = state.MainGame;
        SceneManager.LoadScene("MainGame");
    }
    public void PlayGameScene()
    {
        State = state.PlayGame;
        SceneManager.LoadScene("PlayScene");
    }
}
