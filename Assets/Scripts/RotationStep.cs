using UnityEngine;

// オブジェクトを回転する手順のベースクラスです
public class RotationStep : Step
{
    // 回転前
    protected Quaternion from;
    // 回転後
    protected Quaternion to;

    public override void Update()
    {
        // 回転を設定します
        orizuru.transform.rotation = Quaternion.Lerp(from, to, timeCount);
        
        AddTimeCount();
    }
}
