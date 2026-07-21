using UnityEngine;
public class PostBoxDelivery : MonoBehaviour
{
    public GameObject lockedPromptUI;   // "Belum semua bukti terkumpul" text
    public GameObject deliveredEffectUI;
    // Dipanggil dari InteractableObject.onInteract (drag GameObject ini, pilih fungsi TryDeliver)
    public void TryDeliver()
    {
        if (!GameManager.Instance.AllEvidenceCollected())
        {
            if (lockedPromptUI != null)
            {
                lockedPromptUI.SetActive(true);
                Invoke(nameof(HidePrompt), 2f);
            }
            return;
        }
        GameManager.Instance.hasDeliveredPostBox = true;
        if (deliveredEffectUI != null) deliveredEffectUI.SetActive(true);
        DialogueManager.Instance.ShowLine("Kavi", "Semua bukti sudah kumasukkan.", 2f);
    }
    void HidePrompt()
    {
        lockedPromptUI.SetActive(false);
    }
    // Versi final di Epilogue: dipanggil langsung tanpa syarat evidence (evidence sudah pasti lengkap saat ini)
    public void DeliverToGirl()
    {
        DialogueManager.Instance.ShowLine("Kavi", "I have something to give to you.", 3f);
    }
}
