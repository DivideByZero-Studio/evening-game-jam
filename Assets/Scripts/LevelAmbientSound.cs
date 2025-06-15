using System;
using UnityEngine;

public class LevelAmbientSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        AudioManager.Instance.PlayAmbientByForce(_clip, 0.3f);
    }

    private void OnDestroy()
    {
        AudioManager.Instance.StopAmbient();
    }
}
