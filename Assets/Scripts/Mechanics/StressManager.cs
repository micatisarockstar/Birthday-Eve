using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class StressManager : MonoBehaviour
{
    public float sanityValue = 100f;
    public float drainRate = 12f;
    public float regenRate = 6f;
    public ParticleSystem noseBleedParticles;
    public Volume horrorVolume; // Global Volume URP dengan override Vignette
    private Vignette vignette;
    void Start()
    {
        horrorVolume.profile.TryGet(out vignette);
    }
    public void TriggerNoseBleed(bool isActive)
    {
        if (isActive)
        {
            if (!noseBleedParticles.isPlaying) noseBleedParticles.Play();
            sanityValue -= drainRate * Time.deltaTime;
            if (vignette != null)
            {
                vignette.intensity.value = Mathf.Lerp(0.25f, 0.6f, 1f - (sanityValue / 100f));
                vignette.color.value = Color.Lerp(Color.black, Color.red, 1f - (sanityValue / 100f));
            }
        }
        else
        {
            noseBleedParticles.Stop();
            sanityValue = Mathf.Min(100f, sanityValue + regenRate * Time.deltaTime);
            if (vignette != null) vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.15f, 0.1f);
        }
        if (sanityValue <= 0f) Faint();
    }
    public void ApplyShockPenalty(float amount)
    {
        sanityValue -= amount;
        if (sanityValue <= 0f) Faint();
    }
    void Faint()
    {
        sanityValue = 100f;
        SceneFlowController.Instance.LoadSceneByIndex(2); // respawn di Corridor
    }
}