using UnityEngine.SceneManagement;

// Sceneを再読込みします
public class Reload : Step
{
    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        // Sceneを再読込みします
        SceneManager.LoadScene("Main");
    }
}