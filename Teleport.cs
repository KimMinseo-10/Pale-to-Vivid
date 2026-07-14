
using System.Collections;
using UnityEngine;

#nullable disable
public class Teleport : MonoBehaviour
{
  [SerializeField]
  private GameObject teleport;
  public bool teleportOK;
  [SerializeField]
  private GreyerManage greyerManage;
  [SerializeField]
  private PlayerHealth health;
  [SerializeField]
  private HealthBarUI _healthBarUI;
  public bool isfinish;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!(other.tag == "Player") || !this.teleportOK)
      return;
    other.transform.position = this.teleport.transform.position + new Vector3(3f, 0.0f, 0.0f);
    this.isfinish = true;
    this.health._playerHealth = this.health.maxHealth;
    this._healthBarUI.UpdateHealthUI(this.health._playerHealth);
    this.StartCoroutine(this.StageSwitch());
  }

  private IEnumerator StageSwitch()
  {
    yield return (object) new WaitForSeconds(0.3f);
    this.greyerManage.FadeOut(0.5f);
  }
}
