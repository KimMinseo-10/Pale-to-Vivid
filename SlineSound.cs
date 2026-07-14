

using UnityEngine;

#nullable disable
public class SlineSound : MonoBehaviour
{
  public AudioClip footStepSounds;
  public float stepInterval = 0.5f;
  private AudioSource audioSource;
  private float stepTimer;

  private void Awake() => this.audioSource = this.GetComponent<AudioSource>();

  public void PlayFootStepContinuous()
  {
    this.stepTimer += Time.deltaTime;
    if ((double) this.stepTimer < (double) this.stepInterval || (Object) this.footStepSounds == (Object) null)
      return;
    this.audioSource.clip = this.footStepSounds;
    this.audioSource.Play();
    this.stepTimer = 2f;
  }

  public void ResetTimer() => this.stepTimer = this.stepInterval;
}
