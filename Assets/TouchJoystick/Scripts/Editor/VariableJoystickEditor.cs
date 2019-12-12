using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BT;

[CustomEditor(typeof(VariableJoystick), true)]
public class VariableJoystickEditor : JoystickEditor
{
    private SerializedProperty moveThreshold;
    private SerializedProperty joystickType;

    protected override void OnEnable()
    {
        base.OnEnable();

        moveThreshold = serializedObject.FindProperty("moveThreshold");
        joystickType = serializedObject.FindProperty("joystickType");
    }

    protected override void DrawValues()
    {
        base.DrawValues();

        EditorGUILayout.PropertyField(moveThreshold, new GUIContent("Move Threshold", "The distance the joystick has to be from the centre before the joystick begins to move"));
        EditorGUILayout.PropertyField(joystickType, new GUIContent("Joystick Type", "The type of joystick"));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawValues();
        EditorGUILayout.Space();
        DrawComponents();

        serializedObject.ApplyModifiedProperties();

        //if (background != null)
        //{
        //    RectTransform backgroundRect = (RectTransform)background.objectReferenceValue;

        //    backgroundRect.anchorMin = centre;
        //    backgroundRect.anchorMax = centre;
        //    backgroundRect.pivot = centre;
        //    backgroundRect.anchoredPosition = Vector2.zero;
        //}
    }
}
