using UnityEngine;

// 折り鶴を作成する手順のベースクラスです
public abstract class Step
{
    protected const string OBJECT_NAME = "Orizuru";

    // 「折り紙」オブジェクト
    protected GameObject orizuru;

    // 手順が完了したらtrueになります
    protected bool finished = false;

    // 現在の手順が開始してからの経過時間
    protected float timeCount = 0;

    public virtual void Init() {
        // 「折り紙」オブジェクトを取得します
        orizuru = GameObject.Find(OBJECT_NAME);
    }

    public virtual void Update() {
    }

    // 手順が完了しているかどうかを返します
    public bool IsFinished()
    {
        return finished;
    }

    // 現在の手順の経過時間を加算します
    protected void AddTimeCount()
    {
        timeCount += (Time.deltaTime / 0.5F);
        if (timeCount > 1.1F)
        {
            finished = true;
        }
    }

    // 折り鶴を折る手順で、頂点が重ならないように空ける隙間
    protected const float DELTA = 0.06F;
}
