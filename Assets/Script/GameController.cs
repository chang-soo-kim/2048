using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private GameController() { }
    private static GameController _instance = null; //static으로 싱글톤 클래스 유일 선언
    GameObject pool;
    public GameObject removeCude;
    [SerializeField]
    GameObject[] BlockPrefab;




    public static GameController Instance //프로퍼티 선언
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameController>();

                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameController>();
                }
            }
            return _instance;// 인스턴스의 값이 null이 아니라면 SingletonClass 오브젝트를 찾아 _instance에 할당합니다.
        }
    }




    public int count = 0;
    //public int CreateCount = 0;
    [SerializeField]
    Block CubePrefab;
    [SerializeField]
    Enemy EnemyPrefab;
    public int enemyLiveCount;
    int enemyCount = 10;

    public Block[,] allBlock;

    public int Gold = 0;
    public float damage = 5f;
    public bool isBattle = false;
    public int Wave;


    public void CreateBlock()
    {

        if (count == 16)
        {
            //if(GameOverCheck())
            //{
            //    return;
            //}
            return;
        }
        //if (CreateCount == 0) return;
        

        int x = Random.Range(0, 4);
        int y = Random.Range(0, 4);

        while (allBlock[x, y] != null)
        {
            x = Random.Range(0, 4);
            y = Random.Range(0, 4);
        }
        Gold -= 10;
        allBlock[x, y] = Instantiate(CubePrefab, new Vector3(x, 1.25f, y), Quaternion.identity);
        allBlock[x, y].transform.SetParent(gameObject.transform);
        //allBlock[x, y].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        ++count;

    }
    public void CreatePrefab(int x, int y , int Num)
    {
        Instantiate(BlockPrefab[Num], new Vector3(x, 1.25f, y), Quaternion.identity,allBlock[x, y].transform);
    }


    //public bool GameOverCheck()
    //{
    //    for (int x = 0; x < 5; x++)
    //    {
    //        for (int y = 0; y < 4; y++)
    //        {
    //            if(allBlock[x, y].Num == allBlock[x, y + 1].Num)
    //            {
    //                return false;
    //            }
    //        }
    //    }
    //    for (int y = 0; y < 5; y++)
    //    {
    //        for (int x = 0; x < 4; x++)
    //        {
    //            if (allBlock[x, y].Num == allBlock[x+1, y].Num)
    //            {
    //                return false;
    //            }
    //        }
    //    }
    //    return true;

    //}

    void Start()
    {
        pool = new GameObject("EnemyPool");
        allBlock = new Block[4, 4];
        Wave = 0;
        //CreateCount = 1;
        enemyLiveCount = 5;
        CreateBlock();
        UIManager.Instance.Create += CreateBlock;
        Gold = 50;
        // CreateEnemy();
    }

    void Update()
    {
        //UIManager.Instance.Goldtxt.text = "Gold" + Gold.ToString();
        //UIManager.Instance.WaveCounttxt.text = "Wave" + Wave;
        //UIManager.Instance.enemycounttxt.text = "Count" + enemyLiveCount.ToString();
        if (pool.transform.childCount == 0 && isBattle)
        {
            isBattle = false;
        }

        if (isBattle) return;
        MoveControll();

        RemoveCube();
    }

    public void RemoveCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "PlayerCube")
                {
                    if (removeCude != null)
                        removeCude.GetComponent<MeshRenderer>().material.color = Color.red;
                    removeCude = hit.transform.gameObject;
                    removeCude.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    Debug.Log(removeCude);
                }
            }
        }
    }

    public void MoveControll()
    {
        
        //if (Gold < 10 || isBattle) return;
        if (isBattle) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int x = 3; x >= 0; x--)
            {
                for (int y = 3; y >= 0; y--)
                {
                    if (allBlock[x, y] != null)
                    allBlock[x, y].Right();
                }
            }
            CreateBlock();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (allBlock[x, y] != null)
                        allBlock[x, y].Left();
                }
            }
            CreateBlock();
        }


        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int y = 3; y >= 0; y--)
            {
                for (int x = 3; x >= 0; x--)
                {
                    if (allBlock[x, y] != null)
                        allBlock[x, y].Up();
                }
            }
            CreateBlock();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (allBlock[x, y] != null)
                        allBlock[x, y].Down();
                }
            }
            CreateBlock();
        }
    }

    public void CreateEnemy()
    {
        for (int i = 0; i < enemyCount + Wave; i++)
        {
            Instantiate(EnemyPrefab, new Vector3(-1.5f, 1.25f, -1.5f - (i * 1.5f)), Quaternion.identity, pool.transform);
        }
    }

    public void GameOver()
    {
        if (enemyLiveCount == 0)
        {
            UIManager.Instance.GameOver();
        }
    }
}
