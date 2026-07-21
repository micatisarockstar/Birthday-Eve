using UnityEngine;
public class DayNightYardController : MonoBehaviour
{
    public GameObject dayVersion;
    public GameObject nightVersion;
    public GameObject bloodstainDecal;
    void Start()
    {
        bool isNight = GameManager.Instance.isNightmareState;
        dayVersion.SetActive(!isNight);
        nightVersion.SetActive(isNight);
        bloodstainDecal.SetActive(isNight);
    }
}