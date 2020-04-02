using UnityEngine;

// 手前上の頂点を開いて、奥へ移動します(裏)
public class Step14 : MoveStep
{
    public override void Init()
    {
        int[] indexes = {3, 5, 6};
        base.Init(indexes);

        // 上に移動した頂点を奥へ移動します(裏)
        from[0] = vertices[3];
        to[0] = new Vector3(2 - Mathf.Sqrt(2), 0 - 2 * DELTA, 2 - Mathf.Sqrt(2));
        from[1] = vertices[5];
        to[1] = Vector3.Lerp(to[0], vertices[0], 0.55F);
        from[2] = vertices[6];
        to[2] = Vector3.Lerp(to[0], vertices[2], 0.55F);
    }
}
