// Decompiled with JetBrains decompiler
// Type: KingWangZZangRenderer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class KingWangZZangRenderer : MonoBehaviour
{
  private Animator _anim;
  [SerializeField]
  private KingWangZZangMover _mover;
  [SerializeField]
  private PlayerHealth _health;
  private int _hashDie = Animator.StringToHash("Die");
  private int _hashDownAttack = Animator.StringToHash("DownAttack");
  private int _hashUpAttack = Animator.StringToHash("UpAttack");
  private int _hashAttack1 = Animator.StringToHash("Attack1");
  private int _hashAttack2 = Animator.StringToHash("Attack2");
  private int _hashDash1 = Animator.StringToHash("Dash1");
  private int _hashDash2 = Animator.StringToHash("Dash2");
  private int _hashRun = Animator.StringToHash("Run");
  public bool _isDeath;
  public bool _isworking;
  private bool isfinish;
  [SerializeField]
  private Collider2D _coll;
  [SerializeField]
  private Transform kingtrm;
  [SerializeField]
  private Transform playertrm;
  [SerializeField]
  private GameObject kingSound;
  [SerializeField]
  private GameObject kingSound1;
  [SerializeField]
  private GameObject kingSound2;
  [SerializeField]
  private GameObject kingSound3;

  private void Awake() => this._anim = this.GetComponent<Animator>();

  private IEnumerator KingSound()
  {
    this.kingSound.SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.kingSound.SetActive(false);
  }

  private IEnumerator KingSound1()
  {
    this.kingSound1.SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.kingSound1.SetActive(false);
  }

  private IEnumerator KingSound2()
  {
    this.kingSound2.SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.kingSound2.SetActive(false);
  }

  private IEnumerator KingSound3()
  {
    this.kingSound3.SetActive(true);
    yield return (object) new WaitForSeconds(1f);
    this.kingSound3.SetActive(false);
  }

  public IEnumerator Attack1Animation()
  {
    yield return (object) new WaitForSeconds(0.1f);
    this._isworking = true;
    this._anim.SetBool(this._hashAttack1, true);
    yield return (object) new WaitForSeconds(0.25f);
    this._isworking = false;
    this._anim.SetBool(this._hashAttack1, false);
  }

  public IEnumerator Attack2Animation()
  {
    yield return (object) new WaitForSeconds(0.1f);
    this._isworking = true;
    this._anim.SetBool(this._hashAttack2, true);
    yield return (object) new WaitForSeconds(0.45f);
    this._isworking = false;
    this._anim.SetBool(this._hashAttack2, false);
  }

  public IEnumerator Attack3Animation()
  {
    yield return (object) new WaitForSeconds(0.1f);
    this._isworking = true;
    this._anim.SetBool(this._hashUpAttack, true);
    yield return (object) new WaitForSeconds(0.35f);
    this._isworking = false;
    this._anim.SetBool(this._hashUpAttack, false);
  }

  public IEnumerator Dash1Animation()
  {
    yield return (object) new WaitForSeconds(0.1f);
    this._isworking = true;
    this._mover.move = true;
    this._anim.SetBool(this._hashDash1, true);
    yield return (object) new WaitForSeconds(0.25f);
    this.kingtrm.position = (double) this.kingtrm.position.x <= (double) this.playertrm.position.x ? (Vector3) new Vector2(this.playertrm.position.x + 7f, this.kingtrm.position.y) : (Vector3) new Vector2(this.playertrm.position.x - 7f, this.kingtrm.position.y);
    this._isworking = false;
    this._mover.move = false;
    this._anim.SetBool(this._hashDash1, false);
  }

  public IEnumerator Die()
  {
    KingWangZZangRenderer wangZzangRenderer = this;
    if (!wangZzangRenderer._isDeath && !wangZzangRenderer.isfinish)
    {
      wangZzangRenderer.isfinish = true;
      wangZzangRenderer._isworking = true;
      wangZzangRenderer._anim.SetBool(wangZzangRenderer._hashDie, true);
      yield return (object) new WaitForSeconds(1f);
      wangZzangRenderer._anim.SetBool(wangZzangRenderer._hashDie, false);
      wangZzangRenderer.enabled = false;
      yield return (object) new WaitForSeconds(1f);
    }
  }

  public void Damage()
  {
    if (this._mover.attack1)
      this._health.GetDamage(2, this._mover._Attack1Overlap);
    this._mover.attack1 = false;
  }

  public void Damage1()
  {
    if (this._mover.attack2)
      this._health.GetDamage(3, this._mover._Attack1Overlap);
    this._mover.attack2 = false;
  }

  public void Damage2()
  {
    if (this._mover.attack3)
      this._health.GetDamage(1, this._mover._Attack1Overlap);
    this._mover.attack3 = false;
  }

  public void Damage3()
  {
    if (this._mover.attack4)
      this._health.GetDamage(1, this._mover._Attack1Overlap);
    this._mover.attack4 = false;
  }
}
