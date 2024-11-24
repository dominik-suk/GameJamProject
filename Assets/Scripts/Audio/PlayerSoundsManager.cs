using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSoundsManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup sfx;
    [SerializeField] private AudioClip _walkingSound;
    private AudioSource _walkingSoundSource;
    private bool walkingSoundOn = false;

    private void Awake()
    {
        _walkingSoundSource = gameObject.AddComponent<AudioSource>();
        _walkingSoundSource.clip = _walkingSound;
        _walkingSoundSource.loop = true;
        _walkingSoundSource.outputAudioMixerGroup = sfx;
    }
    private void Update()
    {
        if (!walkingSoundOn && GetComponentInChildren<GroundedChecker2D>().IsGrounded && GetComponent<Rigidbody2D>().linearVelocity != Vector2.zero)
        {
            walkingSoundOn = true;
            _walkingSoundSource.Play();   
        }
        else if (walkingSoundOn && (GetComponent<Rigidbody2D>().linearVelocity == Vector2.zero || !GetComponentInChildren<GroundedChecker2D>().IsGrounded))
        {
            walkingSoundOn = false;
            _walkingSoundSource.Stop();
        }
    }
}
