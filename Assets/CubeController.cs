using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    CubeSpawner cubeSpawner;
    void Start()
    {
        cubeSpawner = FindObjectOfType<CubeSpawner>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int x = 4; x >= 0; x--)
            {
                for (int y = 4; y >= 0; y--)
                {
                    if (cubeSpawner.allCube[x, y] != null)
                        cubeSpawner.allCube[x, y].Right();
                }
            }

            cubeSpawner.CreateCube();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (cubeSpawner.allCube[x, y] != null)
                        cubeSpawner.allCube[x, y].Left();
                }
            }

            cubeSpawner.CreateCube();

        }


        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int y = 4; y >= 0; y--)
            {
                for (int x = 4; x >= 0; x--)
                {
                    if (cubeSpawner.allCube[x, y] != null)
                        cubeSpawner.allCube[x, y].Up();
                }
            }

            cubeSpawner.CreateCube();

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (cubeSpawner.allCube[x, y] != null)
                        cubeSpawner.allCube[x, y].Down();
                }
            }

            cubeSpawner.CreateCube();

        }




    }
}
