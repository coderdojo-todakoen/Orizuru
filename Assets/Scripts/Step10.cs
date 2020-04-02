using UnityEngine;

// 手前上の頂点を開いて、奥へ移動します
public class Step10 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {1, 7, 8};
        base.Init(indexes);

        // 上に移動した頂点を奥へ移動します
        from[0] = vertices[1];
        to[0] = new Vector3(2 - Mathf.Sqrt(2), 0 + 2 * DELTA, 2 - Mathf.Sqrt(2));
        from[1] = vertices[7];
        to[1] = Vector3.Lerp(to[0], vertices[0], 0.55F);
        from[2] = vertices[8];
        to[2] = Vector3.Lerp(to[0], vertices[2], 0.55F);
    }
}
