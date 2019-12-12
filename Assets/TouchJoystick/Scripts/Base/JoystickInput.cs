using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using BT;

public class JoystickInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
  #region Serialized
  [SerializeField] float handlerRange = 1;
  [SerializeField] float deadZone = 0;
  [SerializeField] AxisOption axisOptions = AxisOption.Both;
  [SerializeField] bool snapX = false;
  [SerializeField] bool snapY = false;
  [SerializeField] protected RectTransform background = null;
  [SerializeField] protected RectTransform handle = null;
  #endregion

  #region References
  protected RectTransform baseRect = null;
  Canvas canvas;
  Camera cam;
  [SerializeField] Vector2 input = Vector2.zero;
  #endregion

  #region Properties
  public float Horizontal
  {
    get { return (snapX) ? SnapFloat(input.x, AxisOption.Horizontal) : input.x; }
  }
  public float Vertical
  {
    get { return (snapY) ? SnapFloat(input.y, AxisOption.Vertical) : input.y; }
  }
  public Vector2 Direction
  {
    get { return new Vector2(Horizontal, Vertical); }
  }
  public float HandleRange
  {
    get { return handlerRange; }
    set { handlerRange = Mathf.Abs(value); }
  }
  public float DeadZone
  {
    get { return deadZone; }
    set { deadZone = Mathf.Abs(value); }
  }
  public AxisOption AxisOptions { get; set; }
  public bool SnapX { get; set; }
  public bool SnapY { get; set; }
  #endregion

  float SnapFloat(float _val, AxisOption _ax)
  {
    if (_val == 0)
    {
      return _val;
    }
    if (axisOptions == AxisOption.Both)
    {
      float angle = Vector2.Angle(input, Vector2.up);

      switch (_ax)
      {
        case AxisOption.Horizontal:
          return angle.WithinRange(22.5f, 157.5f) ? ((_val > 0) ? 1 : -1) : 0;
        case AxisOption.Vertical:
          return angle.WithinRange(67.5f, 112.5f) ? ((_val > 0) ? 1 : -1) : 0;
      }
      return _val;
    }
    else
    {
      return (_val > 0 ? 1 : -1);
    }
  }

  protected virtual void Start()
  {
    HandleRange = handlerRange;
    DeadZone = deadZone;
    baseRect = GetComponent<RectTransform>();
    canvas = GetComponentInParent<Canvas>();

    if (!canvas)
    {
      print("Canvas not found. \nHave you placed the gameobject within the Canvas?");
    }

    Vector2 centre = new Vector2(.5f, .5f);
    background.pivot = centre;

    handle.anchorMin = centre;
    handle.anchorMax = centre;

    handle.pivot = centre;
    handle.anchoredPosition = Vector2.zero;
  }

  private void FormatInput()
  {
    switch (axisOptions)
    {
      case AxisOption.Horizontal:
        input = new Vector2(input.x, 0f);
        break;
      case AxisOption.Vertical:
        input = new Vector2(0f, input.y);
        break;
    }
  }

  protected virtual void HandleInput(float _mag, Vector2 _norm, Vector2 _rad, Camera _cam)
  {
    if (_mag > deadZone)
    {
      if (_mag > 1)
      {
        input = _norm;
      }
    }
    else
    {
      input = Vector2.zero;
    }
  }

  protected Vector2 ScreenPointToAnchoredPosition(Vector2 _screenPos)
  {
    Vector2 _localPoint = Vector2.zero;
    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, _screenPos, cam, out _localPoint))
    {
      return _localPoint - (background.anchorMax * baseRect.sizeDelta);
    }
    return _localPoint;
  }

  public virtual void OnDrag(PointerEventData eventData)
  {
    cam = null;
    if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
    {
      cam = canvas.worldCamera;
    }

    Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
    Vector2 radius = background.sizeDelta / 2;

    input = (eventData.position - position) / (radius * canvas.scaleFactor);
    FormatInput();
    HandleInput(input.magnitude, input.normalized, radius, cam);
    handle.anchoredPosition = input * radius * handlerRange;
  }

  public virtual void OnPointerDown(PointerEventData eventData)
  {
    //input = Vector2.zero;
    OnDrag(eventData);
  }

  public virtual void OnPointerUp(PointerEventData eventData)
  {
    input = Vector2.zero;
    handle.anchoredPosition = Vector2.zero;
  }

  public Vector2 GetAxis()
  {
    return input;
  }
}

public enum AxisOption
{
  Both,
  Horizontal,
  Vertical
}
