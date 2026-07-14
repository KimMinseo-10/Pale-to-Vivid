// Decompiled with JetBrains decompiler
// Type: KingWangZZangMover
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class KingWangZZangMover : MonoBehaviour
{
  [SerializeField]
  private KingWangZZangRenderer renderer;
  [SerializeField]
  private Vector2 boxSize;
  [SerializeField]
  private Vector2 offset;
  [SerializeField]
  private Vector2 attack1boxSize;
  [SerializeField]
  private Vector2 attack1offset;
  [SerializeField]
  private Vector2 attack2boxSize;
  [SerializeField]
  private Vector2 attack2offset;
  [SerializeField]
  private Vector2 attack3boxSize;
  [SerializeField]
  private Vector2 attack3offset;
  [SerializeField]
  private Vector2 attack4boxSize;
  [SerializeField]
  private Vector2 attack4offset;
  [SerializeField]
  private LayerMask Player;
  [SerializeField]
  private float speed = 5f;
  [SerializeField]
  private Transform playertrm;
  [SerializeField]
  private GameObject attack1Zone;
  [SerializeField]
  private GameObject attack2Zone;
  [SerializeField]
  private GameObject attack3Zone;
  [SerializeField]
  private GameObject kingWangZZangHealthUI;
  [SerializeField]
  private SlimeHeathUI bosshealthUI;
  private Vector3 dir;
  private Vector2 moveDir;
  [SerializeField]
  private float SkillCoolTime = 5f;
  public bool attack4;
  public bool attack1;
  public bool attack2;
  public bool attack3;
  private bool _AttackStart;
  private bool _skillTime;
  private bool isfirst = true;
  [SerializeField]
  private GameObject bossUI;

  public bool move { private get; set; }

  public Collider2D _Attack1Overlap { get; private set; }

  public Collider2D _Attack4Overlap { get; private set; }

  public Collider2D _Attack2Overlap { get; private set; }

  public Collider2D _Attack3Overlap { get; private set; }

  private void Awake()
  {
    this.kingWangZZangHealthUI.SetActive(false);
    this.bossUI.SetActive(false);
  }

  private void Update()
  {
    this.dir = (this.playertrm.position - this.transform.position).normalized;
    if ((double) this.dir.x < 0.10000000149011612 && !this.renderer._isworking)
    {
      if (this.move)
        this.transform.Translate(new Vector3(-this.dir.normalized.x * this.speed * Time.deltaTime, 0.0f, 0.0f));
      this.transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
    }
    else if ((double) this.dir.x > -0.10000000149011612 && !this.renderer._isworking)
    {
      if (this.move)
        this.transform.Translate(new Vector3(this.dir.normalized.x * this.speed * Time.deltaTime, 0.0f, 0.0f));
      this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
    if (this._skillTime)
      return;
    this._AttackStart = (bool) (Object) Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.offset), this.boxSize, 0.0f, (int) this.Player);
    if (!this._AttackStart)
      return;
    this.bossUI.SetActive(true);
    this.kingWangZZangHealthUI.SetActive(true);
    this.StartCoroutine(this.AttackStart());
    Debug.Log((object) "감지");
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.offset, (Vector3) this.boxSize);
    Gizmos.color = Color.aquamarine;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.attack1offset, (Vector3) this.attack1boxSize);
    Gizmos.color = Color.darkOrange;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.attack2offset, (Vector3) this.attack2boxSize);
    Gizmos.color = Color.greenYellow;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.attack3offset, (Vector3) this.attack3boxSize);
    Gizmos.color = Color.blueViolet;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.attack4offset, (Vector3) this.attack4boxSize);
  }

  private IEnumerator AttackStart()
  {
    KingWangZZangMover kingWangZzangMover = this;
    kingWangZzangMover._skillTime = true;
    if (!kingWangZzangMover.renderer._isDeath)
    {
      switch (Random.Range(1, 10))
      {
        case 1:
        case 2:
          kingWangZzangMover.StartCoroutine(kingWangZzangMover.Attack1Zone());
          kingWangZzangMover._Attack1Overlap = Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack1offset), kingWangZzangMover.attack1boxSize, 0.0f);
          kingWangZzangMover.attack1 = (bool) (Object) Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack1offset), kingWangZzangMover.attack1boxSize, 0.0f, (int) kingWangZzangMover.Player);
          kingWangZzangMover.StartCoroutine(kingWangZzangMover.renderer.Attack1Animation());
          break;
        case 3:
        case 4:
          kingWangZzangMover.StartCoroutine(kingWangZzangMover.Attack2Zone());
          kingWangZzangMover._Attack2Overlap = Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack2offset), kingWangZzangMover.attack2boxSize, 0.0f);
          kingWangZzangMover.attack2 = (bool) (Object) Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack2offset), kingWangZzangMover.attack2boxSize, 0.0f, (int) kingWangZzangMover.Player);
          kingWangZzangMover.StartCoroutine(kingWangZzangMover.renderer.Attack2Animation());
          break;
        case 5:
        case 6:
          kingWangZzangMover.StartCoroutine(kingWangZzangMover.Attack3Zone());
          kingWangZzangMover._Attack3Overlap = Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack3offset), kingWangZzangMover.attack3boxSize, 0.0f);
          kingWangZzangMover.attack3 = (bool) (Object) Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack3offset), kingWangZzangMover.attack3boxSize, 0.0f, (int) kingWangZzangMover.Player);
          kingWangZzangMover.StartCoroutine(kingWangZzangMover.renderer.Attack3Animation());
          break;
        case 7:
        case 8:
        case 9:
          kingWangZzangMover._Attack4Overlap = Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack4offset), kingWangZzangMover.attack4boxSize, 0.0f);
          kingWangZzangMover.attack3 = (bool) (Object) Physics2D.OverlapBox((Vector2) (kingWangZzangMover.transform.position + (Vector3) kingWangZzangMover.attack4offset), kingWangZzangMover.attack4boxSize, 0.0f, (int) kingWangZzangMover.Player);
          kingWangZzangMover.StartCoroutine(kingWangZzangMover.renderer.Dash1Animation());
          break;
      }
      yield return (object) new WaitForSeconds(kingWangZzangMover.SkillCoolTime);
    }
    else
      kingWangZzangMover.enabled = false;
    kingWangZzangMover._skillTime = false;
  }

  private IEnumerator Attack1Zone()
  {
    this.attack1Zone.SetActive(true);
    yield return (object) new WaitForSeconds(0.5f);
    this.attack1Zone.SetActive(false);
  }

  private IEnumerator Attack2Zone()
  {
    this.attack2Zone.SetActive(true);
    yield return (object) new WaitForSeconds(0.5f);
    this.attack2Zone.SetActive(false);
  }

  private IEnumerator Attack3Zone()
  {
    this.attack3Zone.SetActive(true);
    yield return (object) new WaitForSeconds(0.5f);
    this.attack3Zone.SetActive(false);
  }
}
