using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 5; ++i)
        {
            for (var j = 0; j < 10; ++j)
            {
                Instantiate(prefab, new Vector3(j * 1.0f - 5.0f, i * 1.0f, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
