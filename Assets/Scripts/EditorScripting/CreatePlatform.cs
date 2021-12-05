using UnityEditor;
using UnityEngine;

public class DashEditor : EditorWindow
{
    float zValue;
    float xValue;
    int count = 5;
    GameObject parent;

    [MenuItem("Window/Create Platform")]
    public static void ShowWindow()
    {
        GetWindow<DashEditor>("Create Platform Editor");
    }
    private void OnGUI()
    {
        GUILayout.Label("Create From Selected Object", EditorStyles.boldLabel);
        GUILayout.Label("X Value", EditorStyles.boldLabel);
        xValue = EditorGUILayout.FloatField(xValue);
        GUILayout.Label("Z Value", EditorStyles.boldLabel);
        zValue = EditorGUILayout.FloatField(zValue);
        GUILayout.Label("Count", EditorStyles.boldLabel);
        count = EditorGUILayout.IntField(count);
        parent = GameObject.FindGameObjectWithTag("Parent");

        if (GUILayout.Button("Create Platform"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                for (int i = 0; i < count; i++)
                {
                    GameObject go = Instantiate(obj);
                    Vector3 goPosition = obj.transform.position;
                    goPosition.x += xValue * (i + 1);
                    goPosition.z += zValue * (i + 1);
                    go.transform.position = goPosition;
                    go.transform.SetParent(parent.transform);
                }
            }
        }

    }
}
