

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SlimeEffect : MonoBehaviour
{
  public static SlimeEffect Instance;
  public GameObject hitParticlePrefab;
  public int poolSize = 10;
  private List<GameObject> particlePool = new List<GameObject>();

  private void Awake() => SlimeEffect.Instance = this;

  private void Start()
  {
    for (int index = 0; index < this.poolSize; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.hitParticlePrefab);
      gameObject.SetActive(false);
      this.particlePool.Add(gameObject);
    }
  }

  public void ShowHitEffect(Vector3 hitPoint)
  {
    for (int index = 0; index < this.particlePool.Count; ++index)
    {
      if (!this.particlePool[index].activeInHierarchy)
      {
        this.particlePool[index].transform.position = hitPoint;
        this.particlePool[index].SetActive(true);
        this.StartCoroutine(this.TurnOffParticle(this.particlePool[index], 2f));
        return;
      }
    }
    GameObject particle = Object.Instantiate<GameObject>(this.hitParticlePrefab);
    particle.transform.position = hitPoint;
    particle.SetActive(true);
    this.particlePool.Add(particle);
    this.StartCoroutine(this.TurnOffParticle(particle, 2f));
  }

  private IEnumerator TurnOffParticle(GameObject particle, float delay)
  {
    yield return (object) new WaitForSeconds(delay);
    if ((Object) particle != (Object) null)
      particle.SetActive(false);
  }
}
