using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{

    [SerializeField] private int layerMask;
    [SerializeField] private Transform car;
    [SerializeField] private float upper;
    [SerializeField] private float lower;
    [SerializeField] private GameObject cube;

    [SerializeField] private List<GameObject> foamCubeList;

    public void PlaceObjects()
    {
        Vector3[] meshPoints = car.GetComponent<MeshFilter>().sharedMesh.vertices;
        // Vector3[] meshPoints = car.GetComponent<MeshFilter>().mesh.vertices;
        // int[] tris = car.GetComponent<MeshFilter>().mesh.triangles;
        int[] tris = car.GetComponent<MeshFilter>().sharedMesh.triangles;
        Debug.Log(tris.Length);
        int triStart = Random.Range(0, meshPoints.Length / 3) * 3; // get first index of each triangle

        float a = Random.value;
        float b = Random.value;

        if (a + b >= 1)
        {
            // reflect back if > 1
            a = 1 - a;
            b = 1 - b;
        }

        Vector3 newPointOnMesh = meshPoints[triStart] + (a * (meshPoints[triStart + 1] - meshPoints[triStart])) +
                                 (b * (meshPoints[triStart + 2] -
                                       meshPoints[triStart])); // apply formula to get new random point inside triangle

        newPointOnMesh = car.TransformPoint(newPointOnMesh); // convert back to worldspace

        for (int i = 0; i < 100; i++)
        {

            float r = Random.Range(upper, lower);
            Debug.Log(r);
            Vector3 rayOrigin = ((Random.onUnitSphere * r) + car.position); // put the ray randomly around the transform
            RaycastHit hitPoint;
            Physics.Raycast(rayOrigin, newPointOnMesh - rayOrigin, out hitPoint, 100f, layerMask);
            GameObject newCube = Instantiate(cube, hitPoint.point, Quaternion.identity);

            foamCubeList.Add(newCube);

        }


    }

    public void PlaceObjects2()
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
}
