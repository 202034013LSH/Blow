using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseAuthManager
{
    private static FireBaseAuthManager instance = null;
    private bool IsLogin = false;

    public static FireBaseAuthManager Instance
    {
        get
        {
            if (instance == null) instance = new FireBaseAuthManager();
            return instance;
        }
    }

    private FirebaseAuth auth;
    private FirebaseUser user;

    public Action<bool> LoginState;

    public string UserID => user.UserId;

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;
        if (auth.CurrentUser != null) LogOut();

        auth.StateChanged += OnChanged;
    }

    private void OnChanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != user)
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if (!signed && user != null)
            {
                Debug.Log("로그아웃");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if (signed)
            {
                Debug.Log("로그인");
                LoginState?.Invoke(true);

            }
        }
    }


    public void Create(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("회원가입 실패");
                foreach (var exception in task.Exception.InnerExceptions)
                {
                    Debug.LogError($"Error : {exception.Message}");
                }
                return;
            }

            Debug.Log("회원가입 완료");
            IsLogin = false;
        });
    }
    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("로그인 실패");
                return;
            }

            Debug.Log("로그인 완료");
            IsLogin = true;
        });
    }
    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("로그아웃");
        IsLogin = false;
    }
}
