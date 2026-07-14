// Decompiled with JetBrains decompiler
// Type: SceneFadeManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#nullable disable
public class SceneFadeManager : MonoBehaviour
{
  public Image fadeImage;

  private void Start() => this.StartCoroutine(this.FadeIn(1.5f));

  public void ChangeScene(string sceneName)
  {
    this.StartCoroutine(this.FadeOutAndLoadScene(sceneName, 3f));
  }

  private IEnumerator FadeIn(float duration)
  {
    float time = 0.0f;
    Color color = this.fadeImage.color;
    this.fadeImage.raycastTarget = true;
    while ((double) time < (double) duration)
    {
      time += Time.deltaTime;
      color.a = Mathf.Lerp(1f, 0.0f, time / duration);
      this.fadeImage.color = color;
      yield return (object) null;
    }
    color.a = 0.0f;
    this.fadeImage.color = color;
    this.fadeImage.raycastTarget = false;
  }

  private IEnumerator FadeOutAndLoadScene(string sceneName, float duration)
  {
    float time = 0.0f;
    Color color = this.fadeImage.color;
    this.fadeImage.raycastTarget = true;
    while ((double) time < (double) duration)
    {
      time += Time.deltaTime;
      color.a = Mathf.Lerp(0.0f, 1f, time / duration);
      this.fadeImage.color = color;
      yield return (object) null;
    }
    color.a = 1f;
    this.fadeImage.color = color;
    SceneManager.LoadScene(sceneName);
  }
}
