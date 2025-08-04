using UnityEngine;
using UnityEngine.UI;

public class BowlCounter : MonoBehaviour
{
    public int bowlCount = 0;
    public Text countText;

    private void Start()
    {
        UpdateText();
    }

    [ContextMenu("addbowl")]
    public void AddBowl()
    {
        bowlCount++;
        UpdateText();
    }

    void UpdateText()
    {
        countText.text = bowlCount + "”t";
    }
}
