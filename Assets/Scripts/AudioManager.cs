using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;

    [SerializeField] AudioClip sceneSwitchSwoosh;
    [SerializeField] AudioClip pilotLaser;

    [SerializeField] AudioClip[] VocalBops;
    [SerializeField] AudioClip Pickup;
    [SerializeField] AudioClip Warn;
    [SerializeField] AudioClip Ambiance;
    [SerializeField] AudioClip Drop;
    [SerializeField] AudioClip Track1;
    [SerializeField] AudioClip Track2;
    [SerializeField] AudioClip Track3;
    [SerializeField] AudioClip BossIntro;
    [SerializeField] AudioClip BossFight;

    [Space(10)]
    [SerializeField] AudioSource musicChannel;
    [SerializeField] List<AudioSource> sfxChannels;

    int currentSFXChannel = 0;
    int highestSFXChannel = 0;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;

        if (musicChannel == null) Debug.LogError("AudioManager: Music Channel is null");
        foreach (AudioSource sfxChannel in sfxChannels)
        {
            if (sfxChannel == null) Debug.LogError("Audio Manager: One of the SFX Channels is null");
        }

        highestSFXChannel = sfxChannels.Count - 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Music
    void PlayMusic(AudioClip music)
    {
        if (music == null)
        {
            Debug.LogWarning("Attempted to play a null music clip.  Not playing music");
            return;
        }
        // This conditional will only allow swapping of the music if the music is changing
        //  - This lets multiple areas with the same music feel contiguous
        if (musicChannel.clip != music)
        {
            musicChannel.Stop();
            musicChannel.clip = music;
            musicChannel.Play();
        }
    }
    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }
    public void PlayGameMusic()
    {
        PlayMusic(gameMusic);
    }
    public void PlayAmbiance()
    {
        PlayMusic(Ambiance);
    }
    public void PlayTrack1()
    {
        PlayMusic(Track1);
    }
    public void PlayTrack2()
    {
        PlayMusic(Track2);
    }
    public void PlayTrack3()
    {
        PlayMusic(Track3);
    }
    public void PlayBoss() 
    {
        StartCoroutine(PlayBossFight());
    }
    IEnumerator PlayBossFight() 
    {
        PlayMusic(BossIntro);
        yield return new WaitForSeconds(BossIntro.length);
        PlayMusic(BossFight);
    }
    #endregion

    #region Sound Effects

    void PlaySoundEffect(AudioClip soundEffect)
    {
        if (soundEffect == null)
        {
            Debug.LogWarning("Attempted to play a null sfx clip.  Not playing sfx");
            return;
        }

        NextSFXChannel();
        if (!sfxChannels[currentSFXChannel].isPlaying)
        {
            sfxChannels[currentSFXChannel].Stop();
            sfxChannels[currentSFXChannel].clip = soundEffect;
            sfxChannels[currentSFXChannel].Play();
        }
    }
    public void PlayDropEffect() 
    {
        PlaySoundEffect(Drop);
    }
    public void PlayPickup() 
    {
        PlaySoundEffect(Pickup);
    }
    public void PlayWarn() 
    {
        PlaySoundEffect(Warn);
    }
    public void PlaySceneSwitchSwooshSFX()
    {
        PlaySoundEffect(sceneSwitchSwoosh);
    }
    public void PlayPilotLaserSFX()
    {
        PlaySoundEffect(pilotLaser);
    }

    public void PlayVocalBop(int min, int max) 
    {
        PlaySoundEffect(VocalBops[Random.Range(min, max)]);
    }

    // This cycles the indices of the sfx channel list and makes "currentSFXChannel" appropriate throughout the class
    // - This is called by PlayMusic() and PlaySoundEffect() before stopping the sound/music, replacing the clip, and playing the new clip
    void NextSFXChannel()
    {
        currentSFXChannel++;
        if (currentSFXChannel > highestSFXChannel)
            currentSFXChannel = 0;

    }
    #endregion
}
