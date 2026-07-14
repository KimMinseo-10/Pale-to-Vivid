
using System.Collections;
using TMPro;
using UnityEngine;

#nullable disable
public class PotionMessage : MonoBehaviour
{
  [SerializeField]
  private TextMeshPro textMeshPro;
  private bool isfirst;

  private void Awake() => this.textMeshPro = this.GetComponent<TextMeshPro>();

  public void StartBattleEffect()
  {
    if (this.isfirst)
      return;
    this.StartCoroutine(this.FadeInAndOut());
    this.isfirst = true;
  }

  private IEnumerator FadeInAndOut()
  {
    PotionMessage potionMessage = this;
    yield return (object) potionMessage.StartCoroutine(potionMessage.FadeText(0.0f, 1f, 1f));
    yield return (object) new WaitForSeconds(3f);
  }

  private IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
  {
    float time = 0.0f;
    Color color = this.textMeshPro.color;
    while ((double) time < (double) duration)
    {
      time += Time.deltaTime;
      color.a = Mathf.Lerp(startAlpha, endAlpha, time / duration);
      this.textMeshPro.color = color;
      yield return (object) null;
    }
    color.a = endAlpha;
    this.textMeshPro.color = color;
  }
}
