using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    static int mapsize = 5;
    
    [SerializeField]
    GameObject cubemap;

    void Start()
    {
        for (int i = 0; i < mapsize; i++)
        {
            for (int j = 0; j < mapsize; j++)
            {
                GameObject cube = Instantiate(cubemap, new Vector3(i, 0.5f, j),Quaternion.identity);
                cube.transform.SetParent(gameObject.transform);
            }
        }

        
    }

}
