using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangulatorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject go = new GameObject();
        go.name = "Cross";
        MeshFilter mf = go.AddComponent<MeshFilter>();
        go.AddComponent<MeshCollider>();
        go.AddComponent<MeshRenderer>();

        Mesh mesh = mf.mesh;

        List<Vector2> points = new List<Vector2>();
        List<List<Vector2>> holes = new List<List<Vector2>>();
        List<int> indices = null;
        List<Vector3> vertices = null;

        points.Add(new Vector2(10, 0));
        points.Add(new Vector2(20, 0));
        points.Add(new Vector2(20, 10));
        points.Add(new Vector2(30, 10));
        points.Add(new Vector2(30, 20));
        points.Add(new Vector2(20, 20));
        points.Add(new Vector2(20, 30));
        points.Add(new Vector2(10, 30));
        points.Add(new Vector2(10, 20));
        points.Add(new Vector2(0, 20));
        points.Add(new Vector2(0, 10));
        points.Add(new Vector2(10, 10));

        List<Vector2> hole = new List<Vector2>();
        hole.Add(new Vector2(12, 12));
        hole.Add(new Vector2(18, 12));
        hole.Add(new Vector2(18, 18));
        hole.Add(new Vector2(12, 18));

        holes.Add(hole);

        Triangulation.triangulate(points, holes, out indices, out vertices);

        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = indices.ToArray();
        //mesh.Optimize();
        mesh.RecalculateNormals();

        go.GetComponent<MeshCollider>().sharedMesh = mesh;

        Vector2[] uvs = new Vector2[mesh.vertices.Length];
        for(int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(mesh.vertices[i].x, mesh.vertices[i].y);
        }
        mesh.uv = uvs;
    }
	
	void Update () {
		
	}
}
