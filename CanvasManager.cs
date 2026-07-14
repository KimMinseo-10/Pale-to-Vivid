
using System.Collections;
using UnityEngine;

#nullable disable
public class CanvasManager : MonoBehaviour
{
  [SerializeField]
  private GameObject XUI;

  public IEnumerator XuiManager(float time)
  {
    this.XUI.SetActive(true);
    yield return (object) new WaitForSeconds(time);
    this.XUI.SetActive(false);
  }
}
