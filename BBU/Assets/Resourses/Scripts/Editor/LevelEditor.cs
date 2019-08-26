using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level), true)]
public class LevelEditor : Editor
{
    protected static string LEVELPROPERTY_FACTORY_NAME = "LevelType";
    protected Level levelObject;
    protected SerializedObject serializedLevel;
    protected SerializedProperty SerializedLevelProperty;

    void OnEnable()
    {
        levelObject = (Level)target;
        serializedLevel = new SerializedObject(levelObject);
        SerializedLevelProperty = serializedLevel.FindProperty(LEVELPROPERTY_FACTORY_NAME);
    }
    public override void OnInspectorGUI()
    {
        serializedLevel.Update();
        DrawPropertiesExcluding(serializedLevel, new string[] { LEVELPROPERTY_FACTORY_NAME });
        DrawLevelType();
        serializedLevel.ApplyModifiedProperties();
    }

    protected void DrawLevelType()
    {
        EditorGUILayout.LabelField(LEVELPROPERTY_FACTORY_NAME, EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(SerializedLevelProperty.FindPropertyRelative("Type"));

        LevelPropertyFactory levelPropertyFactory = levelObject.LevelType;
        System.Type typeOfLevelProperty = levelPropertyFactory.GetClassType(levelPropertyFactory.Type);
        SerializedProperty specificLevelProperty = (SerializedLevelProperty.FindPropertyRelative(typeOfLevelProperty.ToString())).Copy();
        string parentPath = specificLevelProperty.propertyPath;
        while (specificLevelProperty.NextVisible(true) && specificLevelProperty.propertyPath.StartsWith(parentPath))
        {
            EditorGUILayout.PropertyField(specificLevelProperty);
        }
    }
}
