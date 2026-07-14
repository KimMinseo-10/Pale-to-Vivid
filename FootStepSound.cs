

using UnityEngine;

#nullable disable
public class FootStepSound : MonoBehaviour
{
  public AudioClip[] footStepSounds;
  public float stepInterval = 0.5f;
  private AudioSource audioSource;
  private float stepTimer;

  private void Awake() => this.audioSource = this.GetComponent<AudioSource>();

  public void PlayFootStepContinuous()
  {
    this.stepTimer += Time.deltaTime;
    if ((double) this.stepTimer < (double) this.stepInterval || this.footStepSounds == null || this.footStepSounds.Length == 0)
      return;
    this.audioSource.clip = this.footStepSounds[Random.Range(0, this.footStepSounds.Length)];
    this.audioSource.Play();
    this.stepTimer = 0.0f;
  }

  public void ResetTimer() => this.stepTimer = this.stepInterval;
}
