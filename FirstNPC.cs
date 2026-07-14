

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class FirstNPC : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
  public TextMeshProUGUI ScriptText_dialogue;
  public string sceneName;
  public string[] dialogue;
  public int dialogue_count;
  [SerializeField]
  private SceneFadeManager scenefademanager;
  [SerializeField]
  private AudioFadeManager audioFadeManager;
  [SerializeField]
  private GameObject clickSound;
  private bool isfinish;

  public void OnPointerDown(PointerEventData data)
  {
    this.StartCoroutine(this.ClickSound());
    if (this.dialogue_count < this.dialogue.Length && !this.isfinish)
    {
      this.ScriptText_dialogue.text = this.dialogue[this.dialogue_count];
      ++this.dialogue_count;
    }
    else
    {
      if (this.dialogue_count != this.dialogue.Length || this.isfinish)
        return;
      Debug.Log((object) "대화 종료");
      this.audioFadeManager.FadeOut(3f);
      this.scenefademanager.ChangeScene(this.sceneName);
      this.dialogue_count = 0;
      this.isfinish = true;
    }
  }

  private IEnumerator ClickSound()
  {
    this.clickSound.SetActive(true);
    yield return (object) new WaitForSeconds(0.3f);
    this.clickSound.SetActive(false);
  }
}
