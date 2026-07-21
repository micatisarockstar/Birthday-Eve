using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneFlowController : MonoBehaviour
{
     public static SceneFlowController Instance;
    public CanvasGroup fadeCanvas;   // full-screen black image, alpha dikontrol lewat script
    public float fadeDuration = 0.6f;
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }
    public void LoadSceneByIndex(int index)
    {
        StartCoroutine(FadeAndLoad(index));
    }
    public void LoadBadEndingScene()
    {
        // Scene terpisah / state khusus di Epilogue yang menampilkan Kavi menjadi entitas baru
        StartCoroutine(FadeAndLoad(7, badEnding: true));
    }
    IEnumerator FadeAndLoad(int index, bool badEnding = false)
    {
        yield return Fade(1f);
        yield return SceneManager.LoadSceneAsync(index);
        if (badEnding) EpilogueController.PendingBadEnding = true;
        yield return Fade(0f);
    }
    IEnumerator Fade(float target)
    {
        float start = fadeCanvas.alpha;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(start, target, t / fadeDuration);
            yield return null;
        }
        fadeCanvas.alpha = target;
    }
}
