using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public struct Sound
    {
        public AudioClip soundPlaying;
        public AudioSource source;
        public GameObject obj;

        public SoundParams parameters;

        public float startTime;
        public float endTime;

        public void Play(AudioSource source, GameObject obj, SoundParams parameters)
        {
            this.parameters = parameters;
            this.source = source;
            this.source.clip = soundPlaying;
            this.source.volume = parameters.volume;
            this.source.loop = parameters.loop;
            this.source.spatialBlend = parameters.isMusic ? 0 : 1f;
            this.source.maxDistance = 500f;
            this.source.minDistance = 1f;
            this.source.pitch = parameters.pitch;
            this.source.Play();
            this.obj = obj;
            endTime = Time.time + soundPlaying.length;
        }

        public void Update(float currentVolume = 1f)
        {
            source.volume = currentVolume * parameters.volume;
        }

        public void Destroy()
        {
            MonoBehaviour.Destroy(obj.gameObject);
        }
    }

    public class SoundParams
    {
        public float volume = 1f;
        public float pitch = 1f;
        public bool loop = false;
        public string subtitle = "";
        public bool isMusic = false;

        public SoundParams()
        {
        }

        public SoundParams(float volume, bool loop, string subtitle)
        {
            this.volume = volume;
            this.loop = loop;
            this.subtitle = subtitle;
        }
    }

    private const float defaultSoundVolume = 1.0f;
    private const float defaultMusicVolume = 0.75f;

    public float soundVolume = defaultSoundVolume;
    public float musicVolume = defaultMusicVolume;

    public List<Sound> soundsPlaying = new List<Sound>();

    private void Start()
    {
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", defaultSoundVolume);
        }

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", defaultMusicVolume);
        }

        soundVolume = PlayerPrefs.GetFloat("soundVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
    }

    public void PlaySound(AudioClip soundToPlay, Vector3 location, SoundParams parameters = null)
    {
        if (parameters == null)
        {
            parameters = new SoundParams();
        }

        Sound sound = new Sound()
        {
            soundPlaying = soundToPlay,
            startTime = Time.time,
        };

        GameObject soundObject = new GameObject(parameters.subtitle != "" ? parameters.subtitle : soundToPlay.name);
        soundObject.transform.position = location;
        AudioSource source = soundObject.AddComponent<AudioSource>();
        sound.Play(source, soundObject, parameters);
        soundsPlaying.Add(sound);
    }

    public void PlayMusic(AudioClip soundToPlay, SoundParams parameters = null)
    {
        for (int i = 0; i < soundsPlaying.Count; i++)
        {
            if (soundsPlaying[i].parameters.isMusic)
            {
                soundsPlaying[i].Destroy();
                soundsPlaying.RemoveAt(i);
            }
        }

        if (parameters == null)
        {
            parameters = new SoundParams();
        }

        parameters.loop = true;
        parameters.isMusic = true;

        Sound sound = new Sound()
        {
            soundPlaying = soundToPlay,
            startTime = Time.time,
        };

        GameObject soundObject = new GameObject(parameters.subtitle != "" ? parameters.subtitle : soundToPlay.name);
        soundObject.transform.position = Vector3.zero;
        AudioSource source = soundObject.AddComponent<AudioSource>();
        sound.Play(source, soundObject, parameters);
        soundsPlaying.Add(sound);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < soundsPlaying.Count; i++)
        {
            if (soundsPlaying[i].parameters.isMusic == false)
            {
                soundsPlaying[i].Update(soundVolume);
            }
            else
            {
                soundsPlaying[i].Update(musicVolume);
            }

            if (Time.time >= soundsPlaying[i].endTime && soundsPlaying[i].parameters.loop == false)
            {
                soundsPlaying[i].Destroy();
                soundsPlaying.RemoveAt(i);
            }
        }
    }

    public void SetSoundVolume(float volume)
    {
        soundVolume = volume;
        PlayerPrefs.SetFloat("soundVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void ResetSettings()
    {
        PlayerPrefs.SetFloat("soundVolume", defaultSoundVolume);
        PlayerPrefs.SetFloat("musicVolume", defaultMusicVolume);
        soundVolume = defaultSoundVolume;
        musicVolume = defaultMusicVolume;
    }
}
