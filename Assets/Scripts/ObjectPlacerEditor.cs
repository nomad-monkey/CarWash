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
        
        if(GUILayout.Button("AddComponents"))
        {
            myScript.AddComponents();
        }
        
        if(GUILayout.Button("Create Parent Objects"))
        {
            myScript.CreateParentObjects();
        }
      
        if(GUILayout.Button("Random Cubes"))
        {
            myScript.PlaceRandomObjects();
        }
     
        
        if(GUILayout.Button("Set First Cubes"))
        {
            myScript.SetFirstObjects();
        }
        
        if(GUILayout.Button("Copy Objects to Other Lists"))
        {
            myScript.CopyFirstObjects();
        }

        if(GUILayout.Button("Set Car Manager"))
        {
            myScript.AssignCubesToCar();
        }
        
        
        if(GUILayout.Button("Remove Cubes"))
        {
            myScript.CleanCubes();
        }
        
        
        if(GUILayout.Button("New Car"))
        {
            myScript.NewCar();
        }
        

        
       
    }
}

      
#endif

