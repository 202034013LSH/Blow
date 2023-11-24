using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasManager : MonoBehaviour
{
    private bool IsLogin;
    public UnityEvent OnLogin;
    public UnityEvent OnLogout;
    public UnityEvent OnOption_open;
    public UnityEvent OnOption_close;
    public UnityEvent OnPlayGameLoad;
    public UnityEvent OnMainSceneLoad;
    public UnityEvent OnConstruction_open;
    public UnityEvent OnConstruction_close;

    void Start()
    {
        IsLogin = false;

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
    public void Option_open()
    {
        OnOption_open.Invoke();
    }
    public void Option_close()
    {
        OnOption_close.Invoke();
    }
    public void MainSceneLoad()
    {
        OnMainSceneLoad.Invoke();
    }
    public void PlayGameLoad()
    {
        OnPlayGameLoad.Invoke();
    }
    public void Construction_Open()
    {
        OnConstruction_open.Invoke();
    }
    public void Construction_Close()
    {
        OnConstruction_close.Invoke();
    }
}
