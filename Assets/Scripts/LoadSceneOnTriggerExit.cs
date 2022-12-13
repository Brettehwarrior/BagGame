using UnityEngine;

public class LoadSceneOnTriggerExit : MonoBehaviour
{
    [SerializeField] private string tagToCheck;
    [SerializeField] private CustomSceneManager.SceneType sceneType;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagToCheck))
        {
            CustomSceneManager.LoadPrimaryScene(sceneType);
        }
    }
}