using UnityEngine;

// 90度回転して起こします
public class Step18 : RotationStep
{
    public override void Init()
    {
        base.Init();

        // 90度回転して起こします
        from = orizuru.transform.rotation;
        to = from * Quaternion.AngleAxis(90, new Vector3(1, 0, -1));
    }
}
