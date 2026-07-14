

using System.Collections;
using UnityEngine;

#nullable disable
public class SlimeRenderer : MonoBehaviour
{
  private Animator _anim;
  private SpriteRenderer _spriter;
  [SerializeField]
  private SlimeMover _mover;
  [SerializeField]
  private PlayerHealth _health;
  [SerializeField]
  private GameObject slimesound;
  [SerializeField]
  private GameObject slimesound2;
  private int _hashDie = Animator.StringToHash("Die");
  private int _hashAttack1Animation = Animator.StringToHash("Attack1Animation");
  private int _hashAttack2Animation = Animator.StringToHash("Attack2Animation");
  public bool _isDeath;

  private void Awake()
  {
    this._anim = this.GetComponent<Animator>();
    this._spriter = this.GetComponent<SpriteRenderer>();
  }

  public IEnumerator Attack1Animation()
  {
    yield return (object) new WaitForSeconds(1f);
    this._anim.SetBool(this._hashAttack1Animation, true);
    this.slimesound.SetActive(true);
    this._mover.move = true;
    yield return (object) new WaitForSeconds(1.4f);
    this.slimesound.SetActive(false);
    this._mover.move = false;
    this._anim.SetBool(this._hashAttack1Animation, false);
  }

  public IEnumerator Attack2Animation()
  {
    yield return (object) new WaitForSeconds(1f);
    this._anim.SetBool(this._hashAttack2Animation, true);
    this.slimesound2.SetActive(true);
    yield return (object) new WaitForSeconds(0.5f);
    this.slimesound2.SetActive(false);
    this._anim.SetBool(this._hashAttack2Animation, false);
  }

  public IEnumerator Die()
  {
    SlimeRenderer slimeRenderer = this;
    if (!slimeRenderer._isDeath)
    {
      slimeRenderer._anim.SetBool(slimeRenderer._hashDie, true);
      slimeRenderer.slimesound2.SetActive(true);
      yield return (object) new WaitForSeconds(1f);
      slimeRenderer._anim.SetBool(slimeRenderer._hashDie, false);
      slimeRenderer._mover.move = false;
      slimeRenderer.enabled = false;
      yield return (object) new WaitForSeconds(1f);
      slimeRenderer.slimesound2.SetActive(false);
      slimeRenderer.gameObject.SetActive(false);
    }
  }

  public void Damage()
  {
    if (this._mover.attack1)
      this._health.GetDamage(1, this._mover._Attack1Overlap);
    this._mover.attack1 = false;
  }
}
