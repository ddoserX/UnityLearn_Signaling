using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TamperSensor : MonoBehaviour
{
    [SerializeField] private float _smoothSoundDuration = 1.0f;
    private AudioSource _audioPlayer;
    private Coroutine _audioPlayerJob;

    private void Start() 
    {
        _audioPlayer = GetComponent<AudioSource>();
    }

    public void EnterArea()
    {
        Debug.Log("Enter");

        if ((_audioPlayerJob == null) == false)
            StopCoroutine(_audioPlayerJob);
        
        _audioPlayerJob = StartCoroutine(SmoothStartSound(_smoothSoundDuration));
    }

    public void ExitArea()
    {
        Debug.Log("Exit");
        
        if ((_audioPlayerJob == null) == false)
            StopCoroutine(_audioPlayerJob);

        _audioPlayerJob = StartCoroutine(SmoothStopSound(_smoothSoundDuration));
    }

    private IEnumerator SmoothStartSound(float duration)
    {
        _audioPlayer.volume = 0.0f;
        _audioPlayer.Play();
        
        while(_audioPlayer.volume != 1.0f)
        {
            _audioPlayer.volume = Mathf.MoveTowards(_audioPlayer.volume, 1, Time.deltaTime / duration);

            yield return null;
        }
    }

    private IEnumerator SmoothStopSound(float duration = 1.0f)
    {
        while(_audioPlayer.volume != 0.0f)
        {
            _audioPlayer.volume = Mathf.MoveTowards(_audioPlayer.volume, 0, Time.deltaTime / duration);

            yield return null;
        }

        _audioPlayer.Stop();
    }
}
