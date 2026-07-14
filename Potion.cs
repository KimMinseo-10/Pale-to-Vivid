
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
public class Potion : MonoBehaviour
{
  [SerializeField]
  private PlayerHealth _playerHealth;
  [SerializeField]
  private GameObject otherpotion;
  [SerializeField]
  private CuteBossHealth _cuteBossHealth;
  [SerializeField]
  private Potionname1 _potionname1;
  private bool _isPlayerInside;

  private void Start() => this.gameObject.SetActive(false);

  private void Update()
  {
    if (!this._cuteBossHealth.IsDeath || !this._isPlayerInside || !Keyboard.current.fKey.wasPressedThisFrame || !this.otherpotion.activeInHierarchy)
      return;
    this._playerHealth.maxHealth = 15;
    this.gameObject.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    this._isPlayerInside = true;
    this._potionname1.StartBattleEffect();
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    this._isPlayerInside = false;
    this._potionname1.EndBattleEffect();
  }
}
