
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
