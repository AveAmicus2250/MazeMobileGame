using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VariableJoystick : JoystickInput
{
  public float MoveThreshold
  {
    get { return moveThreshold; }
    set { moveThreshold = Mathf.Abs(value); }
  }

  [SerializeField]
  float moveThreshold = 1f;
  [SerializeField]
  JoystickType joystickType = JoystickType.Fixed;
  Vector2 fixedPosition = Vector2.zero;

  public void SetMode(JoystickType _joyType)
  {
    joystickType = _joyType;
    //_joyType = joystickType;
    if (_joyType == JoystickType.Fixed)
    {
      background.anchoredPosition = fixedPosition;
      background.gameObject.SetActive(true);

      print("Set Mode to Fixed");
      //baseRect.sizeDelta = new Vector2(215, 215);
    }
    else
    {
      print("Set Mode from Fixed");

      background.gameObject.SetActive(false);
      //baseRect.sizeDelta = GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta;
    }
  }

  protected override void Start()
  {
    base.Start();
    fixedPosition = background.anchoredPosition;
    SetMode(joystickType);
  }

  private void Update()
  {
    //SetMode(joystickType);
  }

  public override void OnPointerDown(PointerEventData eventData)
  {
    base.OnPointerDown(eventData);

    //SetMode(joystickType);

    if (joystickType != JoystickType.Fixed)
    {
      background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
      handle.anchoredPosition = Vector2.zero;
      background.gameObject.SetActive(true);
    }
  }

  public override void OnPointerUp(PointerEventData eventData)
  {
    base.OnPointerUp(eventData);
    if (joystickType != JoystickType.Fixed)
    {
      background.gameObject.SetActive(false);
    }
  }

  protected override void HandleInput(float _mag, Vector2 _norm, Vector2 _rad, Camera _cam)
  {
    base.HandleInput(_mag, _norm, _rad, _cam);
    if (joystickType == JoystickType.Dynamic && _mag > moveThreshold)
    {
      Vector2 difference = _norm * (_mag - moveThreshold) * _rad;
      background.anchoredPosition += difference;
    }
  }

  public enum JoystickType
  {
    Fixed,
    Floating,
    Dynamic
  }
}
