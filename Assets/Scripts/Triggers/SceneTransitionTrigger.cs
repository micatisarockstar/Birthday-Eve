using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class SceneTransitionTrigger : MonoBehaviour
{
    public int targetSceneIndex;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        SceneFlowController.Instance.LoadSceneByIndex(targetSceneIndex);
    }
}