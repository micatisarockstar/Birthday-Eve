using UnityEngine;
using System.Collections;
public class FinalConfrontationController : MonoBehaviour
{
    public SpriteRenderer ghostRenderer;
    public Sprite angrySprite;
    public Sprite goodSprite;
    public GameObject lockerKeyPickup;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !GameManager.Instance.AllEvidenceCollected()) return;
        StartCoroutine(ConfrontationSequence());
    }
    IEnumerator ConfrontationSequence()
    {
        ghostRenderer.sprite = angrySprite;
        DialogueManager.Instance.ShowLine("???", "Kenapa... kenapa baru sekarang...", 3f);
        yield return new WaitForSeconds(3.5f);
        ghostRenderer.sprite = goodSprite;
        DialogueManager.Instance.ShowLine("???", "Terima kasih sudah mengingatku.", 3f);
        yield return new WaitForSeconds(3.5f);
        lockerKeyPickup.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.TriggerGoodEnding();
    }
}
