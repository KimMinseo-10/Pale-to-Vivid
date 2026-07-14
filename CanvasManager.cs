// Decompiled with JetBrains decompiler
// Type: CanvasManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class CanvasManager : MonoBehaviour
{
  [SerializeField]
  private GameObject XUI;

  public IEnumerator XuiManager(float time)
  {
    this.XUI.SetActive(true);
    yield return (object) new WaitForSeconds(time);
    this.XUI.SetActive(false);
  }
}
