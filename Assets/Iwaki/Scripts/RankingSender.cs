using UnityEngine;

public class RankingSender : MonoBehaviour
{
    [SerializeField] BowlCounter _bowlCounter;

    public void SendRanking()
    {
        var item = new RankingItem() { score = _bowlCounter.bowlCount };
        DataManager.RegisterRank(item);
        Debug.Log("スコアを保存しました: " + _bowlCounter.bowlCount + "杯");
    }
}
