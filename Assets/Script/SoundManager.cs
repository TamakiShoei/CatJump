using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource bgmSource;
    [SerializeField]
    AudioSource seSource;

    public float BgmVolume
    {
        get
        {
            return bgmSource.volume;
        }
        set
        {
            bgmSource.volume = Mathf.Clamp01(value);
        }
    }

    private void Start()
    {
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        bool result = soundManager != null && soundManager != gameObject;

        if (result)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayBgm(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        bgmSource.clip = clip;

        bgmSource.Play();
    }
    
    public void PlaySe(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        seSource.PlayOneShot(clip);
    }
}