using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider2D))]
public class InteractableObject : MonoBehaviour
{
    public string promptText = "Tekan E";
    public GameObject promptUI;         // Text/Icon "Tekan E" yang muncul saat player dekat
    public UnityEvent onInteract;       // di-assign lewat Inspector, bisa panggil fungsi apa saja
    public bool interactOnce = false;
    private bool playerInRange = false;
    private bool alreadyUsed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = true;
        if (promptUI != null && !(interactOnce && alreadyUsed)) promptUI.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = false;
        if (promptUI != null) promptUI.SetActive(false);
    }
    void Update()
    {
        if (!playerInRange) return;
        if (interactOnce && alreadyUsed) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            onInteract.Invoke();
            alreadyUsed = true;
            if (promptUI != null) promptUI.SetActive(false);
        }
    }
}