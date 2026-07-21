using UnityEngine;
using TMPro;
public class ComputerLoginPuzzle : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField passwordInputField;
    public GameObject digitalPhotoReward;
    public FaintSequenceController faintController;
    private const string VALID_ID = "Susanto.teacher.id";
    private const string VALID_PW = "susantoGanteng10";
    public void AttemptLogin()
    {
        if (!GameManager.Instance.hasTeacherLoginInfo)
        {
            // Percobaan pertama: selalu memicu event pingsan, apapun inputnya
            faintController.TriggerFaintSequence();
            return;
        }
        string inputID = idInputField.text.Trim();
        string inputPW = passwordInputField.text;
        if (inputID == VALID_ID && inputPW == VALID_PW)
        {
            digitalPhotoReward.SetActive(true);
            GameManager.Instance.collectedPhotoFragments++;
            GameManager.Instance.hasHackedComputer = true;
        }
        else
        {
            DialogueManager.Instance.ShowLine("System", "Login gagal. Periksa kembali kredensial.", 2f);
        }
    }
}