// Decompiled with JetBrains decompiler
// Type: CuteBossHealth
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class CuteBossHealth : MonoBehaviour
{
  [SerializeField]
  private CameraMove cameraMove;
  [SerializeField]
  private HealthBarUI healthBarUI;
  [SerializeField]
  private int maxHealth = 30;
  public int _cutieHealth;
  private CuteBossMover _mover;
  private bool isfirst = true;
  [SerializeField]
  private CuteBossRenderer _renderer;
  [SerializeField]
  private GreyerManage greyermanager;
  [SerializeField]
  private SecondStageMiddle middle;
  [SerializeField]
  private SecondStageEND end;

  public bool IsDeath { get; private set; }

  private void Awake() => this._mover = this.GetComponent<CuteBossMover>();

  private void Update()
  {
    if (this._cutieHealth > this.maxHealth / 2)
      return;
    this.middle.StartBattleEffect();
  }

  private void Start()
  {
    this.healthBarUI.InitHealth(this.maxHealth);
    this._cutieHealth = this.maxHealth;
    this.IsDeath = false;
  }

  public void GetDamage(int damage, Collider2D dealer)
  {
    if (this.IsDeath)
      return;
    this.StartCoroutine(this.cameraMove.PlayerHit());
    this._cutieHealth -= damage;
    this.healthBarUI.UpdateHealthUI(this._cutieHealth);
    if (this._cutieHealth > 0)
      return;
    this._renderer.enabled = false;
    this._mover.enabled = false;
    this.end.StartBattleEffect();
    this.StartCoroutine(this._renderer.Die());
    this.StartCoroutine(this.WaitFadeIn());
  }

  private IEnumerator WaitFadeIn()
  {
    if (this.isfirst)
    {
      this.isfirst = false;
      yield return (object) new WaitForSeconds(1f);
      this.greyermanager.FadeIn(1f);
      this.IsDeath = true;
    }
  }
}
