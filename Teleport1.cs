// Decompiled with JetBrains decompiler
// Type: Teleport1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Teleport1 : MonoBehaviour
{
  [SerializeField]
  private GameObject teleport;
  public bool teleportOK;
  [SerializeField]
  private GreyerManage greyerManage;
  [SerializeField]
  private PlayerHealth health;
  [SerializeField]
  private HealthBarUI _healthBarUI;
  public bool isfinish;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!(other.tag == "Player") || !this.teleportOK)
      return;
    this.isfinish = true;
    other.transform.position = this.teleport.transform.position + new Vector3(3f, 0.0f, 0.0f);
    this.health._playerHealth = this.health.maxHealth;
    this._healthBarUI.UpdateHealthUI(this.health._playerHealth);
    this.StartCoroutine(this.StageSwitch());
  }

  private IEnumerator StageSwitch()
  {
    yield return (object) new WaitForSeconds(0.3f);
    this.greyerManage.FadeOut(0.5f);
  }
}
