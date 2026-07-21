using UnityEngine;
public class EpilogueController : MonoBehaviour
{
    public static bool PendingBadEnding = false; // di-set dari SceneFlowController kalau Glitch Timer habis
    public GameObject[] subAreas; // 0=Classroom,1=Street,2=Mother,3=Hospital,4=Girl,5=Graveyard
    public GameObject badEndingSequence; // sequence alternatif jika PendingBadEnding true
    void Start()
    {
        if (PendingBadEnding)
        {
            foreach (var area in subAreas) area.SetActive(false);
            badEndingSequence.SetActive(true);
            return;
        }
        ShowSubArea(0);
    }
    public void ShowSubArea(int index)
    {
        for (int i = 0; i < subAreas.Length; i++)
            subAreas[i].SetActive(i == index);
    }
}