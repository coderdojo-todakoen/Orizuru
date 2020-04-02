using System.Collections.Generic;
using UnityEngine;

// くちばしを折ります
public class Step20 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {0};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        list.Add(Vector3.Lerp(list[0], list[31], 0.4F)); // 35
        list.Add(Vector3.Lerp(list[0], list[27], 0.35F)); // 36
        list.Add(Vector3.Lerp(list[0], list[28], 0.35F)); // 37
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        triangles.Clear();
        triangles.Add(0); triangles.Add(35); triangles.Add(37);
        triangles.Add(37); triangles.Add(35); triangles.Add(28);
        triangles.Add(35); triangles.Add(31); triangles.Add(28);
        triangles.Add(7); triangles.Add(12); triangles.Add(28);

        triangles.Add(12); triangles.Add(11); triangles.Add(4);

        triangles.Add(0); triangles.Add(36); triangles.Add(35);
        triangles.Add(35); triangles.Add(36); triangles.Add(27);
        triangles.Add(35); triangles.Add(27); triangles.Add(31);
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

        // くちばしを折ります
        from[0] = vertices[0];
        Vector3 v1 = orizuru.transform.TransformPoint(vertices[0]) - 
                        orizuru.transform.TransformPoint(vertices[35]);
        Vector3 v2 = Quaternion.Euler(0, 0, 90) * v1;
        to[0] = vertices[35] + orizuru.transform.InverseTransformPoint(v2);
    }
}
