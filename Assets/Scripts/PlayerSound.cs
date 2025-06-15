using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [Header("Clips")]
    [SerializeField] private AudioClip awakeSound;
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landingSound;
    [SerializeField] private AudioClip gotDamagedSound;
    [SerializeField] private AudioClip deathSound;

    public void PlayAwakeSound() => AudioManager.Instance.PlaySfxOneShot(awakeSound);
    public void PlayFootstepSound() => AudioManager.Instance.PlaySfxOneShot(footstepSound, 0.5f);
    public void PlayJumpSound() => AudioManager.Instance.PlaySfxOneShot(jumpSound, 0.9f);
    public void PlayLandingSound() => AudioManager.Instance.PlaySfxOneShot(landingSound, 0.5f);
    public void PlayGotDamagedSound() => AudioManager.Instance.PlaySfxOneShot(gotDamagedSound, 0.6f);
    public void PlayDeathSound() => AudioManager.Instance.PlaySfxOneShot(deathSound, 0.8f);
}