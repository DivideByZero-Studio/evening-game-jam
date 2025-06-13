using System;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CameraSwitchTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineCamera firstCamera;
    [SerializeField] private CinemachineCamera secondCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            firstCamera.enabled = false;
            secondCamera.enabled = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            firstCamera.enabled = true;
            secondCamera.enabled = false;
        }
    }
}
