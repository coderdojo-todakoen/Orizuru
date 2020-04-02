using UnityEngine;

// 左右の頂点を中央へ折り返します(裏)
public class Step16 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {18, 19};
        base.Init(indexes);

        // 左右の頂点を折り返します(裏)
        from[0] = vertices[18];
        Vector3 v0_3 = vertices[3] - vertices[0];
        Vector3 v0_18 = vertices[18] - vertices[0];
        to[0] = vertices[0] + v0_3.normalized * v0_18.magnitude;
        from[1] = vertices[19];
        Vector3 v2_3 = vertices[3] - vertices[2];
        Vector3 v2_19 = vertices[19] - vertices[2];
        to[1] = vertices[2] + v2_3.normalized * v2_19.magnitude;
    }
}
