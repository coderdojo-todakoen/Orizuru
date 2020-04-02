using UnityEngine;

// 「折り紙」を裏返します
public class Step2 : RotationStep
{
    public override void Init()
    {
        base.Init();

        // 180度回転して裏返しにします
        from = orizuru.transform.rotation;
        to = from * Quaternion.AngleAxis(180, new Vector3(-1, 0, -1));
    }
}
