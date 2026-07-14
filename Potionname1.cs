// Decompiled with JetBrains decompiler
// Type: Potionname1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using TMPro;
using UnityEngine;

#nullable disable
public class Potionname1 : MonoBehaviour
{
  [SerializeField]
  private TextMeshPro textMeshPro;

  private void Awake() => this.textMeshPro = this.GetComponent<TextMeshPro>();

  public void StartBattleEffect() => this.StartCoroutine(this.FadeIn());

  public void EndBattleEffect() => this.StartCoroutine(this.FadeOut());

  private IEnumerator FadeIn()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Potionname1 potionname1 = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) potionname1.StartCoroutine(potionname1.FadeText(0.0f, 1f, 0.5f));
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private IEnumerator FadeOut()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Potionname1 potionname1 = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) potionname1.StartCoroutine(potionname1.FadeText(1f, 0.0f, 0.5f));
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
  {
    float time = 0.0f;
    Color color = this.textMeshPro.color;
    while ((double) time < (double) duration)
    {
      time += Time.deltaTime;
      color.a = Mathf.Lerp(startAlpha, endAlpha, time / duration);
      this.textMeshPro.color = color;
      yield return (object) null;
    }
    color.a = endAlpha;
    this.textMeshPro.color = color;
  }
}
