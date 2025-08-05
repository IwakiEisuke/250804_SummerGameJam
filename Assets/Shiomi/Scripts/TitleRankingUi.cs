using UnityEngine;

public class TitleRankingUi : MonoBehaviour
{
    [SerializeField] GameObject _RankingUi;
    
    private bool _isRanking;
    void Start()
    {
        _RankingUi.SetActive(_isRanking);
    }

    public void ChangeUi()
    {
        _isRanking = !_isRanking;
        _RankingUi.SetActive(_isRanking);
    }
}
