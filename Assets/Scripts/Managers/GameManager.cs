using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
     public static GameManager Instance;
    [Header("Story Progress")]
    public bool isNightmareState = true;
    public int collectedPhotoFragments = 0;   // target: 2 (foto id + foto rooftop)
    public bool hasTeacherLoginInfo = false;  // dapat setelah pingsan pertama
    public bool hasHackedComputer = false;
    public bool isDiaryCompleted = false;
    public bool hasDeliveredPostBox = false;
    [Header("Memory Recovery (Headache System)")]
    public bool isPostFaintState = false;
    public bool angryEntityPermanentlyGone = false;
    [Header("Glitch / Losing Timer")]
    public float glitchTimeLimit = 900f;   // 15 menit real-time = batas 1 malam in-game
    public float glitchTimeElapsed = 0f;
    public bool isGameOver = false;
    public event Action<float> OnGlitchTick;   // update UI clock
    public event Action OnGoodEnding;
    public event Action OnBadEnding;
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }
    void Update()
    {
        if (isGameOver || !isNightmareState) return;
        glitchTimeElapsed += Time.deltaTime;
        OnGlitchTick?.Invoke(glitchTimeLimit - glitchTimeElapsed);
        if (glitchTimeElapsed >= glitchTimeLimit)
            TriggerBadEnding();
    }
    public bool AllEvidenceCollected()
    {
        return collectedPhotoFragments >= 2 && hasHackedComputer && isDiaryCompleted && hasDeliveredPostBox;
    }
    public void TriggerGoodEnding()
    {
        if (isGameOver) return;
        isGameOver = true;
        OnGoodEnding?.Invoke();
        SceneFlowController.Instance.LoadSceneByIndex(7); // Epilogue
    }
    public void TriggerBadEnding()
    {
        if (isGameOver) return;
        isGameOver = true;
        OnBadEnding?.Invoke();
        SceneFlowController.Instance.LoadBadEndingScene();
    }
}
