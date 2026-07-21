using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    [Header("Clips")]
    public AudioClip bgmGlitchedClassroom;
    public AudioClip bgmEpiloguePiano;
    public AudioClip sfxHeartbeat;
    public AudioClip sfxKeyboardTyping;
    public AudioClip sfxJumpscareStinger;
    public AudioClip sfxGlitchBlip;
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }
    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayOneShotGlitch()
    {
        if (sfxGlitchBlip != null) sfxSource.PlayOneShot(sfxGlitchBlip);
    }
    // Heartbeat dengan pitch dinamis, dipanggil dari StressManager sesuai jarak ke episentrum
    public void SetHeartbeatIntensity(float t) // t = 0 (jauh) sampai 1 (dekat sekali)
    {
        if (!sfxSource.isPlaying || sfxSource.clip != sfxHeartbeat)
        {
            sfxSource.clip = sfxHeartbeat;
            sfxSource.loop = true;
            sfxSource.Play();
        }
        sfxSource.pitch = Mathf.Lerp(0.8f, 1.6f, t);
        sfxSource.volume = Mathf.Lerp(0.2f, 1f, t);
    }
    public void StopHeartbeat()
    {
        if (sfxSource.clip == sfxHeartbeat) sfxSource.Stop();
    }
}