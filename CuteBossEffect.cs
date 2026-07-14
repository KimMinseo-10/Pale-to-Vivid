// Decompiled with JetBrains decompiler
// Type: CuteBossEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CuteBossEffect : MonoBehaviour
{
  private Animator _anim;
  private int _hashAttack2 = Animator.StringToHash("Attack2");
  [SerializeField]
  private PlayerHealth _health;
  [SerializeField]
  private CuteBossMover _mover;

  private void Awake() => this._anim = this.GetComponent<Animator>();

  public void Attack2EffectON() => this._anim.SetBool(this._hashAttack2, true);

  public void Attack2EffectOff() => this._anim.SetBool(this._hashAttack2, false);
}
