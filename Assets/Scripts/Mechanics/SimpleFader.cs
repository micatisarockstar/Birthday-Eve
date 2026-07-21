using UnityEngine;
using System.Collections;
public static class SimpleFader
{
    public static IEnumerator FadeSpriteAlpha(SpriteRenderer sr, float from, float to, float duration)
    {
        float t = 0f;
        Color c = sr.color;
        while (t < duration)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(from, to, t / duration);
            sr.color = new Color(c.r, c.g, c.b, a);
            yield return null;
        }
        sr.color = new Color(c.r, c.g, c.b, to);
    }
    public static IEnumerator FadeCanvasGroup(CanvasGroup cg, float from, float to, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }
        cg.alpha = to;
    }
    public static IEnumerator PulseScale(Transform target, float minScale, float maxScale, float speed)
    {
        // Dipakai untuk efek "berdenyut" sederhana, misal ikon HP berkedip saat bisa diambil
        while (true)
        {
            float s = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * speed) + 1f) / 2f);
            target.localScale = Vector3.one * s;
            yield return null;
        }
    }
}