// Decompiled with JetBrains decompiler
// Type: ToTheTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class ToTheTitle : MonoBehaviour
{
  [SerializeField]
  private SceneFadeManager sceneFadeManager;
  [SerializeField]
  private GameObject clickSound;

  public void OnMouseDown()
  {
    this.StartCoroutine(this.ClickSound());
    this.sceneFadeManager.ChangeScene("Start");
  }

  public IEnumerator ClickSound()
  {
    this.clickSound.SetActive(true);
    yield return (object) new WaitForSeconds(0.3f);
    this.clickSound.SetActive(false);
  }
}
