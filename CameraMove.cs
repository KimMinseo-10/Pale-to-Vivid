// Decompiled with JetBrains decompiler
// Type: CameraMove
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

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
