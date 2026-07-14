

using UnityEngine;

#nullable disable
public class SecondFirstManager : MonoBehaviour
{
  [SerializeField]
  private SecondFirstStory secondFirstStory;

  private void OnTriggerEnter2D(Collider2D other) => this.secondFirstStory.StartBattleEffect();
}
