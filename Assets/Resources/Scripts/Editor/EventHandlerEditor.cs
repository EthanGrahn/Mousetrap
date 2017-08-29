using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventHandler))]
[CanEditMultipleObjects]
public class EventHandlerEditor : Editor {

    EventHandler eh;

    void OnEnable()
    {
        eh = (EventHandler)target;   
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.EnumPopup("Event Type", eh.eventType);
        EditorGUILayout.Space();

        switch (eh.eventType)
        {
            case EventHandler.EventType.TEXT:
                EditorGUILayout.LabelField("Text To Display");
                EditorGUILayout.TextField(string.Empty, GUILayout.Height(150));
                EditorGUILayout.Space();
                break;
            case EventHandler.EventType.IMAGE:
                EditorGUILayout.LabelField("Image To Display");
                break;
            case EventHandler.EventType.CUTSCENE:
                break;
        }
    }
}
