// Decompiled with JetBrains decompiler
// Type: SlimeHealth
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class SlimeHealth : MonoBehaviour
{
  [SerializeField]
  private CameraMove cameraMove;
  [SerializeField]
  private HealthBarUI healthBarUI;
  [SerializeField]
  private int maxHealth = 30;
  [SerializeField]
  private Teleport teleport;
  [SerializeField]
  private GreyerManage greyerManager;
  [SerializeField]
  private int _slimeHealth;
  public bool IsDeath;
  private bool isfinish;
  [SerializeField]
  private SlimeRenderer _renderer;
  private SlimeMover _mover;

  private void Awake() => this._mover = this.GetComponent<SlimeMover>();

  private void Start()
  {
    this.healthBarUI.InitHealth(this.maxHealth);
    this._slimeHealth = this.maxHealth;
    this.IsDeath = false;
  }

  public void GetDamage(int damage, Collider2D dealer)
  {
    if (this.IsDeath)
      return;
    this.StartCoroutine(this.cameraMove.PlayerHit());
    this._slimeHealth -= damage;
    this.healthBarUI.UpdateHealthUI(this._slimeHealth);
    if (this._slimeHealth > 0)
      return;
    this.teleport.teleportOK = true;
    this._renderer.enabled = false;
    this._mover.enabled = false;
    this.StartCoroutine(this._renderer.Die());
    this.StartCoroutine(this.WaitFadeIn());
  }

  private IEnumerator WaitFadeIn()
  {
    yield return (object) new WaitForSeconds(1f);
    if (!this.isfinish)
    {
      this.greyerManager.FadeIn(1f);
      this.IsDeath = true;
      this.isfinish = true;
    }
  }
}
