using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{

    
    public int Num = 2;
    public int PrefabNum = 0;
    float min = 100f;
    float now;
    float oldTime = 0f;
    float damage = 0f;
    [SerializeField]
    TextMeshPro numtext;

    int x;
    int z;

    private void Start()
    {
        x = (int)this.transform.position.x;
        z = (int)this.transform.position.z;
    }

    public void Update()
    {
        Att();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;    
        Gizmos.DrawSphere(transform.position, 2f);
    }

    public void Att()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f, 1 << LayerMask.NameToLayer("Enemy"));

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

    //public void emptySpaceMove( Vector3 dir)
    //{
    //    while (true)
    //    {
    //        //  맨끝까지 아무것도 없을때 끝가지감
    //        if (GameController.Instance.allBlock[x + 1, z] == null)
    //        {
              
    //            transform.position += dir;
    //            x = (int)this.transform.position.x;
    //            z = (int)this.transform.position.z;
    //            GameController.Instance.allBlock[x, z] = GameController.Instance.allBlock[x - 1, z];
    //            GameController.Instance.allBlock[x - 1, z] = null;
    //        }
    //        // 옆으로갔을때 같은게 있으면 합쳐짐
    //        else if (GameController.Instance.allBlock[x + 1, z].Num == GameController.Instance.allBlock[x, z].Num)
    //        {
    //            GameController.Instance.allBlock[x, z] = null;
    //            GameController.Instance.allBlock[x + 1, z].Num *= 2;

    //            --GameController.Instance.count;
    //            Destroy(gameObject);
    //            break;
    //        }
    //        // 둘다 아니면 멈춤
    //        else
    //        {
    //            // --gameController.CreateCount;
    //            break;
    //        }
    //    }
    //}


    public void Right()
    {
        //if (x < 3)
        {
            //++gameController.CreateCount;
            while (x < 3)
            {
                //  맨끝까지 아무것도 없을때 끝가지감
                if (GameController.Instance.allBlock[x + 1, z] == null)
                {
                    transform.position += Vector3.right;
                    x = (int)this.transform.position.x;
                    z = (int)this.transform.position.z;
                    GameController.Instance.allBlock[x, z] = GameController.Instance.allBlock[x - 1, z];
                    GameController.Instance.allBlock[x - 1, z] = null;
                }
                // 옆으로갔을때 같은게 있으면 합쳐짐
                else if (GameController.Instance.allBlock[x + 1, z].Num == GameController.Instance.allBlock[x, z].Num)
                {
                    GameController.Instance.allBlock[x, z] = null;
                    GameController.Instance.allBlock[x + 1, z].Num *= 2;

                    ++GameController.Instance.allBlock[x + 1, z].PrefabNum;
                    Destroy(GameController.Instance.allBlock[x + 1, z].transform.GetChild(1).gameObject);
                    GameController.Instance.CreatePrefab(x + 1, z, GameController.Instance.allBlock[x + 1, z].PrefabNum);
                    

                    --GameController.Instance.count;
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

            //++gameController.CreateCount;
            while (z < 3)
            {

                if (GameController.Instance.allBlock[x, z + 1] == null)
                {
                    transform.position += Vector3.forward;
                    x = (int)this.transform.position.x;
                    z = (int)this.transform.position.z;
                    GameController.Instance.allBlock[x, z] = GameController.Instance.allBlock[x, z - 1];
                    GameController.Instance.allBlock[x, z - 1] = null;
                }

                else if (GameController.Instance.allBlock[x, z + 1].Num == GameController.Instance.allBlock[x, z].Num)
                {
                    GameController.Instance.allBlock[x, z] = null;
                    GameController.Instance.allBlock[x, z + 1].Num *= 2;

                ++GameController.Instance.allBlock[x, z + 1].PrefabNum;
                Destroy(GameController.Instance.allBlock[x, z + 1].transform.GetChild(1).gameObject);
                GameController.Instance.CreatePrefab(x, z + 1, GameController.Instance.allBlock[x, z + 1].PrefabNum);

                --GameController.Instance.count;
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
    public void Left()
    {
            //++gameController.CreateCount;
            while (x > 0)
            {
                if (GameController.Instance.allBlock[x - 1, z] == null)
                {
                    transform.position += Vector3.left;
                    x = (int)this.transform.position.x;
                    z = (int)this.transform.position.z;
                    GameController.Instance.allBlock[x, z] = GameController.Instance.allBlock[x + 1, z];
                    GameController.Instance.allBlock[x + 1, z] = null;
                }

                else if (GameController.Instance.allBlock[x - 1, z].Num == GameController.Instance.allBlock[x, z].Num)
                {
                    GameController.Instance.allBlock[x, z] = null;
                    GameController.Instance.allBlock[x - 1, z].Num *= 2;

                ++GameController.Instance.allBlock[x - 1, z].PrefabNum;
                Destroy(GameController.Instance.allBlock[x - 1, z].transform.GetChild(1).gameObject);
                GameController.Instance.CreatePrefab(x - 1, z, GameController.Instance.allBlock[x - 1, z].PrefabNum);

                --GameController.Instance.count;
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
    public void Down()
    {

            //++gameController.CreateCount;
            while (z > 0)
            {
                if (GameController.Instance.allBlock[x, z - 1] == null)
                {
                    transform.position += Vector3.back;
                    x = (int)this.transform.position.x;
                    z = (int)this.transform.position.z;
                    GameController.Instance.allBlock[x, z] = GameController.Instance.allBlock[x, z + 1];
                    GameController.Instance.allBlock[x, z + 1] = null;
                }

                else if (GameController.Instance.allBlock[x, z - 1].Num == GameController.Instance.allBlock[x, z].Num)
                {
                    GameController.Instance.allBlock[x, z] = null;
                    GameController.Instance.allBlock[x, z - 1].Num *= 2;

                ++GameController.Instance.allBlock[x, z - 1].PrefabNum;
                Destroy(GameController.Instance.allBlock[x, z - 1].transform.GetChild(1).gameObject);
                GameController.Instance.CreatePrefab(x, z - 1, GameController.Instance.allBlock[x, z - 1].PrefabNum);

                --GameController.Instance.count;
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
