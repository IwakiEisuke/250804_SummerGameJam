using UnityEngine;

public class GaugeController : MonoBehaviour
{
    [SerializeField] float gaugeAddValue = 10f;
    [SerializeField] gauge gauge;

    public void AddGauge()
    {
        if (gauge != null)
        {
            gauge.AddFullness(gaugeAddValue);
        }
        else
        {
            Debug.LogWarning("Gauge reference is not set in GaugeController.");
        }
    }
}
