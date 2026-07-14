
using System.Collections;
using UnityEngine;

#nullable disable
public class SlimeMover : MonoBehaviour
{
  [SerializeField]
  private SlimeRenderer renderer;
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
  private GameObject slimeHealthUI;
  [SerializeField]
  private SlimeHeathUI bosshealthUI;
  private Vector3 dir;
  private Vector2 moveDir;
  [SerializeField]
  private float SkillCoolTime = 5f;
  public bool attack1;
  private bool _AttackStart;
  private bool _skillTime;
  private Rigidbody2D _rb;

  public bool move { private get; set; }

  public Collider2D _Attack1Overlap { get; private set; }

  public bool attack2 { get; private set; }

  public Collider2D _Attack2Overlap { get; private set; }

  private void Awake()
  {
    this.slimeHealthUI.SetActive(false);
    this._rb = this.GetComponent<Rigidbody2D>();
  }

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
    this.slimeHealthUI.SetActive(true);
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
  }

  private IEnumerator AttackStart()
  {
    SlimeMover slimeMover = this;
    slimeMover.bosshealthUI.gameObject.SetActive(true);
    slimeMover._skillTime = true;
    if (!slimeMover.renderer._isDeath)
    {
      switch (Random.Range(1, 6))
      {
        case 1:
        case 2:
        case 3:
          slimeMover.StartCoroutine(slimeMover.Attack1Zone());
          slimeMover._Attack1Overlap = Physics2D.OverlapBox((Vector2) (slimeMover.transform.position + (Vector3) slimeMover.attack1offset), slimeMover.attack1boxSize, 0.0f);
          slimeMover.attack1 = (bool) (Object) Physics2D.OverlapBox((Vector2) (slimeMover.transform.position + (Vector3) slimeMover.attack1offset), slimeMover.attack1boxSize, 0.0f, (int) slimeMover.Player);
          slimeMover.StartCoroutine(slimeMover.renderer.Attack1Animation());
          break;
        case 4:
        case 5:
          slimeMover.StartCoroutine(slimeMover.Attack2Zone());
          slimeMover._Attack2Overlap = Physics2D.OverlapBox((Vector2) (slimeMover.transform.position + (Vector3) slimeMover.attack2offset), slimeMover.attack2boxSize, 0.0f);
          slimeMover.attack2 = (bool) (Object) Physics2D.OverlapBox((Vector2) (slimeMover.transform.position + (Vector3) slimeMover.attack2offset), slimeMover.attack2boxSize, 0.0f, (int) slimeMover.Player);
          slimeMover.StartCoroutine(slimeMover.renderer.Attack2Animation());
          break;
      }
      yield return (object) new WaitForSeconds(slimeMover.SkillCoolTime);
    }
    else
      slimeMover.enabled = false;
    slimeMover._skillTime = false;
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
}
