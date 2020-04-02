using UnityEngine;

// 右の頂点を上へ移動します(裏)
public class Step7 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {1, 2};
        base.Init(indexes);

        // 右の頂点を上へ移動します(裏)
        from[0] = vertices[1];
        to[0] = new Vector3(0, vertices[1].magnitude, 0);
        from[1] = vertices[2];
        to[1] = new Vector3(-1 - DELTA / Mathf.Sqrt(2), 0, -1 + DELTA / Mathf.Sqrt(2));
    }
}
