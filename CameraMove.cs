
using System.Collections;
using UnityEngine;

#nullable disable
public class CameraMove : MonoBehaviour
{
  [SerializeField]
  private float _speed = 0.1f;
  [SerializeField]
  private float _rotation = 1f;
  [SerializeField]
  private int _count = 3;

  public IEnumerator PlayerHit()
  {
    CameraMove cameraMove = this;
    for (int i = 0; i <= cameraMove._count; ++i)
    {
      cameraMove.transform.rotation = Quaternion.Euler(0.0f, 0.0f, cameraMove._rotation);
      yield return (object) new WaitForSeconds(cameraMove._speed);
      cameraMove.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
  }
}
