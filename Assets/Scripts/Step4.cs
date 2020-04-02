using UnityEngine;

// 奥の頂点が手前の頂点に重なるよう移動します
public class Step4 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {0, 2};
        base.Init(indexes);

        // 頂点(1, 1)を手前(-1, -1)に重なるように移動します
        from[0] = vertices[0];
        to[0] = new Vector3(-1 + DELTA / Mathf.Sqrt(2), 0, -1 - DELTA / Mathf.Sqrt(2));
        from[1] = vertices[2];
        to[1] = new Vector3(-1, 0 + DELTA, -1);
    }
}
