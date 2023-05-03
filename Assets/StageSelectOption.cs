using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectOption : MonoBehaviour
{
  public GameManager.Stage Option;

  public StageSelectOption Right;
  public StageSelectOption Left;

  void Awake()
  {
    // unhilight all on awake
    Highlight(false);
  }

  public void Highlight(bool to)
  {
    var image = GetComponent<Image>();
    Color tempColor = image.color;
    tempColor.a = to ? 1f : 0.5f;
    image.color = tempColor;
    transform.GetChild(0).gameObject.SetActive(to);
  }
}
