using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

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
        eh.eventType = (EventHandler.EventType)EditorGUILayout.EnumPopup("Event Type", eh.eventType);
        EditorGUILayout.Space();

        switch (eh.eventType)
        {
            case EventHandler.EventType.TEXT:
                EditorGUILayout.LabelField("Text To Display");
                EditorStyles.textField.wordWrap = true;
                eh.textToDisplay = EditorGUILayout.TextArea(eh.textToDisplay, GUILayout.Height(150), GUILayout.ExpandHeight(true));
                EditorGUILayout.Space();
                break;
            case EventHandler.EventType.IMAGE:
                EditorGUILayout.LabelField("Image To Display");
                eh.imageToDisplay = (Sprite)EditorGUILayout.ObjectField(eh.imageToDisplay, typeof(Sprite), false);
                EditorGUILayout.Space();
                break;
            case EventHandler.EventType.CUTSCENE:
                eh.sceneToLoad = EditorGUILayout.ObjectField("Unity Scene", eh.sceneToLoad, typeof(Object), true);
                EditorGUILayout.Space();
                break;
        }
        
    }
}
