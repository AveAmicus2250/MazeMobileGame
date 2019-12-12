using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BT;

[CustomEditor(typeof(JoystickInput), true)]

public class JoystickEditor : Editor
{
    private SerializedProperty handlerRange;
    private SerializedProperty deadZone;

    private SerializedProperty axisOptions;
    private SerializedProperty snapX;
    private SerializedProperty snapY;

    protected SerializedProperty background;
    private SerializedProperty handle;

    //protected Vector2 centre = BaneMath.centre;
    protected Vector2 centre = new Vector2(0.5f, 0.5f);

    protected virtual void OnEnable()
    {
        handlerRange = serializedObject.FindProperty("handlerRange");
        deadZone = serializedObject.FindProperty("deadZone");

        axisOptions = serializedObject.FindProperty("axisOptions");
        snapX = serializedObject.FindProperty("snapX");
        snapY = serializedObject.FindProperty("snapY");

        background = serializedObject.FindProperty("background");
        handle = serializedObject.FindProperty("handle");
    }

    protected virtual void DrawValues()
    {
        EditorGUILayout.PropertyField(handlerRange, new GUIContent("Handle Range", "The distance the visual handle can move from the centre of the joystick"));
        EditorGUILayout.PropertyField(deadZone, new GUIContent("Dead Zone", "The distance away from the centre before input is registered"));

        EditorGUILayout.PropertyField(axisOptions, new GUIContent("Axis Options", "Which axes the joystick uses"));
        EditorGUILayout.PropertyField(snapX, new GUIContent("Snap to X", "Snap the joystick to the X axis"));
        EditorGUILayout.PropertyField(snapY, new GUIContent("Snap to Y", "Snap the joystick to the Y axis"));
    }

    protected virtual void DrawComponents()
    {
        EditorGUILayout.ObjectField(background, new GUIContent("Background", "The background's RectTransform component"));
        EditorGUILayout.ObjectField(handle, new GUIContent("Handle", "The handle's RectTransform component"));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawValues();
        EditorGUILayout.Space();
        DrawComponents();

        serializedObject.ApplyModifiedProperties();

        //if (handle != null)
        //{
        //    RectTransform handleRect = (RectTransform)handle.objectReferenceValue;

        //    handleRect.anchorMax = centre;
        //    handleRect.anchorMin = centre;
        //    handleRect.pivot = centre;
        //    handleRect.anchoredPosition = Vector2.zero;
        //}
    }
}
