using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(LightManager))]
public class LightManagerEditor : Editor
{    
    GameObject[] lights;
    float intensity;
    


    private void OnEnable()
    {
        lights = GameObject.FindGameObjectsWithTag("Lamps");
        intensity = lights[0].GetComponent<Light>().intensity;
      
    }




    public override void OnInspectorGUI()
    {
        intensity = EditorGUILayout.Slider(intensity, 0f, 1f);

        foreach (var light in lights)
        {
            light.GetComponent<Light>().intensity = intensity;
        }

      
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
