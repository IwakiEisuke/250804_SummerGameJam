using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore;
    public int CurrentScore => _currentScore;

    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterScore(int score)
    {
        _currentScore = score;
    }
}
