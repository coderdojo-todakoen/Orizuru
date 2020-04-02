using UnityEngine;

// 奥の頂点が手前の頂点に重なるよう移動するために
// 上まで移動します
public class Step3 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {0};
        base.Init(indexes);

        // 頂点(1, 1)を手前(-1, -1)に重なるように移動するために
        // 上(0, 0)へ移動します
        from[0] = vertices[0];
        to[0] = new Vector3(0, -vertices[0].magnitude, 0);
    }
}
