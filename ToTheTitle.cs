using System.Collections;
using UnityEngine;

#nullable disable
public class ToTheTitle : MonoBehaviour
{
  [SerializeField]
  private SceneFadeManager sceneFadeManager;
  [SerializeField]
  private GameObject clickSound;

  public void OnMouseDown()
  {
    this.StartCoroutine(this.ClickSound());
    this.sceneFadeManager.ChangeScene("Start");
  }

  public IEnumerator ClickSound()
  {
    this.clickSound.SetActive(true);
    yield return (object) new WaitForSeconds(0.3f);
    this.clickSound.SetActive(false);
  }
}
