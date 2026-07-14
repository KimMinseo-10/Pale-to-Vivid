

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
