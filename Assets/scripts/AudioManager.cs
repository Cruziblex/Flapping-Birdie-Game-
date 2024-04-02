using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource sfxLoop;

    [Header("SFX Clips")]
    public AudioClip birdFlap;
    public AudioClip birdIdle;
    public AudioClip birdCrash;
    public AudioClip menuHover;
    public AudioClip menuClick;

    private string musicIsOn;
    private string sfxIsOn;


    private void Awake()
    {
        Debug.Log("AudioManager loaded " + sfxIsOn + " to sfxIsOn and " + musicIsOn + " to musicIsOn");
    }
    private void Start()
    {
        sfxIsOn = PlayerPrefs.GetString("sfxIsOn", "Default");
        musicIsOn = PlayerPrefs.GetString("musicIsOn", "Default");
        loadSavedMusicSettings();
        loadSavedSfxSettings();
    }

    public void Update()
    {

    }


    public void playMusic()
    {
        backgroundMusic.Play();
    }

    public void stopMusic()
    {
        backgroundMusic.Stop();
    }
    public void stopSound()
    {
        sfxLoop.Stop();
    }
    public void playHover()
    {
        sfxSource.PlayOneShot(menuHover);
    }
    public void playClick()
    {
        if (sfxIsOn == "True")
        {
            sfxSource.PlayOneShot(menuClick);
        }
    }
    public void playSound(AudioClip clip)
    {
        if (sfxIsOn == "True")
        {
            sfxSource.clip = clip;
            sfxSource.PlayOneShot(clip);
        }
    }

    public void playSoundLoop(AudioClip clip)
    {
        if (sfxIsOn == "True")
        {
            sfxLoop.clip = clip;
            sfxLoop.Play();
        }

    }

    public void loadSavedSfxSettings()
    {
        if (sfxIsOn == "True" || sfxIsOn == "Default")
        {
            sfxSource.mute = false;
            sfxLoop.mute = false;
        }
        else if (sfxIsOn == "False")
        {
            sfxSource.mute = true;
            sfxLoop.mute = true;
        }
            
    }
    public void loadSavedMusicSettings()
    {

        if (musicIsOn == "True" || musicIsOn == "Default")
        {
            backgroundMusic.mute = false;
        }
        else if (musicIsOn == "False")
        {
            backgroundMusic.mute = true;
        }

    }


    public void muteSfxLoop()
    {
        sfxLoop.mute = true;
        Debug.Log("Game should be muting, this is running. Mute status is: " + sfxLoop.mute);
    }

    public void unmuteSfxLoop()
    {
        sfxLoop.mute = false;
        Debug.Log("Game should be unmuting, this is running. Mute status is: " + sfxLoop.mute);
    }

    public void toggleMuteMusic()
    {
        if (backgroundMusic.mute == true)
        {
            backgroundMusic.mute = false;
        }
        else if (backgroundMusic.mute == false)
        {
            backgroundMusic.mute = true;
        }
    }
    public void toggleMuteSfx()
    {
        if (sfxSource.mute == true)
        {
            sfxSource.mute = false;
        }
        else if (sfxSource.mute == false)
        {
            sfxSource.mute = true;
        }
    }



}