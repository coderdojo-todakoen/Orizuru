using System.Collections.Generic;
using UnityEngine;

// 「折り紙」オブジェクトを作成します
public class Step0 : Step
{
    public override void Init()
    {
        base.Init();

        orizuru = GameObject.Find(OBJECT_NAME);
        if (orizuru != null)
        {
            // 既にゲームオブジェクトがあれば削除します
            GameObject.DestroyImmediate(orizuru);
        }

        // 新しいゲームオブジェクトを作成します
        orizuru = new GameObject(OBJECT_NAME);
        orizuru.AddComponent<MeshFilter>();
        orizuru.AddComponent<MeshRenderer>();

        Material[] materials = new Material[2];
        materials[0] = Resources.Load("Materials/Color2") as Material;
        materials[1] = Resources.Load("Materials/Color1") as Material;
        orizuru.GetComponent<MeshRenderer>().materials = materials;

        // 頂点配列を作成します
        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(new Vector3( 1, 0,  1)); // 0
        vertices.Add(new Vector3( 1, 0, -1)); // 1
        vertices.Add(new Vector3(-1, 0, -1)); // 2
        vertices.Add(new Vector3(-1, 0,  1)); // 3

        // メッシュを作成します
        Mesh mesh = new Mesh();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices.ToArray();
        // サブメッシュの数を設定します
        mesh.subMeshCount = 2;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        triangles.Add(0); triangles.Add(1); triangles.Add(3);
        triangles.Add(1); triangles.Add(2); triangles.Add(3);
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        mesh.RecalculateNormals();

        orizuru.GetComponent<MeshFilter>().mesh = mesh;

        finished = true;
    }
}
