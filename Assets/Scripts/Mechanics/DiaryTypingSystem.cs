using UnityEngine;
using TMPro;
public class DiaryTypingSystem : MonoBehaviour
{
    public TMP_InputField answerField;
    public GameObject diaryPanel;
    private const string EXPECTED = "It's not your fault.";
    public void SubmitAnswer()
    {
        if (answerField.text.Trim().Equals(EXPECTED, System.StringComparison.OrdinalIgnoreCase))
        {
            GameManager.Instance.isDiaryCompleted = true;
            diaryPanel.SetActive(false);
            DialogueManager.Instance.ShowLine("???",
                "Tolong aku, kemarahanku sudah tidak bisa aku tahan.", 3f);
        }
        else
        {
            DialogueManager.Instance.ShowLine("Kavi", "(Bukan ini kalimatnya...)", 1.5f);
        }
    }
}
