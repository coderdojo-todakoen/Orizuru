using UnityEngine;

// 左右の頂点を中央へ折り返します
public class Step12 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {9, 10};
        base.Init(indexes);

        // 左右の頂点を折り返します
        from[0] = vertices[9];
        Vector3 v0_1 = vertices[1] - vertices[0];
        Vector3 v0_9 = vertices[9] - vertices[0];
        to[0] = vertices[0] + v0_1.normalized * v0_9.magnitude;
        from[1] = vertices[10];
        Vector3 v2_1 = vertices[1] - vertices[2];
        Vector3 v2_10 = vertices[10] - vertices[2];
        to[1] = vertices[2] + v2_1.normalized * v2_10.magnitude;
    }
}
