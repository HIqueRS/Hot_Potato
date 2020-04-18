using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(LightManager))]
public class LightManagerEditor : Editor
{    
    Light[] lights;
    float intensity;

    private void OnEnable()
    {
        lights = GameObject.FindObjectsOfType<Light>();
      
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        EditorGUILayout.Slider(0f, 0f, 1f);





        serializedObject.ApplyModifiedProperties();
    }
}
#endif
public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
