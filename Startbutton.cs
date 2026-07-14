
using UnityEngine;

#nullable disable
public class Startbutton : MonoBehaviour
{
  [SerializeField]
  private AudioFadeManager fademanager;
  [SerializeField]
  private SceneFadeManager sceneFadeManager;
  [SerializeField]
  private GameObject clickSound;

  public void OnMouseDown()
  {
    this.clickSound.SetActive(true);
    this.FadeOut();
  }

  private void FadeOut()
  {
    this.fademanager.FadeOut(3f);
    this.sceneFadeManager.ChangeScene("Story");
  }
}
