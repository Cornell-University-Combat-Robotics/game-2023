using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{

  public int PlayerID = 0;
  private Color[] _cursorColors = { Color.red, Color.blue, Color.yellow, Color.green };
  private Vector2 _inputDirection;
  private float _cursorSpeed = 200f;
  private RectTransform _rectTransform;
  // private VirtualMouseInput _virtualMouse;
  private Text _playerNumText;

  void Start()
  {
    // synchronize UI events
    GetComponent<PlayerInput>().uiInputModule = GameObject.Find("EventSystem").GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
    _rectTransform = GetComponent<RectTransform>();
    transform.SetParent(GameObject.Find("Canvas").transform);
    _rectTransform.anchoredPosition = Vector2.zero;
    GetComponent<Image>().color = _cursorColors[PlayerID];
    _playerNumText = _rectTransform.GetChild(0).GetComponent<Text>();
    _playerNumText.color = _cursorColors[PlayerID];
    _playerNumText.text = "P" + PlayerID.ToString();
  }

  void Update()
  {
    Debug.Log("YIPEEEE!");
  }
}
