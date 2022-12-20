using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using System.Net.NetworkInformation;
using UnityEngine.SocialPlatforms.Impl;
using System.Net;

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
                if (task.IsFaulted) { Debug.Log("しっぱい"); }
                //callback(null);

                else if (task.IsCompleted) { }
                    //callback(new UserPlayData(
                    //    task.Result.Child("username").Value.ToString(),
                    //    int.Parse(task.Result.Child("score").Value.ToString())));
            });
    }

    public List<UserPlayData> GetTopThreeData()
    {
        List<UserPlayData> outData = new List<UserPlayData>();


        // データが来るまで待つ

        // データをソートする。


        //GetUserData(null) ;
        //reference.GetValueAsync().ContinueWith(task => {

        //    if (task.IsFaulted)
        //    { //取得失敗
        //      //Handle the Error
        //        Debug.Log("失敗してる？");
        //    }
        //});
        //reference.Child("users").OrderByChild("score").GetValueAsync().ContinueWith(task =>
        //{
        //    if (task.IsFaulted)
        //    { //取得失敗
        //      //Handle the Error
        //        Debug.Log("失敗してる？");
        //    }
        //    else if (task.IsCompleted)
        //    { //取得成功
        //        DataSnapshot snapshot = task.Result; //結果取得
        //        IEnumerator<DataSnapshot> en = snapshot.Children.GetEnumerator(); //結果リストをenumeratorで処理
        //        int counter = 0;
        //        while (en.MoveNext())
        //        { //１件ずつ処理
        //            DataSnapshot data = en.Current; //データ取る
        //            string name = (string)data.Child("username").GetValue(true); //名前取る
        //            int score = (int)data.Child("score").GetValue(true); //スコアを取る
        //            outData[counter].username = name;
        //            outData[counter].score = score;
        //            Debug.Log(outData[counter]);
        //        }
        //    }
        //});

        foreach (var Data in outData)
        {
            Debug.Log($"{Data.username}:{Data.score}");
        }

        return outData;
    }

     List<UserPlayData> GetAllData()
    {
        List<UserPlayData> outData = new List<UserPlayData>();
        FirebaseDatabase.DefaultInstance
        .GetReference("users")
        .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.LogError("失敗");
            }
            else if (task.IsCompleted)
            {
              
                outData.Clear();
                DataSnapshot snapshot = task.Result;
                IEnumerator<DataSnapshot> en = snapshot.Children.GetEnumerator(); //結果リストをenumeratorで処理

                while (en.MoveNext())
                { //１件ずつ処理
                    DataSnapshot data = en.Current; //データ取る
                    string name = data.Child("username").GetValue(true).ToString(); //名前取る
                    string scoreString = data.Child("score").GetValue(true).ToString();
                    int score = int.Parse(scoreString); //スコアを取る
                    outData.Add(new UserPlayData(name, score));
                }
            } 
        });
        return outData;
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
