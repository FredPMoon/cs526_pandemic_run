using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TetrahedronEditor : Editor
{
    [MenuItem("GameObject/3D Object/Tetrahedron")]
    static void Create()
    {
        GameObject GO = new GameObject("Tetrahedron");
        Tetrahedron tetrahedron = GO.AddComponent<Tetrahedron>();
        MeshFilter mf = GO.AddComponent<MeshFilter>();
        mf.mesh = new Mesh();
        MeshRenderer mr = GO.AddComponent<MeshRenderer>();
        tetrahedron.Rebuild();
    }
}
