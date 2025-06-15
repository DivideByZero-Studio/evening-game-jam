using System;
using Unity.Cinemachine;
using UnityEngine;

public class GoToSleepTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _endCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerExtraAnimations>(out var playerExtraAnimations))
        {
            playerExtraAnimations.LayDown();
            _endCamera.enabled = true;
        }
    }
}
