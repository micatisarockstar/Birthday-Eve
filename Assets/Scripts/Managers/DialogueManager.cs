using UnityEngine;
using TMPro;
using System.Collections;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialogBox;
    public TMP_Text speakerText;
    public TMP_Text lineText;
    public float typeSpeed = 0.025f;
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
        dialogBox.SetActive(false);
    }
    public void ShowLine(string speaker, string line, float autoHideAfter = 3f)
    {
        StopAllCoroutines();
        StartCoroutine(TypeAndHide(speaker, line, autoHideAfter));
    }
    IEnumerator TypeAndHide(string speaker, string line, float autoHideAfter)
    {
        dialogBox.SetActive(true);
        speakerText.text = speaker;
        lineText.text = "";
        foreach (char c in line)
        {
            lineText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return new WaitForSeconds(autoHideAfter);
        dialogBox.SetActive(false);
    }
}
