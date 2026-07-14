// Decompiled with JetBrains decompiler
// Type: GreyerManage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

#nullable disable
public class GreyerManage : MonoBehaviour
{
  private Volume volume;
  private ColorAdjustments colorAdjustments;
  private Coroutine fadeCoroutine;

  private void Awake()
  {
    this.volume = this.GetComponent<Volume>();
    if ((Object) this.volume == (Object) null)
      this.volume = Object.FindFirstObjectByType<Volume>();
    if (!((Object) this.volume != (Object) null))
      return;
    this.volume.profile.TryGet<ColorAdjustments>(out this.colorAdjustments);
  }

  public void FadeIn(float duration) => this.TriggerFade(-100f, 0.0f, duration);

  public void FadeOut(float duration) => this.TriggerFade(0.0f, -100f, duration);

  private void TriggerFade(float startSat, float endSat, float duration)
  {
    if ((Object) this.colorAdjustments == (Object) null)
      return;
    if (this.fadeCoroutine != null)
      this.StopCoroutine(this.fadeCoroutine);
    this.fadeCoroutine = this.StartCoroutine(this.FadeRoutine(startSat, endSat, duration));
  }

  private IEnumerator FadeRoutine(float startSat, float endSat, float duration)
  {
    float elapsedTime = 0.0f;
    this.colorAdjustments.saturation.overrideState = true;
    this.colorAdjustments.saturation.value = startSat;
    while ((double) elapsedTime < (double) duration)
    {
      elapsedTime += Time.deltaTime;
      this.colorAdjustments.saturation.value = Mathf.Lerp(startSat, endSat, elapsedTime / duration);
      yield return (object) null;
    }
    this.colorAdjustments.saturation.value = endSat;
  }
}
