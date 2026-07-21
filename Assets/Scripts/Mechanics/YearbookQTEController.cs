using UnityEngine;
using UnityEngine.UI;
public class YearbookQTEController : MonoBehaviour
{
    public GameObject qtePanel;
    public GameObject jumpscarePortrait;
    public Slider progressSlider;
    public float decayPerSecond = 15f;
    public float fillPerPress = 8f;
    public StressManager stressManager;
    private bool qteActive = false;
    public void StartMashQTE()
    {
        qteActive = true;
        qtePanel.SetActive(true);
        jumpscarePortrait.SetActive(true);
        progressSlider.value = 30f; // start bukan dari 0 supaya tidak instant fail
    }
    void Update()
    {
        if (!qteActive) return;
        progressSlider.value -= decayPerSecond * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
            progressSlider.value += fillPerPress;
        if (progressSlider.value >= progressSlider.maxValue)
        {
            QTESuccess();
        }
        else if (progressSlider.value <= 0f)
        {
            QTEFail();
        }
    }
    void QTESuccess()
    {
        qteActive = false;
        qtePanel.SetActive(false);
        jumpscarePortrait.SetActive(false);
        DialogueManager.Instance.ShowLine("???", "...", 1.5f);
    }
    void QTEFail()
    {
        stressManager.ApplyShockPenalty(25f);
        progressSlider.value = 30f; // beri kesempatan lagi, jangan langsung game over
    }
}
