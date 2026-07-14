// Decompiled with JetBrains decompiler
// Type: FirstStageSound
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class FirstStageSound : MonoBehaviour
{
  [SerializeField]
  private AudioFadeManager audioFadeManager;
  [SerializeField]
  private Teleport teleport;
  [SerializeField]
  private Teleport1 teleport1;
  [SerializeField]
  private AudioSource audioSource;
  [SerializeField]
  private AudioClip[] clips;
  [SerializeField]
  private SceneFadeManager sceneFadeManager;
  [SerializeField]
  private PlayerHealth playerHealth;
  private bool isStage2MusicStarted;
  private bool isStage3MusicStarted;

  private void Start() => this.audioFadeManager.FadeIn(3f);

  private void Update()
  {
    if (this.teleport.isfinish && !this.isStage2MusicStarted)
    {
      this.isStage2MusicStarted = true;
      this.StartCoroutine(this.ChangeMusicRoutine(0));
    }
    if (!this.teleport1.isfinish || this.isStage3MusicStarted)
      return;
    this.isStage3MusicStarted = true;
    this.StartCoroutine(this.ChangeMusicRoutine(1));
  }

  public void StartFadeOut() => this.audioFadeManager.FadeOut(1f);

  private IEnumerator ChangeMusicRoutine(int clipIndex)
  {
    this.audioFadeManager.FadeOut(1f);
    yield return (object) new WaitForSeconds(1.1f);
    this.audioSource.Stop();
    this.audioSource.clip = this.clips[clipIndex];
    this.audioSource.volume = 0.0f;
    this.audioSource.Play();
    this.audioFadeManager.FadeIn(1f);
  }
}
