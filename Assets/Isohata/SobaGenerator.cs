using UnityEngine;
using UnityEngine.UIElements;

public class SobaGenerator : MonoBehaviour
{

    public GameObject prefab;
    [SerializeField] 
    private Transform SpawnaPos;

    [Header("Soba Scale Range")]    
    [SerializeField]
    private float minScaleY = 1.0f;
    [SerializeField]
    private float maxScaleY = 5.0f;

    /// <summary>
    /// ÇªÇŒÇÃê∂ê¨
    /// </summary>
    public GameObject SpawnSoba()
    {
        GameObject soba = Instantiate(prefab, SpawnaPos.position, Quaternion.identity);
        soba = Instantiate(prefab, SpawnaPos.position, Quaternion.identity);

        float randomY = Random.Range(minScaleY, maxScaleY);
        Vector3 scale = soba.transform.localScale;
        scale.y = randomY;
        soba.transform.localScale = scale;

        return soba;
    }
}

