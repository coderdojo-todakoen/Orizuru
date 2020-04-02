using System.Collections.Generic;
using UnityEngine;

// 手前上の頂点を開いて、奥に移動するため、
// 上まで移動します(裏)
public class Step13 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {3, 5, 6};
        base.Init(indexes);

        // 頂点座標を取得します
        List<Vector3> list = new List<Vector3>();
        foreach (Vector3 v in mesh.vertices)
        {
            list.Add(v);
        }
        // 新しい頂点座標を追加します
        Vector3 v3_4 = list[4] - list[3];
        Vector3 v3_5 = list[5] - list[3];
        Vector3 v4_5 = list[5] - list[4];
        Vector3 v18 = list[4] + v4_5 * v3_4.magnitude / (v3_4.magnitude + v3_5.magnitude);
        list.Add(v18); // 18
        Vector3 v3_6 = list[6] - list[3];
        Vector3 v4_6 = list[6] - list[4];
        Vector3 v19 = list[4] + v4_6 * v3_4.magnitude / (v3_4.magnitude + v3_6.magnitude);
        list.Add(v19); // 19
        list.Add((v18 + v19) / 2); // 20
        vertices = list.ToArray();

        // 頂点座標をメッシュへ格納します
        mesh.vertices = vertices;

        // 頂点座標のインデックスを格納します
        List<int> triangles = new List<int>();
        triangles.Add(0); triangles.Add(7); triangles.Add(12);
        triangles.Add(0); triangles.Add(12); triangles.Add(4);

        triangles.Add(12); triangles.Add(11); triangles.Add(4);

        triangles.Add(0); triangles.Add(18); triangles.Add(5);//A
        triangles.Add(0); triangles.Add(4); triangles.Add(18);//B

        triangles.Add(18); triangles.Add(3); triangles.Add(5);//E
        triangles.Add(20); triangles.Add(3); triangles.Add(18);//F
        triangles.Add(18); triangles.Add(4); triangles.Add(20);//G

        triangles.Add(8); triangles.Add(2); triangles.Add(15);
        triangles.Add(2); triangles.Add(4); triangles.Add(15);

        triangles.Add(11); triangles.Add(15); triangles.Add(4);

        triangles.Add(6); triangles.Add(19); triangles.Add(2);//C
        triangles.Add(19); triangles.Add(4); triangles.Add(2);//D

        triangles.Add(6); triangles.Add(3); triangles.Add(19);//H
        triangles.Add(3); triangles.Add(20); triangles.Add(19);//I
        triangles.Add(20); triangles.Add(4); triangles.Add(19);//J
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 0);

        triangles.Clear();
        triangles.Add(0); triangles.Add(13); triangles.Add(9);
        triangles.Add(11); triangles.Add(1); triangles.Add(12);
        triangles.Add(12); triangles.Add(1); triangles.Add(13);
        triangles.Add(12); triangles.Add(4); triangles.Add(14);

        triangles.Add(16); triangles.Add(2); triangles.Add(10);
        triangles.Add(15); triangles.Add(1); triangles.Add(11);
        triangles.Add(15); triangles.Add(16); triangles.Add(1);
        triangles.Add(15); triangles.Add(17); triangles.Add(4);
        // サブメッシュを構成するポリゴンを追加します
        mesh.SetTriangles(triangles, 1);

        mesh.RecalculateNormals();

        // 手前を開いて上に移動します(裏)
        from[0] = vertices[3];
        to[0] = new Vector3(1 - Mathf.Sqrt(2), -1, 1 - Mathf.Sqrt(2));
        from[1] = vertices[5];
        to[1] = Vector3.Lerp(from[1], to[0], 0.2f);
        from[2] = vertices[6];
        to[2] = Vector3.Lerp(from[2], to[0], 0.2f);
    }
}
