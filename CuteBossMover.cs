

using System.Collections;
using UnityEngine;

#nullable disable
public class CuteBossMover : MonoBehaviour
{
  [SerializeField]
  private CuteBossRenderer renderer;
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
  private float zone1Time = 5f;
  [SerializeField]
  private float zone2Time = 2.5f;
  [SerializeField]
  private Vector3 dir;
  private Vector2 moveDir;
  [SerializeField]
  private float SkillCoolTime = 5f;
  [SerializeField]
  private GameObject cuteBossHealthUI;
  [SerializeField]
  private SlimeHeathUI bosshealthUI;
  public bool attack1;
  private bool _AttackStart;
  private bool _skillTime;
  [SerializeField]
  private SecondStageStory sss;

  public bool move { private get; set; }

  public Collider2D _Attack1Overlap { get; private set; }

  [field: SerializeField]
  public bool attack2 { get; private set; }

  public Collider2D _Attack2Overlap { get; private set; }

  public bool _isAttack1Active { set; private get; }

  public bool _isAttack2Active { set; private get; }

  private void Awake() => this.cuteBossHealthUI.SetActive(false);

  private void Update()
  {
    this.dir = (this.playertrm.position - this.transform.position).normalized;
    if (this.move && (double) this.dir.x > 0.10000000149011612)
    {
      this.transform.Translate(new Vector3(-this.dir.normalized.x * this.speed * Time.deltaTime, 0.0f, 0.0f));
      this.transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
    }
    else if (this.move && (double) this.dir.x < -0.10000000149011612)
    {
      this.transform.Translate(new Vector3(this.dir.normalized.x * this.speed * Time.deltaTime, 0.0f, 0.0f));
      this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
    if (this._skillTime)
      return;
    this._AttackStart = (bool) (Object) Physics2D.OverlapBox((Vector2) (this.transform.position + (Vector3) this.offset), this.boxSize, 0.0f, (int) this.Player);
    if (!this._AttackStart)
      return;
    this.cuteBossHealthUI.SetActive(true);
    Debug.Log((object) "감지");
    this.StartCoroutine(this.StartAttack());
  }

  private IEnumerator StartAttack()
  {
    CuteBossMover cuteBossMover = this;
    cuteBossMover.sss.StartBattleEffect();
    cuteBossMover.bosshealthUI.gameObject.SetActive(true);
    cuteBossMover._skillTime = true;
    switch (Random.Range(1, 6))
    {
      case 1:
      case 2:
      case 3:
        cuteBossMover._isAttack1Active = true;
        cuteBossMover.StartCoroutine(cuteBossMover.Attack1Zone());
        cuteBossMover.StartCoroutine(cuteBossMover.renderer.Attack1Animation());
        break;
      default:
        cuteBossMover._isAttack2Active = true;
        cuteBossMover.StartCoroutine(cuteBossMover.Attack2Zone());
        cuteBossMover.StartCoroutine(cuteBossMover.renderer.Attack2Animation());
        break;
    }
    yield return (object) new WaitForSeconds(cuteBossMover.SkillCoolTime);
    cuteBossMover._skillTime = false;
  }

  public bool CheckAttack1Hit()
  {
    this._Attack1Overlap = Physics2D.OverlapBox((Vector2) (this.transform.position + ((double) this.transform.eulerAngles.y > 90.0 ? new Vector3(-this.attack1offset.x, this.attack1offset.y, 0.0f) : (Vector3) this.attack1offset)), this.attack1boxSize, 0.0f, (int) this.Player);
    this.attack1 = (Object) this._Attack1Overlap != (Object) null;
    return this.attack1;
  }

  public bool CheckAttack2Hit()
  {
    this._Attack2Overlap = Physics2D.OverlapBox((Vector2) (this.transform.position + ((double) this.transform.eulerAngles.y > 90.0 ? new Vector3(-this.attack2offset.x, this.attack2offset.y, 0.0f) : (Vector3) this.attack2offset)), this.attack2boxSize, 0.0f, (int) this.Player);
    this.attack2 = (Object) this._Attack2Overlap != (Object) null;
    return this.attack2;
  }

  private IEnumerator Attack1Zone()
  {
    this.attack1Zone.SetActive(true);
    yield return (object) new WaitForSeconds(this.zone1Time);
    this.attack1Zone.SetActive(false);
  }

  private IEnumerator Attack2Zone()
  {
    this.attack2Zone.SetActive(true);
    yield return (object) new WaitForSeconds(this.zone2Time);
    this.attack2Zone.SetActive(false);
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.dodgerBlue;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.offset, (Vector3) this.boxSize);
    Gizmos.color = Color.orangeRed;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.attack1offset, (Vector3) this.attack1boxSize);
    Gizmos.color = Color.softGreen;
    Gizmos.DrawWireCube(this.transform.position + (Vector3) this.attack2offset, (Vector3) this.attack2boxSize);
  }
}
