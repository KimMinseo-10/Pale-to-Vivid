using UnityEngine;

#nullable disable
public class ToTheEnd : MonoBehaviour
{
  [SerializeField]
  private SceneFadeManager sceneFadeManager;
  [SerializeField]
  private TheEnd theEnd;

  public void OnMouseDown()
  {
    if (!this.theEnd.finish)
      return;
    this.sceneFadeManager.ChangeScene("The End 1");
  }
}
