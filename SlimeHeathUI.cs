// Decompiled with JetBrains decompiler
// Type: SlimeHeathUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SlimeHeathUI : MonoBehaviour
{
  [SerializeField]
  private SlimeHealth slimeHealth;
  [SerializeField]
  private CuteBossHealth cuteBossHealth;
  [SerializeField]
  private GameObject teleport;
  [SerializeField]
  private bool slimeisDead;

  private void Awake() => this.gameObject.SetActive(false);

  private void Update()
  {
    if (this.cuteBossHealth.IsDeath)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      if (!this.slimeHealth.IsDeath || this.slimeisDead)
        return;
      this.gameObject.SetActive(false);
      this.teleport.SetActive(true);
      this.slimeisDead = true;
    }
  }
}
