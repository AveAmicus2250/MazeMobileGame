using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  public static class BaneExtenstions
  {
    #region Maths
    /// <summary>
    /// Remaps a value from a point in a range to a point in another range and returns it as a float.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_from1"></param>
    /// <param name="_to1"></param>
    /// <param name="_from2"></param>
    /// <param name="_to2"></param>
    /// <returns></returns>
    public static float Remap(this float _value, float _from1, float _to1, float _from2, float _to2)
    {
      return (_value - _from1) / (_to1 - _from1) * (_to2 - _from2) + _from2;
    }
    /// <summary>
    /// Remaps a value from a point in a range to a point in another range and returns it as a float.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_from1"></param>
    /// <param name="_to1"></param>
    /// <param name="_from2"></param>
    /// <param name="_to2"></param>
    /// <returns></returns>
    public static float Remap(this int _value, float _from1, float _to1, float _from2, float _to2)
    {
      return (_value - _from1) / (_to1 - _from1) * (_to2 - _from2) + _from2;
    }
    /// <summary>
    /// Returns true if given value is within the provided start and end values.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_start"></param>
    /// <param name="_end"></param>
    /// <returns></returns>
    public static bool WithinRange(this float _value, float _start, float _end)
    {
      if (_value >= _start && _value <= _end)
      {
        return true;
      }
      return false;
    }
    /// <summary>
    /// Returns true if given value is within the provided start and end values.
    /// </summary>
    /// <param name="_value"></param>
    /// <param name="_start"></param>
    /// <param name="_end"></param>
    /// <returns></returns>
    public static bool WithinRange(this int _value, float _start, float _end)
    {
      if (_value >= _start && _value <= _end)
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Returns the midpoint between two Vector3 values.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <returns></returns>
    public static Vector3 MidPoint(this Vector3 _pointA, Vector3 _pointB)
    {
      return (_pointA + _pointB) / 2;
    }   
    /// <summary>
    /// Returns the midpoint between two Vector2 values.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <returns></returns>
    public static Vector2 MidPoint(this Vector2 _pointA, Vector2 _pointB)
    {
      return (_pointA + _pointB) / 2;
    }

    /// <summary>
    /// Returns true if point A is within a given distance to point B.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <param name="_dist"></param>
    /// <returns></returns>
    public static bool CloseTo(this Vector3 _pointA, Vector3 _pointB, float _dist)
    {
      if (_pointA.x.WithinRange(_pointB.x + -_dist, _pointB.x + _dist) && _pointA.y.WithinRange(_pointB.y + -_dist, _pointB.y + _dist) && _pointA.z.WithinRange(_pointB.z + -_dist, _pointB.z + _dist))
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Returns true if point A is within a given distance to point B.
    /// </summary>
    /// <param name="_pointA"></param>
    /// <param name="_pointB"></param>
    /// <param name="_dist"></param>
    /// <returns></returns>
    public static bool CloseTo(this Vector2 _pointA, Vector2 _pointB, float _dist)
    {
      if (_pointA.x.WithinRange(_pointB.x + -_dist, _pointB.x + _dist) && _pointA.y.WithinRange(_pointB.y + -_dist, _pointB.y + _dist))
      {
        return true;
      }
      return false;
    }
    #endregion

    #region Transforms
    /// <summary>
    /// Returns true if the dot product of the objects reference direction is closer to the target direction being checked than the opposite direction. 
    /// <para>The Reference Axis is normal circumstances would be transform.up, while the Target Axis would be Vector3.Down. This returns true if the object's up is closer to world down than not. </para>
    /// <para>The Threshold is how close it needs to get before considering itself tilted. Closer to 1 means closer to the Target Axis. </para>
    /// </summary>
    /// <param name="_object"></param>
    /// <param name="_referenceAxis"></param>
    /// <param name="_targetAxis"></param>
    /// <param name="_threshold"></param>
    /// <returns></returns>
    public static bool Tilted(this Transform _object, Vector3 _referenceAxis, Vector3 _targetAxis, float _threshold = 0)
    {
      float _tiltAmount = Vector3.Dot(_referenceAxis, _targetAxis);

      return _tiltAmount > _threshold;
    }
    public static float Tilt(this Transform _object, Vector3 _referenceAxis, Vector3 _targetAxis)
    {
      return Vector3.Dot(_referenceAxis, _targetAxis);
    }

    #endregion

    #region Rays
  
    public static bool CanSee(this Transform _start, Transform _target)
    {
      RaycastHit hit;
      if (Physics.Linecast(_start.position, _target.position, out hit))
        if (hit.collider.transform != _target)
          return false;
      return true;
    }

    public static float KinematicVelocity(this Transform _object, Vector3 _lastPosition)
    {
      var pos = _object.position;
      var diff = (pos - _lastPosition);
      var velocity = diff / Time.deltaTime;

      var outVel = velocity.magnitude;

      return outVel;
    }

    #endregion

    #region Checks
    public static bool AllEqual(this bool[] _array, bool _value)
    {
      int count = 0;
      foreach (var element in _array)
      {
        if (element == _value)
        {
          count++;
        }
      }

      return count == _array.Length ? true : false;
    }

    public static bool[] Set(this bool[] _array, bool _value)
    {
      bool[] setArray = _array;
      for (int i = 0; i < setArray.Length; i++)
      {
        setArray[i] = false;
      }

      return setArray;
    }
    #endregion
  }
}