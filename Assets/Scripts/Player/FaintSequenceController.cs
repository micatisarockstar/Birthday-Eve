using UnityEngine;
using System.Collections;
public class FaintSequenceController : MonoBehaviour
{
    public Animator kaviAnimator;
    public CanvasGroup redFlash;
    public void TriggerFaintSequence()
    {
        StartCoroutine(FaintRoutine());
    }
    IEnumerator FaintRoutine()
    {
        kaviAnimator.SetTrigger("NoseBleed");
        yield return new WaitForSeconds(0.5f);
        kaviAnimator.SetTrigger("Faint");
        yield return StartCoroutine(FadeRed(1f, 0.4f));
        GameManager.Instance.isPostFaintState = true;
        SceneFlowController.Instance.LoadSceneByIndex(1); // kembali ke Classroom, versi "sudah pingsan"
    }
    IEnumerator FadeRed(float target, float duration)
    {
        float t = 0f;
        float start = redFlash.alpha;
        while (t < duration)
        {
            t += Time.deltaTime;
            redFlash.alpha = Mathf.Lerp(start, target, t / duration);
            yield return null;
        }
    }
}
