using UnityEngine;

public class LoadSceneOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string tagToCheck;
    [SerializeField] private CustomSceneManager.SceneType sceneType;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToCheck))
        {
            CustomSceneManager.LoadScene(sceneType);
        }
    }
}