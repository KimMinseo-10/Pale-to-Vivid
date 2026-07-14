

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

#nullable disable
public class VinetteManag3er : MonoBehaviour
{
  [SerializeField]
  private Volume _volume;
  private Vignette vignette;
  private bool isworking;

  private void Awake()
  {
    Vignette component;
    if (!((Object) this._volume != (Object) null) || !this._volume.profile.TryGet<Vignette>(out component))
      return;
    this.vignette = component;
  }

  public IEnumerator VignetteOn()
  {
    if (!this.isworking)
    {
      this.isworking = true;
      this.vignette.intensity.value = 0.5f;
      yield return (object) new WaitForSeconds(0.5f);
      this.vignette.intensity.value = 0.0f;
      this.isworking = false;
    }
  }
}
