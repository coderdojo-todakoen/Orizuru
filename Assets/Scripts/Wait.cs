using UnityEngine;

// 何か入力されるまで待ちます
public class Wait : Step
{
    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        if (Input.anyKeyDown)
        {
            finished = true;
        }
    }
}