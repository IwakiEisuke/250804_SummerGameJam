using UnityEngine;
using UnityEngine.UI;

public class RankingItemView : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public void SetData(RankingItem item, int rankIndex)
    {
        if (item == null)
        {
            scoreText.text = "N/A"; // データがない場合の表示
        }
        else
        {
            scoreText.text = $"{rankIndex + 1}位 {item.score}杯"; // ランキングとスコアを表示
        }
    }
}
