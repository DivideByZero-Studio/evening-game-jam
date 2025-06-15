using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[DefaultExecutionOrder(-100)]
public class AudioManager : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string AmbientVolume = nameof(AmbientVolume);
    private const string SfxVolume = nameof(SfxVolume);

    public static AudioManager Instance { get; private set; }

    [Header("Settings")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerSnapshot normalSnapshot;
    [SerializeField] private AudioMixerSnapshot earsClosedSnapshot;
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource ambientSource1;
    [SerializeField] private AudioSource ambientSource2;
    [SerializeField] private AudioSource sfxSource;

    private AudioSource _currentAmbientSource;

    private float _volumeBeforeMuting;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        _currentAmbientSource = ambientSource1;
        DontDestroyOnLoad(this);
    }

    public void Mute()
    {
        audioMixer.GetFloat(MasterVolume, out _volumeBeforeMuting);
        SetMasterVolume(0f);
    }
    
    public void Unmute()
    {
        SetMasterVolume(_volumeBeforeMuting);
    }
    
    public void SetNormalSnapshot(float transitionTime)
    {
        normalSnapshot.TransitionTo(transitionTime);
    }

    public void SetEarsClosedSnapshot(float transitionTime)
    {
        earsClosedSnapshot.TransitionTo(transitionTime);
    }
    
    public void SetMasterVolume(float volume) => SetVolume(MasterVolume, volume);
    public void SetAmbientVolume(float volume) => SetVolume(AmbientVolume, volume);
    public void SetSfxVolume(float volume) => SetVolume(SfxVolume, volume);
    private void SetVolume(string mixerGroupVolumeParameter, float volume)
    {
        float volumeValue = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat(mixerGroupVolumeParameter, volumeValue);
    }
    
    public void PlaySfxOneShot(AudioClip clip, float volume = 1f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayAmbientByForce(AudioClip clip, float volume = 1f)
    {
        _currentAmbientSource.clip = clip;
        _currentAmbientSource.volume = volume;
        _currentAmbientSource.Play();
    }

    public void StopAmbient()
    {
        _currentAmbientSource.Stop();
    }
    
    public void PlayAmbientWithSmoothChange(AudioClip clip, float smoothTime, float volume = 1)
    {
        var nextSource = _currentAmbientSource == ambientSource1 ? ambientSource2 : ambientSource1;
        
        nextSource.clip = clip;
        StartCoroutine(ChangeSourceVolume(nextSource, volume, smoothTime));
        StartCoroutine(ChangeSourceVolume(_currentAmbientSource, 0f, smoothTime));
        _currentAmbientSource = nextSource;
        _currentAmbientSource.Play();
    }

    private IEnumerator ChangeSourceVolume(AudioSource clip, float targetVolume, float time)
    {
        float timer = time;
        float fromVolume = clip.volume;

        if (fromVolume > targetVolume)
            (fromVolume, targetVolume) = (targetVolume, fromVolume);
        
        while (time > 0f)
        {
            clip.volume = Mathf.Lerp(fromVolume, targetVolume, time / timer);
            
            time -= Time.deltaTime;
            yield return null;
        }
    }
}
