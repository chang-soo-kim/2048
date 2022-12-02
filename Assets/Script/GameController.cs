using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int count = 0;
    public int CreateCount = 0;
    [SerializeField]
    Cube CubePrefab;
    public Cube[,] allCube;

    public int Gold = 0;
    public float damage = 5f;

    public void CreateCube()
    {
        if (count == 25)
        {
            if(GameOverCheck())
            {
                UIManager.Instance.GameOver();
                return;
            }
            return;
        }
        if (CreateCount == 0) return;


        int x = Random.Range(0 , 5);
        int y = Random.Range(0 , 5);

        while (allCube[x,y] != null)
        {
            x = Random.Range(0, 5);
            y = Random.Range(0, 5);
        }
        allCube[x,y] = Instantiate(CubePrefab, new Vector3(x, 1.25f, y), Quaternion.identity);
        allCube[x, y].transform.SetParent(gameObject.transform);
        allCube[x, y].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        ++count;
        CreateCount = 0;
    }

    public bool GameOverCheck()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if(allCube[x, y].Num == allCube[x, y + 1].Num)
                {
                    return false;
                }
            }
        }
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (allCube[x, y].Num == allCube[x+1, y].Num)
                {
                    return false;
                }
            }
        }
        return true;

    }

    void Start()
    {
        allCube = new Cube[5,5];
        CreateCount = 1;
        CreateCube();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int x = 4; x >= 0; x--)
            {
                for (int y = 4; y >= 0; y--)
                {
                    if (allCube[x, y] != null)
                        allCube[x, y].Right();
                }
            }

            CreateCube();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (allCube[x, y] != null)
                        allCube[x, y].Left();
                }
            }
            CreateCube();
        }


        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int y = 4; y >= 0; y--)
            {
                for (int x = 4; x >= 0; x--)
                {
                    if (allCube[x, y] != null)
                        allCube[x, y].Up();
                }
            }
            CreateCube();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (allCube[x, y] != null)
                        allCube[x, y].Down();
                }
            }
            CreateCube();
        }



    }
}
