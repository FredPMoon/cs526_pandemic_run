using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrahedron : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rebuild();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rebuild()
    {
        //Debug.Log("start");
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if(meshFilter == null){
            Debug.LogError("no MeshFilter");
            return;
        }

        // Vector3 p0 = new Vector3(0, 0, 0);
        // Vector3 p1 = new Vector3(0, 1, 0);
        // Vector3 p2 = new Vector3(Mathf.Sqrt(0.75f), 0.5f, 0);
        // Vector3 p3 = new Vector3(Mathf.Sqrt(0.75f)/3, 0.5f, Mathf.Sqrt(6)/3);
        // Vector3 p0 = new Vector3(0, 0, 0);
        // Vector3 p1 = new Vector3(1, 0, 0);
        // Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
        // Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f)/3);
        // Vector3 p0 = new Vector3(0, 0, 0);
        // Vector3 p1 = new Vector3(1, Mathf.Sqrt(2/3), -Mathf.Sqrt(1/3));
        // Vector3 p2 = new Vector3(-0.5f, Mathf.Sqrt(2/3), Mathf.Sqrt(0.75f)/3);
        // Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(2/3), Mathf.Sqrt(0.75f)/3);
        Vector3 p0 = new Vector3(-0.5f, 0, -Mathf.Sqrt(3)/6);
        Vector3 p1 = new Vector3(0.5f, 0, -Mathf.Sqrt(3)/6);
        Vector3 p2 = new Vector3(0, Mathf.Sqrt(6)/3, 0);
        Vector3 p3 = new Vector3(0, 0, Mathf.Sqrt(3)/3);
        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null){
            //Debug.Log("mesh");
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();

        mesh.vertices = new Vector3[] {p0, p1, p2, p3};
        mesh.triangles = new int[] {0, 1, 2,
                                    0, 2, 3,
                                    2, 1, 3,
                                    0, 3, 1};
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
