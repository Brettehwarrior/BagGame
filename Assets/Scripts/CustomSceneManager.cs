using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CustomSceneManager
{
    [Serializable]
    public enum SceneType
    {
        None = 0,
        BagDimension,
        SceneSelectionScene,
        DemoScene1,
        DemoScene2
    }

    public static readonly Dictionary<SceneType, string> SceneName = new()
    {
        {SceneType.BagDimension, "BagDimension"},
        {SceneType.SceneSelectionScene, "SceneSelectionScene"},
        {SceneType.DemoScene1, "DemoScene1"},
        {SceneType.DemoScene2, "DemoScene2"}
    };

    public static SceneType CurrentPrimarySceneType { get; set; } = SceneType.None;
    public static Scene CurrentPrimaryScene => SceneManager.GetSceneByName(SceneName[CurrentPrimarySceneType]);
    
    /// <summary>
    /// Get the SceneType of a given Scene
    /// </summary>
    /// <param name="sceneToCheck"></param>
    /// <returns></returns>
    public static SceneType SceneToSceneType(Scene sceneToCheck)
    {
        foreach (var (sceneType, name) in SceneName)
        {
            if (name == sceneToCheck.name)
                return sceneType;
        }

        return SceneType.None;
    }
    
    /// <summary>
    /// Determines whether a scene with a given name is loaded
    /// </summary>
    /// <param name="sceneType"></param>
    /// <returns>true if scene is currently loaded</returns>
    public static bool IsSceneLoaded(SceneType sceneType)
    {
        for (var i = 0; i < SceneManager.sceneCount; i++) {
            var scene = SceneManager.GetSceneAt(i);
            
            if (scene.name == SceneName[sceneType])
                return true;
        }
 
        return false;
    }
    
    /// <summary>
    /// Loads a scene with a given name and specified loading mode
    /// </summary>
    /// <param name="sceneType">SceneType of the scene to load</param>
    /// <param name="mode">Load mode (defaults to Additive)</param>
    public static void LoadScene(SceneType sceneType, LoadSceneMode mode = LoadSceneMode.Additive)
    {
        if (IsSceneLoaded(sceneType))
            return;
        
        SceneManager.LoadScene(SceneName[sceneType], mode);
    }

    /// <summary>
    /// Unloads the current primary scene
    /// </summary>
    private static void UnloadPrimaryScene()
    {
        if (!SceneName.ContainsKey(CurrentPrimarySceneType) || !CurrentPrimaryScene.IsValid() || !CurrentPrimaryScene.isLoaded)
            return;
        
        SceneManager.UnloadSceneAsync(CurrentPrimaryScene);
    }
    
    /// <summary>
    /// Unloads current primary scene and loads a scene as the primary scene
    /// </summary>
    /// <param name="sceneType">SceneType of scene to load as primary</param>
    public static void LoadPrimaryScene(SceneType sceneType)
    {   
        UnloadPrimaryScene();
        CurrentPrimarySceneType = sceneType;
        LoadScene(sceneType, LoadSceneMode.Additive);
    }
    
    /// <summary>
    /// Switches a given object to another scene
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="sceneType"></param>
    /// <exception cref="Exception">Throws exception if object's transform parent is not null</exception>
    public static void MoveObjectToScene(GameObject obj, SceneType sceneType)
    {
        if (obj.transform.parent != null)
        {
            throw new Exception("Tried to move object with parent to another scene; transform parent must be null");
        }
        
        if (IsSceneLoaded(sceneType))
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetSceneByName(SceneName[sceneType]));
    }
}