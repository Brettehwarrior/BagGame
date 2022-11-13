using UnityEngine.SceneManagement;

public static class CustomSceneManager
{
    public struct Scenes
    {
        public const string BagDimension = "BagDimension";
    }
    
    public static bool IsSceneLoaded(string sceneName)
    {
        for (var i = 0; i < SceneManager.sceneCount; i++) {
            var scene = SceneManager.GetSceneAt(i);
            
            if (scene.name == sceneName)
                return true;
        }
 
        return false;
    }
    
    public static void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive)
    {
        if (IsSceneLoaded(sceneName))
            return;
        
        SceneManager.LoadScene(sceneName, mode);
    }
}