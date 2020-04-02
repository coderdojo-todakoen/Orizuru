using System.Collections.Generic;
using UnityEngine;

// 右の頂点を上へ移動します
public class Step5 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {3};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        list.Add(new Vector3(0, 0, 0)); // 4
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        triangles.Add(0); triangles.Add(1); triangles.Add(4);
        triangles.Add(0); triangles.Add(4); triangles.Add(3);
        triangles.Add(1); triangles.Add(2); triangles.Add(4);
        triangles.Add(2); triangles.Add(3); triangles.Add(4);
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        mesh.RecalculateNormals();

        // 右の頂点を上へ移動します
        from[0] = vertices[3];
        to[0] = new Vector3(0, -vertices[3].magnitude, 0);
    }
}
