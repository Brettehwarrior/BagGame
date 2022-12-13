using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimpleLevelSelector : MonoBehaviour
{
    [Serializable]
    private struct LevelButtons
    {
        public CustomSceneManager.SceneType sceneType;
        public Button button;
    }
    
    [SerializeField] private List<LevelButtons> levelButtons = new List<LevelButtons>();

    private void Awake()
    {
        foreach (var levelButton in levelButtons)
        {
            levelButton.button.onClick.AddListener(() => CustomSceneManager.LoadPrimaryScene(levelButton.sceneType));
        }
    }

    public void LoadScene(CustomSceneManager.SceneType sceneType)
    {
        CustomSceneManager.LoadPrimaryScene(sceneType);
    }
}