

using System.Collections;
using UnityEngine;

#nullable disable
public class PlayerHealth : MonoBehaviour
{
  public int maxHealth = 30;
  [SerializeField]
  private HealthBarUI _healthBarUI;
  [SerializeField]
  private SceneFadeManager scenefademanager;
  [SerializeField]
  private FirstStageSound sound;
  [SerializeField]
  private VinetteManag3er vignette;
  public int _playerHealth;
  [SerializeField]
  private PlayerRenderer _renderer;
  private bool isfinish;

  public bool IsDeath { get; private set; }

  private void Start()
  {
    this._healthBarUI.InitHealth(this.maxHealth);
    this._playerHealth = this.maxHealth;
    this.IsDeath = false;
  }

  public void GetDamage(int damage, Collider2D dealer)
  {
    Debug.Log((object) "아야");
    this._playerHealth -= damage;
    this.StartCoroutine(this.vignette.VignetteOn());
    this._healthBarUI.UpdateHealthUI(this._playerHealth);
    if (this._playerHealth > 0 || this.isfinish)
      return;
    this.isfinish = true;
    this.StartCoroutine(this.Dead());
    this.IsDeath = true;
    this._renderer.Dead();
    this.sound.StartFadeOut();
  }

  private IEnumerator Dead()
  {
    yield return (object) new WaitForSeconds(0.5f);
    this.scenefademanager.ChangeScene("DeadScene");
  }
}
