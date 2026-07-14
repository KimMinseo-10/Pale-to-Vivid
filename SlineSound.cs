// Decompiled with JetBrains decompiler
// Type: SlineSound
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

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
