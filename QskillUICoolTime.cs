// Decompiled with JetBrains decompiler
// Type: QskillUICoolTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class QskillUICoolTime : MonoBehaviour
{
  [SerializeField]
  private Image CooldownImage;

  private void Awake() => this.gameObject.SetActive(false);

  public IEnumerator CooldownRoutine(float time)
  {
    QskillUICoolTime qskillUiCoolTime = this;
    qskillUiCoolTime.gameObject.SetActive(true);
    qskillUiCoolTime.CooldownImage.fillAmount = 1f;
    while ((double) qskillUiCoolTime.CooldownImage.fillAmount > 0.0)
    {
      qskillUiCoolTime.CooldownImage.fillAmount -= Time.deltaTime / time;
      yield return (object) null;
    }
    qskillUiCoolTime.CooldownImage.fillAmount = 0.0f;
    qskillUiCoolTime.gameObject.SetActive(false);
  }
}
