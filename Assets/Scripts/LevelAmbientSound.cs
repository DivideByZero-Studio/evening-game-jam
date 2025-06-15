using System;
using UnityEngine;

public class LevelAmbientSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private bool _doNotStopMusic;
    private void Start()
    {
        AudioManager.Instance.PlayAmbientByForce(_clip, 0.3f);
    }

    private void OnDestroy()
    {
        if (_doNotStopMusic)
            return;
        
        AudioManager.Instance.StopAmbient();
    }
}
