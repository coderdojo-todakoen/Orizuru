using System.Collections.Generic;
using UnityEngine;

// 左右の頂点を中央へ折り返すため、上まで移動します
public class Step11 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {9, 10};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        Vector3 v0_9 = list[9] - list[0];
        Vector3 v0_7 = list[7] - list[0];
        Vector3 v9_7 = list[7] - list[9];
        list.Add(list[9] + v9_7 * v0_9.magnitude / (v0_9.magnitude + v0_7.magnitude)); // 12
        Vector3 v0_1 = list[1] - list[0];
        Vector3 v9_1 = list[1] - list[9];
        Vector3 v13 = list[9] + v9_1 * v0_9.magnitude / (v0_9.magnitude + v0_1.magnitude);
        list.Add(v13); // 13
        Vector3 v0_4 = list[4] - list[0];
        Vector3 v9_4 = list[4] - list[9];
        Vector3 v14 = list[9] + v9_4 * v0_9.magnitude / (v0_9.magnitude + v0_4.magnitude);
        list.Add(list[0] + (v13 - list[0]).normalized * (v14 - list[0]).magnitude); // 14

        Vector3 v2_10 = list[10] - list[2];
        Vector3 v2_8 = list[8] - list[2];
        Vector3 v10_8 = list[8] - list[10];
        list.Add(list[10] + v10_8 * v2_10.magnitude / (v2_10.magnitude + v2_8.magnitude)); // 15
        Vector3 v2_1 = list[1] - list[2];
        Vector3 v10_1 = list[1] - list[10];
        Vector3 v16 = list[10] + v10_1 * v2_10.magnitude / (v2_10.magnitude + v2_1.magnitude);
        list.Add(v16); // 16
        Vector3 v2_4 = list[4] - list[2];
        Vector3 v10_4 = list[4] - list[10];
        Vector3 v17 = list[10] + v10_4 * v2_10.magnitude / (v2_10.magnitude + v2_4.magnitude);
        list.Add(list[2] + (v16 - list[2]).normalized * (v17 - list[2]).magnitude); // 17
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        triangles.Add(0); triangles.Add(7); triangles.Add(12);//a
        triangles.Add(0); triangles.Add(12); triangles.Add(4);//b

        triangles.Add(12); triangles.Add(11); triangles.Add(4);//g

        triangles.Add(0); triangles.Add(4); triangles.Add(5);
        triangles.Add(4); triangles.Add(3); triangles.Add(5);

        triangles.Add(8); triangles.Add(2); triangles.Add(15);//c
        triangles.Add(2); triangles.Add(4); triangles.Add(15);//d

        triangles.Add(11); triangles.Add(15); triangles.Add(4);//j

        triangles.Add(2); triangles.Add(6); triangles.Add(4);
        triangles.Add(6); triangles.Add(3); triangles.Add(4);
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        triangles.Clear();
        triangles.Add(0); triangles.Add(13); triangles.Add(9);//a
        triangles.Add(11); triangles.Add(1); triangles.Add(12);//e
        triangles.Add(12); triangles.Add(1); triangles.Add(13);//e
        triangles.Add(12); triangles.Add(4); triangles.Add(14);//g

        triangles.Add(16); triangles.Add(2); triangles.Add(10);//c
        triangles.Add(15); triangles.Add(1); triangles.Add(11);//h
        triangles.Add(15); triangles.Add(16); triangles.Add(1);//h
        triangles.Add(15); triangles.Add(17); triangles.Add(4);//j
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 1);

        mesh.RecalculateNormals();

        // 左右の頂点を折り返します
        from[0] = vertices[9];
        Vector3 h0 = vertices[0] + Vector3.Project(vertices[9] - vertices[0], vertices[13] - vertices[0]);
        to[0] = new Vector3(h0.x, (vertices[9] - h0).magnitude, h0.z);
        from[1] = vertices[10];
        Vector3 h1 = vertices[0] + Vector3.Project(vertices[10] - vertices[0], vertices[16] - vertices[0]);
        to[1] = new Vector3(h1.x, (vertices[10] - h1).magnitude, h1.z);
    }
}
