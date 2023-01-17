using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
    }

    [SerializeField]
    private SoundData[] soundDatas;

    [SerializeField]
    private AudioSource[] audioSourceList = new AudioSource[20];

    //名前とキーとするサウンドデータマップ
    private Dictionary<string, SoundData> soundDataDictionary = new Dictionary<string, SoundData>();

    private void Awake()
    {
        for (int i = 0; i < audioSourceList.Length; i++)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        //Dictionaryに追加
        foreach(var soundData in soundDatas)
        {
            soundDataDictionary.Add(soundData.name, soundData);
        }
    }

    private AudioSource GetUnusedAudioSource()
    {
        for (int i = 0; i < audioSourceList.Length; i++)
        {
            if (audioSourceList[i].isPlaying == false)
            {
                return audioSourceList[i];
            }
        }
        return null;
    }

    private void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null)
        {
            return;
        }
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void Play(string name)
    {
        if (soundDataDictionary.TryGetValue(name, out var soundData))
        {
            Play(soundData.audioClip);
        }
        else
        {
            Debug.LogWarning($"{name}という名前の効果音はありません");
        }
    }

    public void StopAll()
    {
        foreach (var audioSource in audioSourceList)
        {
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
}