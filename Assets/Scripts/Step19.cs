using System.Collections.Generic;
using UnityEngine;

// 羽を開きます
public class Step19 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {1, 13, 16, 3, 22, 25};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        list.Add((list[14] + list[17]) / 2); // 33
        list.Add((list[23] + list[26]) / 2); // 34
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        triangles.Clear();
        triangles.Add(0); triangles.Add(31); triangles.Add(28);
        triangles.Add(7); triangles.Add(12); triangles.Add(28);

        triangles.Add(12); triangles.Add(11); triangles.Add(4);

        triangles.Add(0); triangles.Add(27); triangles.Add(31);
        triangles.Add(27); triangles.Add(21); triangles.Add(5);

        triangles.Add(21); triangles.Add(4); triangles.Add(20);

        triangles.Add(32); triangles.Add(2); triangles.Add(30);
        triangles.Add(30); triangles.Add(15); triangles.Add(8);

        triangles.Add(11); triangles.Add(15); triangles.Add(4);

        triangles.Add(6); triangles.Add(24); triangles.Add(29);
        triangles.Add(32); triangles.Add(29); triangles.Add(2);

        triangles.Add(20); triangles.Add(4); triangles.Add(24);

        triangles.Add(33); triangles.Add(1); triangles.Add(14);
        triangles.Add(14); triangles.Add(1); triangles.Add(13);
        triangles.Add(11); triangles.Add(33); triangles.Add(14);
        triangles.Add(11); triangles.Add(14); triangles.Add(12);
        triangles.Add(12); triangles.Add(4); triangles.Add(14);

        triangles.Add(23); triangles.Add(25); triangles.Add(3);
        triangles.Add(23); triangles.Add(3); triangles.Add(34);
        triangles.Add(21); triangles.Add(23); triangles.Add(20);
        triangles.Add(20); triangles.Add(23); triangles.Add(34);
        triangles.Add(21); triangles.Add(23); triangles.Add(4);

        triangles.Add(16); triangles.Add(1); triangles.Add(17);
        triangles.Add(17); triangles.Add(1); triangles.Add(33);
        triangles.Add(15); triangles.Add(17); triangles.Add(11);
        triangles.Add(11); triangles.Add(17); triangles.Add(33);
        triangles.Add(15); triangles.Add(17); triangles.Add(4);

        triangles.Add(34); triangles.Add(3); triangles.Add(26);
        triangles.Add(26); triangles.Add(3); triangles.Add(22);
        triangles.Add(20); triangles.Add(34); triangles.Add(26);
        triangles.Add(20); triangles.Add(26); triangles.Add(24);
        triangles.Add(24); triangles.Add(4); triangles.Add(26);
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 1);

        mesh.RecalculateNormals();

        // 手前の2つの頂点を、左右へ開いて奥へ折り返します
        Vector3 v14_17 = vertices[17] - vertices[14];
        Quaternion q0 = Quaternion.AngleAxis(90, v14_17);
        from[0] = vertices[1];
        to[0] = q0 * from[0];
        Vector3 h13 = vertices[14] + Vector3.Project(vertices[13] - vertices[14], v14_17);
        Vector3 h16 = vertices[14] + Vector3.Project(vertices[16] - vertices[14], v14_17);
        Vector3 d1 = (to[0] - vertices[33]).normalized;
        from[1] = vertices[13];
        to[1] = h13 + d1 * (vertices[13] - h13).magnitude;
        from[2] = vertices[16];
        to[2] = h16 + d1 * (vertices[16] - h16).magnitude;

        Vector3 v26_23 = vertices[23] - vertices[26];
        Quaternion q1 = Quaternion.AngleAxis(90, v26_23);
        from[3] = vertices[3];
        to[3] = q1 * from[3];
        Vector3 h25 = vertices[26] + Vector3.Project(vertices[25] - vertices[26], v26_23);
        Vector3 h22 = vertices[26] + Vector3.Project(vertices[22] - vertices[26], v26_23);
        Vector3 d3 = (to[3] - vertices[34]).normalized;
        from[4] = vertices[25];
        to[4] = h25 + d3 * (vertices[25] - h25).magnitude;
        from[5] = vertices[22];
        to[5] = h22 + d3 * (vertices[22] - h22).magnitude;
    }
}
