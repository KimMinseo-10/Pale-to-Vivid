

using System.Collections;
using UnityEngine;

#nullable disable
public class PlayerRenderer : MonoBehaviour
{
  private Animator _anim;
  private SpriteRenderer _spriter;
  [SerializeField]
  private PlayerMovement _movement;
  private int _hashAttack1 = Animator.StringToHash("Attack1");
  private int _hashJump = Animator.StringToHash("Jump");
  private int _hashQskill = Animator.StringToHash("Qskill");
  private int _hashDead = Animator.StringToHash("Dead");
  private Vector2 moveDir;

  private void Awake()
  {
    this._anim = this.GetComponent<Animator>();
    this._spriter = this.GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    this.moveDir = this._movement.moveDir;
    this._anim.SetFloat("Speed", this.moveDir.magnitude);
  }

  public void Dead() => this._anim.SetTrigger(this._hashDead);

  public IEnumerator Attack1Animation()
  {
    this._anim.SetBool(this._hashAttack1, true);
    yield return (object) new WaitForSeconds(0.43f);
    this._anim.SetBool(this._hashAttack1, false);
  }

  public void Qskill() => this._anim.SetBool(this._hashQskill, true);

  public IEnumerator QskillAnimation()
  {
    this._anim.SetBool(this._hashQskill, true);
    yield return (object) new WaitForSeconds(0.5f);
    this._anim.SetBool(this._hashQskill, false);
  }

  public IEnumerator JumpAnimation()
  {
    this._anim.SetBool(this._hashJump, true);
    yield return (object) new WaitForSeconds(1f);
    this._anim.SetBool(this._hashJump, false);
  }
}
