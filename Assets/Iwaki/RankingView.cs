using UnityEngine;

public class RankingView : MonoBehaviour
{
    [SerializeField] Transform _rankingBoardRoot;
    [SerializeField] DataManager _dataManager;

    RankingData _rankingData; // ランキングデータのインスタンス

    private void Start()
    {
        _rankingData = _dataManager.Data;

        var items = _rankingBoardRoot.GetComponentsInChildren<RankingItemView>(false);
        var loop = Mathf.Min(items.Length, RankingData.rankCount);

        for (int i = 0; i < loop; i++)
        {
            items[i].SetData(_rankingData.ranks[i], i);
        }
    }
}

/// <summary>
/// ランキング情報の１個ずつ
/// </summary>
[System.Serializable]
public class RankingItem
{
    public int score;
}

/// <summary>
/// Jsonで保存するランキングデータ
/// </summary>
[System.Serializable]
public class RankingData
{
    public const int rankCount = 3;
    public RankingItem[] ranks = new RankingItem[rankCount];
}