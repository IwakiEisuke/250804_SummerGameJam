using UnityEngine;

public class soba : MonoBehaviour
{

    public GameObject prefab;
    [SerializeField] private Transform SpawnaPos;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            InstanceSoba();
        }

    }

    public void InstanceSoba()
    {
        Instantiate(prefab, SpawnaPos.position, Quaternion.identity);
    }

}

