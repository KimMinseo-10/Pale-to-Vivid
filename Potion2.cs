

using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
public class Potion2 : MonoBehaviour
{
  [SerializeField]
  private PlayerMovement playerMovement;
  [SerializeField]
  private GameObject otherpotion;
  [SerializeField]
  private CuteBossHealth _cuteBossHealth;
  [SerializeField]
  private Potionname2 _potionname2;
  private bool _isPlayerInside;

  private void Start() => this.gameObject.SetActive(false);

  private void Update()
  {
    if (this._cuteBossHealth._cutieHealth > 0 || !this._isPlayerInside || !Keyboard.current.fKey.wasPressedThisFrame || !this.otherpotion.activeInHierarchy)
      return;
    this.playerMovement.normalattackDamage = 3;
    this.playerMovement.skillattackDamage = 5;
    this.gameObject.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    this._isPlayerInside = true;
    this._potionname2.StartBattleEffect();
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    this._isPlayerInside = false;
    this._potionname2.EndBattleEffect();
  }
}
