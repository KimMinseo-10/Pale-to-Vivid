// Decompiled with JetBrains decompiler
// Type: AudioFadeManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class AudioFadeManager : MonoBehaviour
{
  private AudioSource audioSource;

  private void Awake() => this.audioSource = this.GetComponent<AudioSource>();

  public void FadeIn(float duration) => this.StartCoroutine(this.FadeAudio(0.0f, 1f, duration));

  public void FadeOut(float duration)
  {
    this.StartCoroutine(this.FadeAudio(this.audioSource.volume, 0.0f, duration));
  }

  private IEnumerator FadeAudio(float startVolume, float targetVolume, float duration)
  {
    float time = 0.0f;
    if ((double) startVolume == 0.0 && !this.audioSource.isPlaying)
    {
      this.audioSource.volume = 0.0f;
      this.audioSource.Play();
    }
    while ((double) time < (double) duration)
    {
      time += Time.deltaTime;
      this.audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
      yield return (object) null;
    }
    this.audioSource.volume = targetVolume;
    if ((double) targetVolume == 0.0)
      this.audioSource.Stop();
  }
}
