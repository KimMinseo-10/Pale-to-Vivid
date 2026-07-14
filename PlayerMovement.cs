// Decompiled with JetBrains decompiler
// Type: PlayerMovement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  private QskillUICoolTime coolTimeUI;
  [SerializeField]
  private FootStepSound footStepSound;
  [SerializeField]
  private float speed = 5f;
  [SerializeField]
  private PlayerRenderer renderer;
  [SerializeField]
  private SlimeHealth slimeHealth;
  [SerializeField]
  private CuteBossHealth cuteBossHealth;
  [SerializeField]
  private KingWangZZangHealth kingWangZZangHealth;
  private PlayerHealth _playerHealth;
  private Collider2D _collider;
  private float _attack3Cooltime = 5f;
  private float _attack3NextAttack;
  private float _attack1Cooltime = 0.43f;
  private float _attack1NextAttack;
  [SerializeField]
  private float jumpPower = 5f;
  private Rigidbody2D _rb;
  private bool isGrounded;
  private bool isAttack;
  private Collider2D attackCollider;
  private bool attack;
  private bool isQskill;
  private bool qskill;
  private Collider2D qskillCollider;
  [SerializeField]
  private LayerMask whatisEnemy;
  [SerializeField]
  private LayerMask whatisGround;
  [SerializeField]
  private Vector2 boxSize;
  [SerializeField]
  private Vector2 offset;
  [SerializeField]
  private Vector2 attackBoxSize;
  [SerializeField]
  private Vector2 attackOffset;
  [SerializeField]
  private Vector2 qskillBoxSize;
  [SerializeField]
  private Vector2 qskillOffset;
  [SerializeField]
  private GameObject clickSound;
  private Transform PlayerTrm;
  public int normalattackDamage = 1;
  public int skillattackDamage = 3;
  [SerializeField]
  private GameObject qskillSound;

  public Vector2 moveDir { get; private set; }

  private void Awake()
  {
    this._rb = this.GetComponent<Rigidbody2D>();
    this._playerHealth = this.GetComponent<PlayerHealth>();
  }

  private void Update()
  {
    this.PlayerTrm = this.transform;
    this.isAttack = (bool) (Object) Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.attackOffset), this.attackBoxSize, 0.0f, (int) this.whatisEnemy);
    this.attackCollider = Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.attackOffset), this.attackBoxSize, 0.0f);
    this.attack = (bool) (Object) Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.attackOffset), this.attackBoxSize, 0.0f, (int) this.whatisEnemy);
    this.qskillCollider = Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.qskillOffset), this.qskillBoxSize, 0.0f);
    this.qskill = (bool) (Object) Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.qskillOffset), this.qskillBoxSize, 0.0f, (int) this.whatisEnemy);
    if ((double) this.moveDir.x > 0.10000000149011612)
      this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    if ((double) this.moveDir.x < -0.10000000149011612)
      this.transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
    this.isGrounded = (bool) (Object) Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.offset), this.boxSize, 0.0f, (int) this.whatisGround);
    if (Keyboard.current.qKey.isPressed)
      this.Qskill();
    if (this.isGrounded && (double) this._rb.linearVelocity.sqrMagnitude > 0.10000000149011612)
      this.footStepSound.PlayFootStepContinuous();
    else
      this.footStepSound.ResetTimer();
  }

  private void FixedUpdate()
  {
    this._rb.linearVelocity = new Vector2(this.moveDir.x * this.speed, this._rb.linearVelocity.y);
  }

  private void OnClick()
  {
    if (this._playerHealth.IsDeath || (double) Time.time < (double) this._attack1NextAttack)
      return;
    this.StartCoroutine(this.ClickSound());
    this._attack1NextAttack = Time.time + this._attack1Cooltime;
    this.StartCoroutine(this.renderer.Attack1Animation());
    if (!this.attack)
      return;
    this.slimeHealth.GetDamage(this.normalattackDamage, this.attackCollider);
    if (this.slimeHealth.IsDeath)
      this.cuteBossHealth.GetDamage(this.normalattackDamage, this.attackCollider);
    if (!this.cuteBossHealth.IsDeath)
      return;
    this.kingWangZZangHealth.GetDamage(this.normalattackDamage, this.attackCollider);
  }

  private IEnumerator ClickSound()
  {
    this.clickSound.SetActive(true);
    yield return (object) new WaitForSeconds(0.4f);
    this.clickSound.SetActive(false);
  }

  private void OnJump()
  {
    if (!this.isGrounded || this._playerHealth.IsDeath)
      return;
    this._rb.linearVelocity = Vector2.zero;
    this._rb.AddForce(Vector2.up * this.jumpPower, ForceMode2D.Impulse);
    this.StartCoroutine(this.renderer.JumpAnimation());
  }

  private void OnMove(InputValue value)
  {
    if (this._playerHealth.IsDeath)
      return;
    this.moveDir = value.Get<Vector2>();
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.offset, (Vector3) this.boxSize);
    Gizmos.color = Color.green;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.attackOffset, (Vector3) this.attackBoxSize);
    Gizmos.color = Color.blue;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.qskillOffset, (Vector3) this.qskillBoxSize);
  }

  private void Qskill()
  {
    if ((double) Time.time < (double) this._attack3NextAttack)
      return;
    this._attack3NextAttack = Time.time + this._attack3Cooltime;
    this.StartCoroutine(this.coolTimeUI.CooldownRoutine(this._attack3Cooltime));
    this.StartCoroutine(this.renderer.QskillAnimation());
    this.StartCoroutine(this.QskillSound());
    if (!this.qskill)
      return;
    this.slimeHealth.GetDamage(this.skillattackDamage, this.qskillCollider);
    if (this.slimeHealth.IsDeath)
      this.cuteBossHealth.GetDamage(this.skillattackDamage, this.qskillCollider);
    if (!this.cuteBossHealth.IsDeath)
      return;
    this.kingWangZZangHealth.GetDamage(this.skillattackDamage, this.qskillCollider);
  }

  private IEnumerator QskillSound()
  {
    this.qskillSound.SetActive(true);
    yield return (object) new WaitForSeconds(0.5f);
    this.qskillSound.SetActive(false);
  }
}
