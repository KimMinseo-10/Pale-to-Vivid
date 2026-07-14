// Decompiled with JetBrains decompiler
// Type: PotionManage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

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
