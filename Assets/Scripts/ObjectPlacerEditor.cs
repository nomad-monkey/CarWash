using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;



[CustomEditor(typeof(ObjectPlacer))]
public class ObjectPlacerEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        ObjectPlacer myScript = (ObjectPlacer)target;
        
        if(GUILayout.Button("Spawn First Objects"))
        {
            myScript.PlaceObjects2();
        }
        
        
       
        
        
       
    }
}

      
#endif

