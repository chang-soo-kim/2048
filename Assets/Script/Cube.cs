using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{

    GameController gameController;
    public int Num = 2;
    float min = 100f;
    float now;
    float oldTime = 0f;
    float damage = 0f;
    [SerializeField]
    TextMeshPro numtext;
    void Start()
    {
        
        gameController = FindObjectOfType<GameController>();
        
    }


    public void Update()
    {
        Att();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;    
        Gizmos.DrawSphere(transform.position, 3f);
    }

    public void Att()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f, 1 << LayerMask.NameToLayer("Enemy"));

        oldTime += Time.deltaTime;

        for (int i = 0; i < colliders.Length - 1; i++)
        {
            if (colliders.Length > 2)
            {
                now = Vector3.Distance(colliders[i].transform.position, transform.position);

                if (min < now)
                {
                    colliders[0] = colliders[i];
                    min = Vector3.Distance(colliders[i].transform.position, transform.position);
                }
            }
        }
        min = 100f;

        if (colliders.Length > 0 && oldTime > 1f)
        {
            damage = Num * 0.5f;
            colliders[0].gameObject.GetComponent<Enemy>().curHP -= (int)damage;
            oldTime = 0f;
        }

        numtext.text = Num.ToString();
    }
    public void Right()
    {
        if (gameObject.transform.position.x < 4)
        {
            //++gameController.CreateCount;
            while (gameObject.transform.position.x < 4)
            {
                //  맨끝까지 아무것도 없을때 끝가지감
                if (gameController.allCube[(int)transform.position.x + 1, (int)transform.position.z] == null)
                {
                    transform.position += Vector3.right;
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = gameController.allCube[(int)transform.position.x - 1, (int)transform.position.z];
                    gameController.allCube[(int)transform.position.x - 1, (int)transform.position.z] = null;
                }
                // 옆으로갔을때 같은게 있으면 합쳐짐
                else if (gameController.allCube[(int)transform.position.x + 1, (int)transform.position.z].Num == gameController.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    gameController.allCube[(int)transform.position.x + 1, (int)transform.position.z].Num *= 2;
                    
                    --gameController.count;
                    Destroy(gameObject);
                    break;
                }
                // 둘다 아니면 멈춤
                else
                {
                   // --gameController.CreateCount;
                    break;
                }
            }
            
        }
    }
    public void Up()
    {
        if (gameObject.transform.position.z < 4)
        {
            //++gameController.CreateCount;
            while (gameObject.transform.position.z < 4)
            {

                if (gameController.allCube[(int)transform.position.x, (int)transform.position.z + 1] == null)
                {
                    transform.position += Vector3.forward;
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = gameController.allCube[(int)transform.position.x, (int)transform.position.z - 1];
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z - 1] = null;
                }

                else if (gameController.allCube[(int)transform.position.x, (int)transform.position.z + 1].Num == gameController.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z + 1].Num *= 2;
                    
                    --gameController.count;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    //--gameController.CreateCount;
                    break;
                }
            }
        
        }
    }
    public void Left()
    {
        if (gameObject.transform.position.x > 0)
        {
            //++gameController.CreateCount;
            while (gameObject.transform.position.x > 0)
            {
                if (gameController.allCube[(int)transform.position.x - 1, (int)transform.position.z] == null)
                {
                    transform.position += Vector3.left;
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = gameController.allCube[(int)transform.position.x + 1, (int)transform.position.z];
                    gameController.allCube[(int)transform.position.x + 1, (int)transform.position.z] = null;
                }

                else if (gameController.allCube[(int)transform.position.x - 1, (int)transform.position.z].Num == gameController.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    gameController.allCube[(int)transform.position.x - 1, (int)transform.position.z].Num *= 2;
                    
                    --gameController.count;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    //--gameController.CreateCount;
                    break;
                }
            }
        }
    }
    public void Down()
    {
        if (gameObject.transform.position.z > 0)
        {
            //++gameController.CreateCount;
            while (gameObject.transform.position.z > 0)
            {
                if (gameController.allCube[(int)transform.position.x, (int)transform.position.z - 1] == null)
                {
                    transform.position += Vector3.back;
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = gameController.allCube[(int)transform.position.x, (int)transform.position.z + 1];
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z + 1] = null;
                }

                else if (gameController.allCube[(int)transform.position.x, (int)transform.position.z - 1].Num == gameController.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    gameController.allCube[(int)transform.position.x, (int)transform.position.z - 1].Num *= 2;
                    
                    --gameController.count;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    //--gameController.CreateCount;
                    break;
                }
            }
        }
    }

   


}
