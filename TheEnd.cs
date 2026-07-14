// Decompiled with JetBrains decompiler
// Type: TheEnd
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class TheEnd : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI textMeshPro;
  public Image fadeImage;
  private bool isfirst;
  public bool finish;

  private void Awake()
  {
    if (!((Object) this.textMeshPro == (Object) null))
      return;
    this.textMeshPro = this.GetComponent<TextMeshProUGUI>();
  }

  private void Update()
  {
    if ((Object) this.fadeImage == (Object) null || (double) this.fadeImage.color.a != 0.0 || this.isfirst)
      return;
    this.StartCoroutine(this.Startset());
  }

  private IEnumerator Startset()
  {
    yield return (object) new WaitForSeconds(3f);
    this.StartBattleEffect();
    yield return (object) new WaitForSeconds(3f);
    this.finish = true;
  }

  public void StartBattleEffect()
  {
    if (this.isfirst)
      return;
    this.isfirst = true;
    this.StartCoroutine(this.FadeInTextRoutine());
  }

  private IEnumerator FadeInTextRoutine()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    TheEnd theEnd = this;
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
    this.\u003C\u003E2__current = (object) theEnd.StartCoroutine(theEnd.FadeText(0.0f, 1f, 3f));
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
  {
    if (!((Object) this.textMeshPro == (Object) null))
    {
      float time = 0.0f;
      Color color = this.textMeshPro.color with
      {
        a = startAlpha
      };
      this.textMeshPro.color = color;
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
}
