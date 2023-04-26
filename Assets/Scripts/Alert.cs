using UnityEngine;
using UnityEngine.Events;

public class Alert : MonoBehaviour
{
[SerializeField] private UnityEvent _enterDetected;
[SerializeField] private UnityEvent _exitDetected;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Human>(out Human human))
        {
            _enterDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.TryGetComponent<Human>(out Human human))
        {
            _exitDetected?.Invoke();
        }
    }
}
