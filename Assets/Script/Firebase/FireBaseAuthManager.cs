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
        // ������
        _auth = FirebaseAuth.DefaultInstance;

        // ���łɃ��[�U�[������Ă���̂��m�F
        if (_auth.CurrentUser == null)
        {
            // �܂����[�U�[���ł��Ă��Ȃ����߃��[�U�[�쐬
            Create((result) =>
            {
                if (result)
                {
                    Debug.Log($"����: #{_user.UserId}");
                }
                else
                {
                    Debug.Log("���s");
                }
            });
        }
        else
        {
            _user = _auth.CurrentUser;
            Debug.Log($"���O�C����: #{_user.UserId}");
        }
    }

    /// <summary>
    /// �����Ń��[�U�[�쐬SignInAnonymouslyAsync
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