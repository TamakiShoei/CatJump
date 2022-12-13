using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using System;

public class FirebaseDatabaseManager : SingletonMonoBehaviour<FirebaseDatabaseManager>
{
    readonly string USER_DATA_KEY = "users";
    DatabaseReference reference;
    
    public FirebaseAuth _auth;

    public delegate void GetUserDataCallback(UserPlayData result);

    void Start()
    {
        GameObject obj = GameObject.Find("FirebaseAuthManager");
        _auth = obj.GetComponent<FireBaseAuthManager>()._auth;
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        //// サンプル: 保存
        //var userData = new UserPlayData("taka", 10);
        //SaveUserData(userData);

        // サンプル: 取得
        //GetUserData((result) =>
        //{
        //    if (result == null)
        //    {
        //        Debug.LogWarning("失敗");
        //    }
        //    else
        //    {
        //        Debug.Log($"username: {result.username}");
        //        Debug.Log($"time: {result.score}");
        //    }
        //});
    }

    /// <summary>
    /// ユーザーデータをJson化してdatabaseに保存（SetRawJsonValueAsync）
    /// </summary>
    public void SaveUserData(UserPlayData data)
    {
        GameObject obj = GameObject.Find("FirebaseAuthManager");
        _auth = obj.GetComponent<FireBaseAuthManager>()._auth;
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        // 公式サンプル方法: https://firebase.google.com/docs/database/unity/save-data?authuser=0#write_update_or_delete_data_at_a_reference
        var json = JsonUtility.ToJson(data);
        reference.Child(USER_DATA_KEY).Child(_auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
    }

    /// <summary>
    /// ユーザーデータを取得
    /// </summary>
    public void GetUserData(GetUserDataCallback callback)
    {
        FirebaseDatabase.DefaultInstance.GetReference(USER_DATA_KEY)
            .Child(_auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                    callback(null);

                else if (task.IsCompleted)
                    callback(new UserPlayData(
                        task.Result.Child("username").Value.ToString(),
                        int.Parse(task.Result.Child("time").Value.ToString())));
            });
    }
}

public class UserPlayData
{
    public string username;
    public int score;

    public UserPlayData(string username, int score)
    {
        this.username = username;
        this.score = score;
    }
}
