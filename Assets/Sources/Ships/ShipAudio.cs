using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShipAudio : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private AudioClip _shootAudio;
    [SerializeField] private AudioClip _dieAudio;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _ship.Shooted += OnShipShooted;
        _ship.Died += OnShipDied;
    }

    private void OnDisable()
    {
        _ship.Shooted -= OnShipShooted;
        _ship.Died -= OnShipDied;
    }

    private void OnShipShooted()
    {
        PlayClip(_shootAudio);
    }

    private void OnShipDied()
    {
        PlayClip(_dieAudio);
    }

    private void PlayClip(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
    }
}

