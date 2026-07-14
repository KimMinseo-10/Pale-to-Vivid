

using UnityEngine;

#nullable disable
public class SlimeHeathUI : MonoBehaviour
{
  [SerializeField]
  private SlimeHealth slimeHealth;
  [SerializeField]
  private CuteBossHealth cuteBossHealth;
  [SerializeField]
  private GameObject teleport;
  [SerializeField]
  private bool slimeisDead;

  private void Awake() => this.gameObject.SetActive(false);

  private void Update()
  {
    if (this.cuteBossHealth.IsDeath)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      if (!this.slimeHealth.IsDeath || this.slimeisDead)
        return;
      this.gameObject.SetActive(false);
      this.teleport.SetActive(true);
      this.slimeisDead = true;
    }
  }
}
