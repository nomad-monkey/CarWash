using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using PaintIn3D;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
   
    [SerializeField] private LayerMask cubeMask;
    [SerializeField] private Transform yCorrector;
    [SerializeField] private Transform yCorrectorUp;
    [SerializeField] private Transform car;
    [SerializeField] private float upper;
    [SerializeField] private float lower;
    [SerializeField] private GameObject cube;
   
    [SerializeField] private bool isCarHigh;
    [SerializeField] private List<GameObject> foamCubeList;
    [SerializeField] private List<GameObject> waterCubeList;
    [SerializeField] private List<GameObject> dryerCubeList;
    
    [SerializeField] private Material dirtMaterial;

    private CWCarManager carManager;

    private GameObject foamParent;
    private GameObject dryerParent;
    private GameObject waterParent;

    
   

    public void AddComponents()
    {

        MeshCollider meshCollider = car.GetComponent<MeshCollider>();

        if (!meshCollider)
        {
            meshCollider = car.AddComponent<MeshCollider>();
        }
        
        
        P3dPaintable paintable = car.GetComponent<P3dPaintable>();

        if (!paintable)
        {
            paintable=  car.AddComponent<P3dPaintable>();
        }
        
        P3dMaterialCloner cloner = car.GetComponent<P3dMaterialCloner>();

        if (!cloner )
        {
            cloner= car.AddComponent<P3dMaterialCloner>();
            
        }
        cloner.Index = 1; 
        
        P3dPaintableTexture paintableTexture = car.GetComponent<P3dPaintableTexture>();

        if (paintableTexture  == null)
        {
            paintableTexture = car.AddComponent<P3dPaintableTexture>();
        }

        paintableTexture.Coord = P3dCoord.Second;

        paintableTexture.Slot = new P3dSlot(1, "_MainTex");
        
        
        MeshRenderer renderer = car.GetComponent<MeshRenderer>();

        if (renderer != null)
        {
            renderer.sharedMaterials[0] = renderer.sharedMaterials[0];
            renderer.sharedMaterials[1] = dirtMaterial;
        }
       
        car.gameObject.layer = 13;

        carManager = car.GetComponent<CWCarManager>();

        if (carManager  == null)
        {
            carManager = car.AddComponent<CWCarManager>();
        }
        
        
    }

    public void PlaceFoamObjects()
    {


        Vector3[] meshPoints = car.GetComponent<MeshFilter>().sharedMesh.vertices;
        int[] tris = car.GetComponent<MeshFilter>().sharedMesh.triangles;


        for (int i = 0; i < 10; i++)
        {

            for (int z = 0; z < 10; z++)
            {

                // int triStart = Random.Range(0, meshPoints.Length / 3) * 3; // get first index of each triangle



                // int triStart = Random.Range(0, meshPoints.Length / 3) * 3; // get first index of each triangle
                int triStart = i * 100 + z * 20;
                float a = Random.value;
                float b = Random.value;

                if (a + b >= 1)
                {
                    // reflect back if > 1
                    a = 1 - a;
                    b = 1 - b;
                }

                Vector3 newPointOnMesh = meshPoints[triStart] +
                                         (a * (meshPoints[triStart + 1] - meshPoints[triStart])) +
                                         (b * (meshPoints[triStart + 2] -
                                               meshPoints[
                                                   triStart])); // apply formula to get new random point inside triangle

                GameObject newCube = Instantiate(cube, newPointOnMesh, Quaternion.identity);
                foamCubeList.Add(newCube);

            }
        }

    }
    
    public void CreateParentObjects ()
    {
        GameObject objToSpawn = new GameObject();
        waterParent = Instantiate(objToSpawn, car.position,car.rotation,car);
        waterParent.name = "waterParent";
        
         dryerParent = Instantiate(objToSpawn, car.position,car.rotation,car);
        dryerParent.name ="dryerParent";
        
       foamParent = Instantiate(objToSpawn, car.position,car.rotation,car);
        foamParent.name ="foamParent";
        
    }

    public void SetFirstObjects()
    {
        foreach (GameObject cube  in  foamCubeList)
        {
            cube.GetComponent<BoxCollider>().isTrigger = true;
            cube.GetComponent<MeshRenderer>().enabled = false;
            cube.layer = 6;
            cube.transform.SetParent(foamParent.transform);
            cube.name = "FoamCube";

        }
        
        
    }
    
    
    public void CopyFirstObjects()
    {
        foreach (GameObject cube  in  foamCubeList)
        {
            GameObject newCube=  Instantiate(cube,cube.transform.position,cube.transform.rotation);
            waterCubeList.Add(newCube);
            newCube.GetComponent<BoxCollider>().isTrigger = true;
            newCube.GetComponent<MeshRenderer>().enabled = false;
            newCube.layer = 7;
            newCube.transform.SetParent(waterParent.transform);
            newCube.name = "WaterCube";

        }
        
        foreach (GameObject cube  in  foamCubeList)
        {
            GameObject newCube = Instantiate(cube,cube.transform.position,cube.transform.rotation);
            dryerCubeList.Add(newCube);
            newCube.GetComponent<BoxCollider>().isTrigger = true;
            newCube.GetComponent<MeshRenderer>().enabled = false;
            newCube.layer = 8;
            newCube.transform.SetParent(dryerParent.transform);
            newCube.name = "DryerCube";

        }
        
        
    }

    public void AssignCubesToCar()
    {
        carManager.foamCubes = foamCubeList;
        carManager.waterCubes = waterCubeList;
        carManager.dryerCubes = dryerCubeList;
    }

    public void NewCar()
    {
        foamCubeList.Clear();
        foamCubeList.Capacity = 0;
        waterCubeList.Clear();
        waterCubeList.Capacity = 0;
        dryerCubeList.Clear();
        dryerCubeList.Capacity = 0;


    }

        public void CleanCubes()
    {
        
        foreach (GameObject cube  in  foamCubeList)
        {
           DestroyImmediate(cube);
           foamCubeList = new List<GameObject>();
           foamCubeList.Capacity = 0;

        }
        foreach (GameObject cube  in  waterCubeList)
        {
            DestroyImmediate(cube);
            waterCubeList = new List<GameObject>();
            waterCubeList.Capacity = 0;

        }

        foreach (GameObject cube  in  dryerCubeList)
        {
            DestroyImmediate(cube);
            dryerCubeList = new List<GameObject>();
            dryerCubeList.Capacity = 0;

        }
        
        carManager.foamCubes = foamCubeList;
        carManager.waterCubes = waterCubeList;
        carManager.dryerCubes = dryerCubeList;
    }
    
    
    

    
    public void PlaceRandomObjects()
    {

        for (int i = 0; i < 50; i++)
        {
            bool collisionWithOtherCube = false;
          
            GameObject newCube = Instantiate(cube, (Random.onUnitSphere * 7f) + car.position, Quaternion.identity);

            Vector3 direction = (car.position - newCube.transform.position).normalized;
            Debug.Log(direction);
            RaycastHit hitPoint;
            Physics.Raycast(newCube.transform.position, direction, out hitPoint, Mathf.Infinity);

            Debug.DrawRay(newCube.transform.position, direction, Color.blue);

            if (hitPoint.transform != null && hitPoint.transform.gameObject.layer == 13)
            {
                newCube.transform.position = hitPoint.point;
                Debug.Log("Hit");
                
                if ( (newCube.transform.position.y < yCorrector.position.y) || (isCarHigh && newCube.transform.position.y > yCorrectorUp.position.y))
                {
                    DestroyImmediate(newCube);
                            
                }
                else
                {
                    Collider[] hitColliders = Physics.OverlapSphere(newCube.transform.position, 0.5f);

                    if (hitColliders.Length > 0)
                    {
                        foreach (Collider collider in hitColliders)
                        {
                            if (collider.gameObject.layer == 15)
                            {
                                Debug.Log("Cube");
                                collisionWithOtherCube = true;
                            }
                        }

                        if (collisionWithOtherCube)
                            // Debug.Log("Added");
                            DestroyImmediate(newCube);
                        else
                        {
                            Debug.Log("Added");
                            foamCubeList.Add(newCube);
                        }

                    }
                    else
                    {
                        Debug.Log("Added");
                        foamCubeList.Add(newCube);
                    }
                    
                }

                
            }
            else
            {
                Debug.Log("NoHit");
                DestroyImmediate(newCube);
            }

        }

    }

    
   
}
