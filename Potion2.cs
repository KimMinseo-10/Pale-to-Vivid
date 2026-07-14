// Decompiled with JetBrains decompiler
// Type: Potion2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40EE2C12-5186-4819-9200-6B792B4A111D
// Assembly location: C:\Users\minse\Downloads\Pale to Vivid(2026학년도 1학기 개인프로젝트)\Pale2Vivid\2026_1st_solo_project_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
public class Potion2 : MonoBehaviour
{
  [SerializeField]
  private PlayerMovement playerMovement;
  [SerializeField]
  private GameObject otherpotion;
  [SerializeField]
  private CuteBossHealth _cuteBossHealth;
  [SerializeField]
  private Potionname2 _potionname2;
  private bool _isPlayerInside;

  private void Start() => this.gameObject.SetActive(false);

  private void Update()
  {
    if (this._cuteBossHealth._cutieHealth > 0 || !this._isPlayerInside || !Keyboard.current.fKey.wasPressedThisFrame || !this.otherpotion.activeInHierarchy)
      return;
    this.playerMovement.normalattackDamage = 3;
    this.playerMovement.skillattackDamage = 5;
    this.gameObject.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    this._isPlayerInside = true;
    this._potionname2.StartBattleEffect();
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    this._isPlayerInside = false;
    this._potionname2.EndBattleEffect();
  }
}
