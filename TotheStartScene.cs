

using System.Collections;
using UnityEngine;

#nullable disable
public class TotheStartScene : MonoBehaviour
{
  [SerializeField]
  private SceneFadeManager sceneFadeManager;
  [SerializeField]
  private AudioFadeManager audioFadeManager;
  [SerializeField]
  private GameObject clickSound;

  public void OnMouseDown()
  {
    this.StartCoroutine(this.ClickSound());
    this.audioFadeManager.FadeOut(3f);
    this.sceneFadeManager.ChangeScene("Start");
  }

  public IEnumerator ClickSound()
  {
    this.clickSound.SetActive(true);
    yield return (object) new WaitForSeconds(0.3f);
    this.clickSound.SetActive(false);
  }
}
