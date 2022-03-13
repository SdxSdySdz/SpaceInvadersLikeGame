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
        _ship.Shooted.AddListener(OnShipShooted);
        _ship.Died.AddListener(OnShipDied);
    }

    private void OnDisable()
    {
        _ship.Shooted.RemoveListener(OnShipShooted);
        _ship.Died.RemoveListener(OnShipDied);
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

