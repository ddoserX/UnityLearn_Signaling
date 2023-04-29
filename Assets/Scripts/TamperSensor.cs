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
        if ((_audioPlayerJob == null) == false)
            StopCoroutine(_audioPlayerJob);
        
        _audioPlayer.volume = 0.0f;
        _audioPlayer.Play();
        _audioPlayerJob = StartCoroutine(SmoothSoundLookToward(1.0f, _smoothSoundDuration));
    }

    public void ExitArea()
    {
        if ((_audioPlayerJob == null) == false)
            StopCoroutine(_audioPlayerJob);

        _audioPlayerJob = StartCoroutine(SmoothSoundLookToward(0.0f, _smoothSoundDuration));
    }

    private IEnumerator SmoothSoundLookToward(float value, float duration = 1.0f)
    {
        while(_audioPlayer.volume != value)
        {
            _audioPlayer.volume = Mathf.MoveTowards(_audioPlayer.volume, value, Time.deltaTime / duration);

            yield return null;
        }

        if (_audioPlayer.volume == 0.0f)
        {
            _audioPlayer.Stop();
        }
    }
}