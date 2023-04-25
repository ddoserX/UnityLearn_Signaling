using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alert : MonoBehaviour
{
[SerializeField] private UnityEvent _enterDetection;
[SerializeField] private UnityEvent _exitDetection;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Human>(out Human human))
        {
            _enterDetection?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.TryGetComponent<Human>(out Human human))
        {
            _exitDetection?.Invoke();
        }
    }
}
