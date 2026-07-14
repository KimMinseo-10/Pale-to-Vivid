// Decompiled with JetBrains decompiler
// Type: HealthBarUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HealthBarUI : MonoBehaviour
{
  [SerializeField]
  private GameObject lifePrefabs;
  private int healthCount;
  private GameObject[] lifes;

  public void InitHealth(int life)
  {
    this.healthCount = life;
    this.lifes = new GameObject[this.healthCount];
    for (int index = 0; index < this.healthCount; ++index)
      this.lifes[index] = Object.Instantiate<GameObject>(this.lifePrefabs, this.transform);
  }

  public void UpdateHealthUI(int life)
  {
    for (int index = 0; index < this.lifes.Length; ++index)
    {
      if (index < life)
        this.lifes[index].SetActive(true);
      else
        this.lifes[index].SetActive(false);
    }
  }
}
