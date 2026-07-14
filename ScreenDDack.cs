

using UnityEngine;

#nullable disable
public class ScreenDDack : MonoBehaviour
{
  private void Start() => this.SetResolution();

  public void SetResolution()
  {
    int width1 = 1920;
    int num = 1080;
    int width2 = Screen.width;
    int height1 = Screen.height;
    Screen.SetResolution(width1, (int) ((double) height1 / (double) width2 * (double) width1), true);
    if ((double) width1 / (double) num < (double) width2 / (double) height1)
    {
      float width3 = (float) ((double) width1 / (double) num / ((double) width2 / (double) height1));
      Camera.main.rect = new Rect((float) ((1.0 - (double) width3) / 2.0), 0.0f, width3, 1f);
    }
    else
    {
      float height2 = (float) ((double) width2 / (double) height1 / ((double) width1 / (double) num));
      Camera.main.rect = new Rect(0.0f, (float) ((1.0 - (double) height2) / 2.0), 1f, height2);
    }
  }
}
