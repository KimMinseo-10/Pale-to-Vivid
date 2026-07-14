
using UnityEngine;

#nullable disable
public class StartAudioManager : MonoBehaviour
{
  [SerializeField]
  private AudioFadeManager fademanager;

  private void Start() => this.fademanager.FadeIn(3f);
}
