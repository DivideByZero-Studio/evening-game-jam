using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class TriggerCollider : MonoBehaviour
{
    public event Action<Collider> TriggerEnter;
    public event Action<Collider> TriggerExit;
    
    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke(other);
    }
    
    private void OnTriggerExit(Collider other)
    {
        TriggerExit?.Invoke(other);
    }
}