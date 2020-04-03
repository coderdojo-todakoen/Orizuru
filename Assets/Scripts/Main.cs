using UnityEngine;

// 折り鶴を作成します
public class Main : MonoBehaviour
{
    // 現在の手順
    private Step current;
    // 現在の手順のインデックス
    private int index = 0;

    // 折り鶴を作成する手順を格納します
    private Step[] steps = {
        new Step0(),  // 「折り紙」オブジェクトを作成します
        new Wait(),   // 何か入力されるまで待機します 
        new Step1(),  // 45度回して頂点の1つを手前にします
        new Step2(),  // 「折り紙」を裏返します
        new Step3(),  // 奥の頂点が手前の頂点に重なるよう上まで移動します
        new Step4(),  // 奥の頂点が手前の頂点に重なるよう移動します
        new Step5(),  // 右の頂点を上へ移動します
        new Step6(),  // 上へ移動した頂点が、手前の頂点に重なるよう移動します
        new Step2(),  // 「折り紙」を裏返します
        new Step7(),  // 右の頂点を上へ移動します(裏)
        new Step8(),  // 上へ移動した頂点が、手前の頂点に重なるよう移動します(裏)
        new Step9(),  // 手前上の頂点を開いて、奥に移動するため、上まで移動します
        new Step10(), // 手前上の頂点を開いて、奥へ移動します
        new Step11(), // 左右の頂点を中央へ折り返すため、上まで移動します
        new Step12(), // 左右の頂点を中央へ折り返します
        new Step2(),  // 「折り紙」を裏返します
        new Step13(), // 手前上の頂点を開いて、奥に移動するため、上まで移動します(裏)
        new Step14(), // 手前上の頂点を開いて、奥へ移動します(裏)
        new Step15(), // 左右の頂点を中央へ折り返すため、上まで移動します(裏)
        new Step16(), // 左右の頂点を中央へ折り返します(裏)
        new Step17(), // 手前の2つの頂点を、左右へ開いて奥へ折り返します
        new Step18(), // 90度回転して起こします
        new Step19(), // 羽を開きます
        new Step20(), // くちばしを折ります
        new Step21(), // カメラを1周します
        new Wait(),   // 何か入力されるまで待機します 
        new Reload()
    };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckCurrentStep();
        if (current != null)
        {
            current.Update();
        }
    }

    // 現在の手順が終わっていれば、次の手順へ進みます
    private void CheckCurrentStep() {
        if ((current == null) || (current.IsFinished()))
        {
            if (index < steps.Length)
            {
                current = steps[index++];
                current.Init();
            }
        }
    }
}
