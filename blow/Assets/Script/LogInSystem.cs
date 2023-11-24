using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInSystem : MonoBehaviour
{
    public InputField email;
    public InputField password;

    public Text outputText;

    void Start()
    {
        FireBaseAuthManager.Instance.Init();
        FireBaseAuthManager.Instance.LoginState += OnChangedState;
    }

    private void OnChangedState(bool sign)
    {
        outputText.text = sign ? "로그인 : " : "로그아웃 :";
        outputText.text += FireBaseAuthManager.Instance.UserID;
    }

    public void Create()
    {
        string e = email.text;
        string p = password.text;

        FireBaseAuthManager.Instance.Create(e, p);
        ResetText();
    }
    public void LogIn()
    {
        FireBaseAuthManager.Instance.Login(email.text, password.text);
        ResetText();
    }
    private void ResetText()
    {
        email.text = " ";
        password.text = " ";
    }
    public void LogOut()
    {
        FireBaseAuthManager.Instance.LogOut();
        ResetText();
    }
}
