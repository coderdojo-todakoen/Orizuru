using System.Collections.Generic;
using UnityEngine;

// 上へ移動した頂点が、手前の頂点に重なるよう
// 移動します(裏)
public class Step8 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {1, 7, 8};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        list.Add((list[0] + list[1]) / 2); // 7
        list.Add((list[2] + list[1]) / 2); // 8
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        triangles.Add(0); triangles.Add(7); triangles.Add(4);
        triangles.Add(7); triangles.Add(1); triangles.Add(4);

        triangles.Add(0); triangles.Add(4); triangles.Add(5);
        triangles.Add(4); triangles.Add(3); triangles.Add(5);

        triangles.Add(1); triangles.Add(8); triangles.Add(4);
        triangles.Add(8); triangles.Add(2); triangles.Add(4);
        
        triangles.Add(2); triangles.Add(6); triangles.Add(4);
        triangles.Add(6); triangles.Add(3); triangles.Add(4);
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        mesh.RecalculateNormals();

        // 上の頂点を手前の頂点に重なるように移動します(裏)
        from[0] = vertices[1];
        to[0] = new Vector3(-1, 0 + DELTA, -1);
        from[1] = vertices[7];
        to[1] = new Vector3(0, 0 + 0.5F * DELTA, -1);
        from[2] = vertices[8];
        to[2] = new Vector3(-1, 0 + 0.5F * DELTA, 0);
    }
}
