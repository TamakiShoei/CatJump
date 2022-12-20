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

        //// �T���v��: �ۑ�
        //var userData = new UserPlayData("taka", 10);
        //SaveUserData(userData);

        // �T���v��: �擾
        //GetUserData((result) =>
        //{
        //    if (result == null)
        //    {
        //        Debug.LogWarning("���s");
        //    }
        //    else
        //    {
        //        Debug.Log($"username: {result.username}");
        //        Debug.Log($"time: {result.score}");
        //    }
        //});
    }

    /// <summary>
    /// ���[�U�[�f�[�^��Json������database�ɕۑ��iSetRawJsonValueAsync�j
    /// </summary>
    public void SaveUserData(UserPlayData data)
    {
        GameObject obj = GameObject.Find("FirebaseAuthManager");
        _auth = obj.GetComponent<FireBaseAuthManager>()._auth;
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        // �����T���v�����@: https://firebase.google.com/docs/database/unity/save-data?authuser=0#write_update_or_delete_data_at_a_reference
        var json = JsonUtility.ToJson(data);
        reference.Child(USER_DATA_KEY).Child(_auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
    }

    /// <summary>
    /// ���[�U�[�f�[�^���擾
    /// </summary>
    public void GetUserData(GetUserDataCallback callback)
    {
        FirebaseDatabase.DefaultInstance.GetReference(USER_DATA_KEY)
            .Child(_auth.CurrentUser.UserId).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted) { Debug.Log("�����ς�"); }
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


        // �f�[�^������܂ő҂�

        // �f�[�^���\�[�g����B


        //GetUserData(null) ;
        //reference.GetValueAsync().ContinueWith(task => {

        //    if (task.IsFaulted)
        //    { //�擾���s
        //      //Handle the Error
        //        Debug.Log("���s���Ă�H");
        //    }
        //});
        //reference.Child("users").OrderByChild("score").GetValueAsync().ContinueWith(task =>
        //{
        //    if (task.IsFaulted)
        //    { //�擾���s
        //      //Handle the Error
        //        Debug.Log("���s���Ă�H");
        //    }
        //    else if (task.IsCompleted)
        //    { //�擾����
        //        DataSnapshot snapshot = task.Result; //���ʎ擾
        //        IEnumerator<DataSnapshot> en = snapshot.Children.GetEnumerator(); //���ʃ��X�g��enumerator�ŏ���
        //        int counter = 0;
        //        while (en.MoveNext())
        //        { //�P��������
        //            DataSnapshot data = en.Current; //�f�[�^���
        //            string name = (string)data.Child("username").GetValue(true); //���O���
        //            int score = (int)data.Child("score").GetValue(true); //�X�R�A�����
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
                Debug.LogError("���s");
            }
            else if (task.IsCompleted)
            {
              
                outData.Clear();
                DataSnapshot snapshot = task.Result;
                IEnumerator<DataSnapshot> en = snapshot.Children.GetEnumerator(); //���ʃ��X�g��enumerator�ŏ���

                while (en.MoveNext())
                { //�P��������
                    DataSnapshot data = en.Current; //�f�[�^���
                    string name = data.Child("username").GetValue(true).ToString(); //���O���
                    string scoreString = data.Child("score").GetValue(true).ToString();
                    int score = int.Parse(scoreString); //�X�R�A�����
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
