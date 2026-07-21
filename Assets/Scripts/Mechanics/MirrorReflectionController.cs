using UnityEngine;
public class MirrorReflectionController : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer reflectionRenderer;
    public Sprite kaviReflectionSprite;
    public Sprite ghostReflectionSprite;
    public float mirrorX; // posisi X cermin di world space
    private bool encounterTriggered = false;
    void Update()
    {
        // Posisi bayangan = cerminan horizontal posisi player terhadap cermin
        float mirroredX = mirrorX + (mirrorX - player.position.x);
        reflectionRenderer.transform.position =
            new Vector3(mirroredX, player.position.y, reflectionRenderer.transform.position.z);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || encounterTriggered) return;
        encounterTriggered = true;
        reflectionRenderer.sprite = ghostReflectionSprite;
        DialogueManager.Instance.ShowLine("???", "...", 2f);
        GameManager.Instance.isNightmareState = true;
        // Unlock pintu keluar kelas setelah momen ini, misal set flag di GameManager
    }
}