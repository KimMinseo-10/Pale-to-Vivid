// Decompiled with JetBrains decompiler
// Type: Wall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class Wall : MonoBehaviour
{
  [SerializeField]
  private GameObject wallSentence;
  private bool isworking;

  private void Start() => this.wallSentence.SetActive(false);

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!this.isworking)
      this.StartCoroutine(this.SaveTheWorld());
    if ((double) this.transform.position.x > 100.0 && (double) this.transform.position.x < 110.0)
      other.transform.position = other.transform.position + new Vector3(0.6f, 0.0f, 0.0f);
    else if ((double) this.transform.position.x < -8.0)
      other.transform.position = other.transform.position + new Vector3(0.6f, 0.0f, 0.0f);
    else
      other.transform.position = other.transform.position + new Vector3(-0.6f, 0.0f, 0.0f);
  }

  private IEnumerator SaveTheWorld()
  {
    this.isworking = true;
    this.wallSentence.SetActive(true);
    yield return (object) new WaitForSeconds(3f);
    this.wallSentence.SetActive(false);
    this.isworking = false;
  }
}
