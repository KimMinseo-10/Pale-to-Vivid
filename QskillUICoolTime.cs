

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class QskillUICoolTime : MonoBehaviour
{
  [SerializeField]
  private Image CooldownImage;

  private void Awake() => this.gameObject.SetActive(false);

  public IEnumerator CooldownRoutine(float time)
  {
    QskillUICoolTime qskillUiCoolTime = this;
    qskillUiCoolTime.gameObject.SetActive(true);
    qskillUiCoolTime.CooldownImage.fillAmount = 1f;
    while ((double) qskillUiCoolTime.CooldownImage.fillAmount > 0.0)
    {
      qskillUiCoolTime.CooldownImage.fillAmount -= Time.deltaTime / time;
      yield return (object) null;
    }
    qskillUiCoolTime.CooldownImage.fillAmount = 0.0f;
    qskillUiCoolTime.gameObject.SetActive(false);
  }
}
