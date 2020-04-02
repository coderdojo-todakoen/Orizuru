using UnityEngine;

// 45度回して頂点の1つを手前にします
public class Step1 : RotationStep
{
    public override void Init()
    {
        base.Init();

        // 45度回して、頂点(-1, -1)を手前にします
        from = orizuru.transform.rotation;
        to = Quaternion.AngleAxis(45, new Vector3(0, -1, 0));
    }
}
