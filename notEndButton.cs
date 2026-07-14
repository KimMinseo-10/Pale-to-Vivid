// Decompiled with JetBrains decompiler
// Type: notEndButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class notEndButton : MonoBehaviour
{
  [SerializeField]
  private TheEnd theEnd;
  private Button button;
  private Image image;

  private void Awake()
  {
    this.button = this.GetComponent<Button>();
    this.image = this.GetComponent<Image>();
  }

  private void Start()
  {
    if ((Object) this.button != (Object) null)
      this.button.enabled = false;
    if ((Object) this.image != (Object) null)
      this.image.enabled = false;
    int childCount = this.transform.childCount;
    for (int index = 0; index < childCount; ++index)
      this.transform.GetChild(index).gameObject.SetActive(false);
  }

  private void Update()
  {
    if ((Object) this.theEnd == (Object) null || !this.theEnd.finish)
      return;
    if ((Object) this.button != (Object) null)
      this.button.enabled = true;
    if ((Object) this.image != (Object) null)
      this.image.enabled = true;
    int childCount = this.transform.childCount;
    for (int index = 0; index < childCount; ++index)
      this.transform.GetChild(index).gameObject.SetActive(true);
    this.enabled = false;
  }
}
