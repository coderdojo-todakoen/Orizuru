using UnityEngine;

// カメラを1周します
public class Step21 : Step
{
    private float angle = 0;

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        // 折り鶴を中心にカメラを回転します
        float a = 180 * Time.deltaTime;
        Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, a);

        angle += a;
        if (angle >= 360)
        {
            finished = true;
        }
    }
}
