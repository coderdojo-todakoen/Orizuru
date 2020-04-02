using UnityEngine;

// メッシュの頂点座標を移動する手順のベースクラスです
public class MoveStep : Step
{
    // メッシュ
    protected Mesh mesh;
    // メッシュの頂点座標
    protected Vector3[] vertices;

    // 移動する頂点座標のインデックス
    protected int[] indexes;
    // 移動する頂点座標の移動元座標
    protected Vector3[] from;
    // 移動する頂点座標の移動先座標
    protected Vector3[] to;

    public virtual void Init(int[] indexes)
    {
        base.Init();

        // メッシュを取得します
        var filter = orizuru.GetComponent<MeshFilter>();
        mesh = filter.sharedMesh;

        // 頂点座標を取得します
        vertices = mesh.vertices;

        this.indexes = indexes;
        from = new Vector3[indexes.Length];
        to = new Vector3[indexes.Length];
    }

    public override void Update()
    {
        // 移動対象の頂点座標を格納します
        int i = 0;
        foreach (int index in indexes)
        {
            vertices[index] = Vector3.Slerp(from[i], to[i], timeCount);
            ++i;
        }
        mesh.vertices = vertices;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        AddTimeCount();
    }
}
