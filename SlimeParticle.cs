// Decompiled with JetBrains decompiler
// Type: SlimeParticle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SlimeParticle : MonoBehaviour
{
  public GameObject hitParticle;

  private void Start()
  {
    if (!((Object) this.hitParticle != (Object) null))
      return;
    this.hitParticle.SetActive(false);
  }

  public void TakeDamage(Vector3 hitPoint)
  {
    if (!((Object) this.hitParticle != (Object) null))
      return;
    this.hitParticle.SetActive(false);
    this.hitParticle.transform.position = hitPoint;
    this.hitParticle.SetActive(true);
  }
}
