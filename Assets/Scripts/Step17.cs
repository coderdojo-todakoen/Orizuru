using System.Collections.Generic;
using UnityEngine;

// 手前の2つの頂点を、左右へ開いて奥へ折り返します
public class Step17 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {0, 2};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        Vector3 v0_5 = list[5] - list[0];
        Vector3 v0_21 = list[21] - list[0];
        list.Add(list[0] + Vector3.Project(v0_5, v0_21)); // 27
        Vector3 v0_7 = list[7] - list[0];
        Vector3 v0_12 = list[12] - list[0];
        list.Add(list[0] + Vector3.Project(v0_7, v0_12)); // 28
        Vector3 v2_6 = list[6] - list[2];
        Vector3 v2_24 = list[24] - list[2];
        list.Add(list[2] + Vector3.Project(v2_6, v2_24)); // 29
        Vector3 v2_8 = list[8] - list[2];
        Vector3 v2_15 = list[15] - list[2];
        list.Add(list[2] + Vector3.Project(v2_8, v2_15)); // 30
        list.Add((list[5] + list[7]) / 2); // 31
        list.Add((list[6] + list[8]) / 2); // 32
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

        triangles.Add(0); triangles.Add(27); triangles.Add(31);//A
        triangles.Add(27); triangles.Add(21); triangles.Add(5);//A

        triangles.Add(21); triangles.Add(4); triangles.Add(20);//G

        triangles.Add(32); triangles.Add(2); triangles.Add(30);
        triangles.Add(30); triangles.Add(15); triangles.Add(8);

        triangles.Add(11); triangles.Add(15); triangles.Add(4);

        triangles.Add(6); triangles.Add(24); triangles.Add(29);//C
        triangles.Add(32); triangles.Add(29); triangles.Add(2);//C

        triangles.Add(20); triangles.Add(4); triangles.Add(24);//J

        triangles.Add(11); triangles.Add(1); triangles.Add(12);
        triangles.Add(12); triangles.Add(1); triangles.Add(13);
        triangles.Add(12); triangles.Add(4); triangles.Add(14);

        triangles.Add(21); triangles.Add(3); triangles.Add(20);//E
        triangles.Add(21); triangles.Add(22); triangles.Add(3);//E
        triangles.Add(21); triangles.Add(23); triangles.Add(4);//G

        triangles.Add(15); triangles.Add(1); triangles.Add(11);
        triangles.Add(15); triangles.Add(16); triangles.Add(1);
        triangles.Add(15); triangles.Add(17); triangles.Add(4);

        triangles.Add(20); triangles.Add(3); triangles.Add(24);//H
        triangles.Add(24); triangles.Add(3); triangles.Add(25);//H
        triangles.Add(24); triangles.Add(4); triangles.Add(26);//J
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 1);

        mesh.RecalculateNormals();

        // 手前の2つの頂点を、左右へ開いて奥へ折り返します
        from[0] = vertices[0];
        to[0] = vertices[0] + (vertices[21] - vertices[0]) + (vertices[12] - vertices[0]);
        from[1] = vertices[2];
        to[1] = vertices[2] + (vertices[24] - vertices[2]) + (vertices[15] - vertices[2]);
    }
}
