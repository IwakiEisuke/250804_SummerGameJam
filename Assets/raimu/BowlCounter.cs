using System;
using UnityEngine;
using UnityEngine.UI;

public class BowlCounter : MonoBehaviour
{
    public int bowlCount = 0;
    public Text countText;

    public event Action<int> OnBowlCountChanged;

    private void Start()
    {
        UpdateText();
    }

    [ContextMenu("addbowl")]
    public void AddBowl()
    {
        bowlCount++;
        UpdateText();
        OnBowlCountChanged?.Invoke(bowlCount);
    }

    void UpdateText()
    {
        countText.text = bowlCount + "”t";
    }

    public void FinishGame()
    {
        ScoreManager.Instance.RegisterScore(bowlCount);
    }
}
