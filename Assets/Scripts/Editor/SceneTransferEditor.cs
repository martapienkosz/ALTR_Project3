using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//what class are we making the editor for
[CustomEditor(typeof(SceneTransfer))]


public class SceneTransferEditor : Editor
{
    SerializedProperty toScene;
    SerializedProperty changeLayer;
    SerializedProperty toLayer;

    void OnEnable()
    {
        toScene = serializedObject.FindProperty("toScene");
        changeLayer = serializedObject.FindProperty("changeLayer");
        toLayer = serializedObject.FindProperty("toLayer");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //default view
        EditorGUILayout.PropertyField(toScene);
        EditorGUILayout.PropertyField(changeLayer);


        if (changeLayer.boolValue)//true or false
        {
            int currentLayer = toLayer.intValue;
            //update according to user's choice;
            toLayer.intValue = EditorGUILayout.LayerField("To Layer", currentLayer);
        }

        //finish updating
        serializedObject.ApplyModifiedProperties();
    }


}