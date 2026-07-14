

using UnityEngine;

#nullable disable
public class KingWangZZangHealth : MonoBehaviour
{
  [SerializeField]
  private CameraMove cameraMove;
  [SerializeField]
  private HealthBarUI healthBarUI;
  [SerializeField]
  private int maxHealth = 30;
  [SerializeField]
  private Teleport teleport;
  [SerializeField]
  private GreyerManage greyerManager;
  [SerializeField]
  private AudioFadeManager audioFadeManager;
  [SerializeField]
  private SceneFadeManager sceneFadeManager;
  [SerializeField]
  private int _kingWangZZangHealth;
  public bool IsDeath;
  private bool isfinish;
  [SerializeField]
  private KingWangZZangRenderer _renderer;
  private KingWangZZangMover _mover;

  private void Awake() => this._mover = this.GetComponent<KingWangZZangMover>();

  private void Start()
  {
    this.healthBarUI.InitHealth(this.maxHealth);
    this._kingWangZZangHealth = this.maxHealth;
    this.IsDeath = false;
  }

  public void GetDamage(int damage, Collider2D dealer)
  {
    this.StartCoroutine(this.cameraMove.PlayerHit());
    this._kingWangZZangHealth -= damage;
    this.healthBarUI.UpdateHealthUI(this._kingWangZZangHealth);
    if (this._kingWangZZangHealth > 0)
      return;
    this.teleport.teleportOK = true;
    this._renderer.enabled = false;
    this._mover.enabled = false;
    this.IsDeath = true;
    this.StartCoroutine(this._renderer.Die());
    this.WaitFadeIn();
  }

  private void WaitFadeIn()
  {
    if (this.isfinish)
      return;
    this.isfinish = true;
    this.greyerManager.FadeIn(1f);
    this.audioFadeManager.FadeOut(3f);
    this.sceneFadeManager.ChangeScene("The End 1");
  }
}
