using System.Collections.Generic;
using UnityEngine;

// 左右の頂点を中央へ折り返すため、上まで移動します(裏)
public class Step15 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {18, 19};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        Vector3 v0_18 = list[18] - list[0];
        Vector3 v0_5 = list[5] - list[0];
        Vector3 v18_5 = list[5] - list[18];
        list.Add(list[18] + v18_5 * v0_18.magnitude / (v0_18.magnitude + v0_5.magnitude)); // 21
        Vector3 v0_3 = list[3] - list[0];
        Vector3 v18_3 = list[3] - list[18];
        Vector3 v22 = list[18] + v18_3 * v0_18.magnitude / (v0_18.magnitude + v0_3.magnitude);
        list.Add(v22); // 22
        Vector3 v0_4 = list[4] - list[0];
        Vector3 v18_4 = list[4] - list[18];
        Vector3 v23 = list[18] + v18_4 * v0_18.magnitude / (v0_18.magnitude + v0_4.magnitude);
        list.Add(list[0] + (v22 - list[0]).normalized * (v23 - list[0]).magnitude); // 23

        Vector3 v2_19 = list[19] - list[2];
        Vector3 v2_6 = list[6] - list[2];
        Vector3 v19_6 = list[6] - list[19];
        list.Add(list[19] + v19_6 * v2_19.magnitude / (v2_19.magnitude + v2_6.magnitude)); // 24
        Vector3 v2_3 = list[3] - list[2];
        Vector3 v19_3 = list[3] - list[19];
        Vector3 v25 = list[19] + v19_3 * v2_19.magnitude / (v2_19.magnitude + v2_3.magnitude);
        list.Add(v25); // 25
        Vector3 v2_4 = list[4] - list[2];
        Vector3 v19_4 = list[4] - list[19];
        Vector3 v26 = list[19] + v19_4 * v2_19.magnitude / (v2_19.magnitude + v2_4.magnitude);
        list.Add(list[2] + (v25 - list[2]).normalized * (v26 - list[2]).magnitude); // 26
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        triangles.Add(0); triangles.Add(7); triangles.Add(12);
        triangles.Add(0); triangles.Add(12); triangles.Add(4);

        triangles.Add(12); triangles.Add(11); triangles.Add(4);

        triangles.Add(0); triangles.Add(21); triangles.Add(5);//A
        triangles.Add(0); triangles.Add(4); triangles.Add(21);//B

        triangles.Add(21); triangles.Add(4); triangles.Add(20);//G

        triangles.Add(8); triangles.Add(2); triangles.Add(15);
        triangles.Add(2); triangles.Add(4); triangles.Add(15);

        triangles.Add(11); triangles.Add(15); triangles.Add(4);

        triangles.Add(6); triangles.Add(24); triangles.Add(2);//C
        triangles.Add(24); triangles.Add(4); triangles.Add(2);//D

        triangles.Add(20); triangles.Add(4); triangles.Add(24);//J
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        triangles.Clear();
        triangles.Add(0); triangles.Add(13); triangles.Add(9);
        triangles.Add(11); triangles.Add(1); triangles.Add(12);
        triangles.Add(12); triangles.Add(1); triangles.Add(13);
        triangles.Add(12); triangles.Add(4); triangles.Add(14);

        triangles.Add(0); triangles.Add(18); triangles.Add(22);//A
        triangles.Add(21); triangles.Add(3); triangles.Add(20);//E
        triangles.Add(21); triangles.Add(22); triangles.Add(3);//E
        triangles.Add(21); triangles.Add(23); triangles.Add(4);//G

        triangles.Add(16); triangles.Add(2); triangles.Add(10);
        triangles.Add(15); triangles.Add(1); triangles.Add(11);
        triangles.Add(15); triangles.Add(16); triangles.Add(1);
        triangles.Add(15); triangles.Add(17); triangles.Add(4);

        triangles.Add(25); triangles.Add(19); triangles.Add(2);//C
        triangles.Add(20); triangles.Add(3); triangles.Add(24);//H
        triangles.Add(24); triangles.Add(3); triangles.Add(25);//H
        triangles.Add(24); triangles.Add(4); triangles.Add(26);//J
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 1);

        mesh.RecalculateNormals();

        // 左右の頂点を折り返します(裏)
        from[0] = vertices[18];
        Vector3 h0 = vertices[0] + Vector3.Project(vertices[18] - vertices[0], vertices[22] - vertices[0]);
        to[0] = new Vector3(h0.x, -(vertices[18] - h0).magnitude, h0.z);
        from[1] = vertices[19];
        Vector3 h1 = vertices[0] + Vector3.Project(vertices[19] - vertices[0], vertices[25] - vertices[0]);
        to[1] = new Vector3(h1.x, -(vertices[19] - h1).magnitude, h1.z);
    }
}
