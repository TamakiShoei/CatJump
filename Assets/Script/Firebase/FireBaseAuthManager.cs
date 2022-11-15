using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class FireBaseAuthManager : MonoBehaviour
{
    public FirebaseAuth _auth;
    FirebaseUser _user;
    public FirebaseUser UserData { get { return _user; } }
    public delegate void CreateUser(bool result);

    void Awake()
    {
        // 初期化
        _auth = FirebaseAuth.DefaultInstance;

        // すでにユーザーが作られているのか確認
        if (_auth.CurrentUser == null)
        {
            // まだユーザーができていないためユーザー作成
            Create((result) =>
            {
                if (result)
                {
                    Debug.Log($"成功: #{_user.UserId}");
                }
                else
                {
                    Debug.Log("失敗");
                }
            });
        }
        else
        {
            _user = _auth.CurrentUser;
            Debug.Log($"ログイン中: #{_user.UserId}");
        }
    }

    /// <summary>
    /// 匿名でユーザー作成SignInAnonymouslyAsync
    /// </summary>
    public void Create(CreateUser callback)
    {
        _auth.SignInAnonymouslyAsync().ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                callback(false);
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                callback(false);
                return;
            }

            _user = task.Result;
            Debug.Log($"User signed in successfully: {_user.DisplayName} ({_user.UserId})");
            callback(true);
        });
    }
}
