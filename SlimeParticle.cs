
using UnityEngine;

#nullable disable
public class SlimeParticle : MonoBehaviour
{
  public GameObject hitParticle;

  private void Start()
  {
    if (!((Object) this.hitParticle != (Object) null))
      return;
    this.hitParticle.SetActive(false);
  }

  public void TakeDamage(Vector3 hitPoint)
  {
    if (!((Object) this.hitParticle != (Object) null))
      return;
    this.hitParticle.SetActive(false);
    this.hitParticle.transform.position = hitPoint;
    this.hitParticle.SetActive(true);
  }
}
