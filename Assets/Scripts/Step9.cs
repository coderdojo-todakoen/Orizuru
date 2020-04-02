using System.Collections.Generic;
using UnityEngine;

// 手前上の頂点を開いて、奥に移動するため、
// 上まで移動します
public class Step9 : MoveStep
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
        Vector3 v1_4 = list[4] - list[1];
        Vector3 v1_7 = list[7] - list[1];
        Vector3 v4_7 = list[7] - list[4];
        Vector3 v9 = list[4] + v4_7 * v1_4.magnitude / (v1_4.magnitude + v1_7.magnitude);
        list.Add(v9); // 9
        Vector3 v1_8 = list[8] - list[1];
        Vector3 v4_8 = list[8] - list[4];
        Vector3 v10 = list[4] + v4_8 * v1_4.magnitude / (v1_4.magnitude + v1_8.magnitude);
        list.Add(v10); // 10
        list.Add((v9 + v10) / 2); // 11
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        triangles.Add(0); triangles.Add(7); triangles.Add(9);//a
        triangles.Add(0); triangles.Add(9); triangles.Add(4);//b

        triangles.Add(7); triangles.Add(1); triangles.Add(9);//e
        triangles.Add(9); triangles.Add(1); triangles.Add(11);//f
        triangles.Add(9); triangles.Add(11); triangles.Add(4);//g

        triangles.Add(0); triangles.Add(4); triangles.Add(5);
        triangles.Add(4); triangles.Add(3); triangles.Add(5);

        triangles.Add(8); triangles.Add(2); triangles.Add(10);//c
        triangles.Add(10); triangles.Add(2); triangles.Add(4);//d

        triangles.Add(1); triangles.Add(8); triangles.Add(10);//h
        triangles.Add(1); triangles.Add(10); triangles.Add(11);//i
        triangles.Add(11); triangles.Add(10); triangles.Add(4);//j

        triangles.Add(2); triangles.Add(6); triangles.Add(4);
        triangles.Add(6); triangles.Add(3); triangles.Add(4);
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        mesh.RecalculateNormals();

        // 手前を開いて上に移動します
        from[0] = vertices[1];
        to[0] = new Vector3(1 - Mathf.Sqrt(2), 1, 1 - Mathf.Sqrt(2));
        from[1] = vertices[7];
        to[1] = Vector3.Lerp(from[1], to[0], 0.2f);
        from[2] = vertices[8];
        to[2] = Vector3.Lerp(from[2], to[0], 0.2f);
    }
}
