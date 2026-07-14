// Decompiled with JetBrains decompiler
// Type: CuteBossRenderer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class CuteBossRenderer : MonoBehaviour
{
  private Animator _anim;
  [SerializeField]
  private CuteBossMover _mover;
  [SerializeField]
  private CuteBossEffect _cuteBossEffect;
  [SerializeField]
  private PlayerHealth _health;
  private int _hashDie = Animator.StringToHash("Die");
  private int _hashAttack1 = Animator.StringToHash("Attack1");
  private int _hashAttack2 = Animator.StringToHash("Attack2");
  public bool _isDeath;
  [SerializeField]
  private Teleport1 _teleport1;
  [SerializeField]
  private GameObject cutebosssound;
  [SerializeField]
  private GameObject cutebosssound2;
  [SerializeField]
  private GameObject cuteBosssound3;

  private void Awake() => this._anim = this.GetComponent<Animator>();

  public IEnumerator Attack1Animation()
  {
    yield return (object) new WaitForSeconds(0.1f);
    this._mover.move = true;
    this._anim.SetBool(this._hashAttack1, true);
    yield return (object) new WaitForSeconds(2.8f);
    this._mover.move = false;
    this._mover._isAttack1Active = false;
    this._anim.SetBool(this._hashAttack1, false);
  }

  public IEnumerator Attack2Animation()
  {
    yield return (object) new WaitForSeconds(0.1f);
    yield return (object) new WaitForSeconds(1f);
    this._anim.SetBool(this._hashAttack2, true);
    this._mover.move = true;
    yield return (object) new WaitForSeconds(0.8f);
    this._mover.move = false;
    yield return (object) new WaitForSeconds(1.7f);
    this._mover._isAttack2Active = false;
    this._anim.SetBool(this._hashAttack2, false);
  }

  public IEnumerator Die()
  {
    CuteBossRenderer cuteBossRenderer = this;
    if (!cuteBossRenderer._isDeath)
    {
      cuteBossRenderer._anim.SetBool(cuteBossRenderer._hashDie, true);
      cuteBossRenderer._isDeath = true;
      cuteBossRenderer.cuteBosssound3.SetActive(true);
      yield return (object) new WaitForSeconds(1f);
      cuteBossRenderer._anim.SetBool(cuteBossRenderer._hashDie, false);
      cuteBossRenderer._mover.move = false;
      cuteBossRenderer.enabled = false;
      cuteBossRenderer._teleport1.teleportOK = true;
    }
  }

  public IEnumerator CuteBossSound()
  {
    this.cutebosssound.SetActive(true);
    yield return (object) new WaitForSeconds(0.35f);
    this.cutebosssound.SetActive(false);
  }

  public IEnumerator CuteBossSound2()
  {
    this.cutebosssound2.SetActive(true);
    yield return (object) new WaitForSeconds(2f);
    this.cutebosssound2.SetActive(false);
  }

  public void Damage()
  {
    if (!this._mover.attack1)
      return;
    this._health.GetDamage(2, this._mover._Attack1Overlap);
  }

  public void Damage2()
  {
    if (!this._mover.attack2)
      return;
    this._health.GetDamage(4, this._mover._Attack2Overlap);
  }

  public void AttackEffecton() => this._cuteBossEffect.Attack2EffectON();

  public void AttackEffectoff() => this._cuteBossEffect.Attack2EffectOff();

  public void CheckOverlap1() => this._mover.CheckAttack1Hit();

  public void CheckOverlap2() => this._mover.CheckAttack2Hit();
}
