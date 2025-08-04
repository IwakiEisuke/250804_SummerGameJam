using UnityEngine;

public class RankingTester : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    public RankingItem item;

    [ContextMenu("Register")]
    public void Register()
    {
        DataManager.RegisterRank(item);
    }

    [ContextMenu("Reset")]
    public void ResetRank()
    {
        DataManager.ResetRank();
    }
}
