using UnityEngine;
using UnityEngine.UI;

public class ViewCurrentScore : MonoBehaviour
{
    [SerializeField] Text _text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text.text = ScoreManager.Instance.CurrentScore.ToString();
    }
}
