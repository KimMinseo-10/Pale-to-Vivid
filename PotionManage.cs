
using UnityEngine;

#nullable disable
public class PotionManage : MonoBehaviour
{
  [SerializeField]
  private PotionMessage message;
  [SerializeField]
  private PotionTutorial tutorial;
  [SerializeField]
  private GameObject potion;
  [SerializeField]
  private GameObject potion2;
  [SerializeField]
  private CuteBossHealth cuteie;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!this.cuteie.IsDeath)
      return;
    Debug.Log((object) "인식");
    this.message.StartBattleEffect();
    this.tutorial.StartBattleEffect();
    this.potion.SetActive(true);
    this.potion2.SetActive(true);
  }
}
