using UnityEngine;
public class CorridorLoopManager : MonoBehaviour
{
    public Transform player;
    public float leftBound = -20f;
    public float rightBound = 20f;
    public float teleportOffset = 0.5f;
    public int loopCount = 0;
    public SpriteRenderer[] tilemapVariants; // 0 = monochrome, 1 = warm
    void Update()
    {
        if (player.position.x <= leftBound)
        {
            player.position = new Vector3(rightBound - teleportOffset, player.position.y, player.position.z);
            RegisterLoop();
        }
        else if (player.position.x >= rightBound)
        {
            player.position = new Vector3(leftBound + teleportOffset, player.position.y, player.position.z);
            RegisterLoop();
        }
    }
    void RegisterLoop()
    {
        loopCount++;
        // Setiap 3x loop, munculkan sedikit distorsi audio/visual agar terasa map "expanding"
        if (loopCount % 3 == 0)
            AudioManager.Instance?.PlayOneShotGlitch();
    }
    public void SwitchToWarmVariant()
    {
        // Dipanggil setelah event "Tolong Ingat Aku" selesai
        foreach (var sr in tilemapVariants) sr.gameObject.SetActive(false);
        tilemapVariants[1].gameObject.SetActive(true);
    }
}