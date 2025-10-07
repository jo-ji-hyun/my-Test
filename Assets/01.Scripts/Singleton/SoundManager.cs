using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _Audio_BGM;
    public AudioSource Audio_SFX;

    public AudioClip BGM_1;
    public AudioClip BGM_2;
    public AudioClip SFX_Open;
    public AudioClip SFX_Close;

    protected override bool IsDestroy => false;

    protected override void Awake()
    {
        base.Awake();

        _Audio_BGM = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoadedBGM;
        Interaction.OnStartDialogued += StartSFX;
    }

    private void OnSceneLoadedBGM(Scene scene, LoadSceneMode mode)
    {
        StartBGM(scene.name);
    }

    private void StartBGM(string sceneName)
    {
        AudioClip audioClip = null;

        switch (sceneName)
        {
            case "SampleScene":
                audioClip = BGM_1;
                break;
            case "NextScene":
                audioClip = BGM_2;
                break;

            default:
                if(_Audio_BGM != null)
                {
                    StopBGM();
                }
                break;
        }

        if (audioClip != null) 
        {
            if (_Audio_BGM.clip != audioClip || !_Audio_BGM.isPlaying)
            {
                _Audio_BGM.clip = audioClip;
                _Audio_BGM.Play();
            }
        }
        else
        {
            if (audioClip != null)
            {
                StopBGM();
            }
        }
    }

    public void StartSFX(int i)
    {
        if(Audio_SFX != null)
        {
            Audio_SFX.clip = SFX_Open;
            Audio_SFX.Play();
        }
        else
        {
            StopSFX();
        }
    }

    public void StopBGM()
    {
        if (_Audio_BGM != null && _Audio_BGM.isPlaying)
        {
            _Audio_BGM.Stop();
        }
    }

    public void StopSFX()
    {
        if(Audio_SFX != null && Audio_SFX.isPlaying)
        {
            Audio_SFX.Stop();
        }
    }
}
