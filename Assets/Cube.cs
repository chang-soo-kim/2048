using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    
    CubeSpawner cubeSpawner;
    public int Num = 2;
    [SerializeField]
    TextMeshPro numtext;
    void Start()
    {
        cubeSpawner = FindObjectOfType<CubeSpawner>();   
    }


    public void Update()
    {
        numtext.text = Num.ToString();
    }

    public void Right()
    {
        if (gameObject.transform.position.x < 4)
        {
            ++cubeSpawner.CreateCount;
            while (gameObject.transform.position.x < 4)
            {
                //  �ǳ����� �ƹ��͵� ������ ��������
                if (cubeSpawner.allCube[(int)transform.position.x + 1, (int)transform.position.z] == null)
                {
                    transform.position += Vector3.right;
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = cubeSpawner.allCube[(int)transform.position.x - 1, (int)transform.position.z];
                    cubeSpawner.allCube[(int)transform.position.x - 1, (int)transform.position.z] = null;
                }
                // �����ΰ����� ������ ������ ������
                else if (cubeSpawner.allCube[(int)transform.position.x + 1, (int)transform.position.z].Num == cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    cubeSpawner.allCube[(int)transform.position.x + 1, (int)transform.position.z].Num *= 2;
                    
                    --cubeSpawner.count;
                    Destroy(gameObject);
                    break;
                }
                // �Ѵ� �ƴϸ� ����
                else
                {
                    --cubeSpawner.CreateCount;
                    break;
                }
            }
            
        }
    }
    public void Up()
    {
        if (gameObject.transform.position.z < 4)
        {
            ++cubeSpawner.CreateCount;
            while (gameObject.transform.position.z < 4)
            {

                if (cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z + 1] == null)
                {
                    transform.position += Vector3.forward;
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z - 1];
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z - 1] = null;
                }

                else if (cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z + 1].Num == cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z + 1].Num *= 2;
                    
                    --cubeSpawner.count;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    --cubeSpawner.CreateCount;
                    break;
                }
            }
        
        }
    }
    public void Left()
    {
        if (gameObject.transform.position.x > 0)
        {
            ++cubeSpawner.CreateCount;
            while (gameObject.transform.position.x > 0)
            {
                if (cubeSpawner.allCube[(int)transform.position.x - 1, (int)transform.position.z] == null)
                {
                    transform.position += Vector3.left;
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = cubeSpawner.allCube[(int)transform.position.x + 1, (int)transform.position.z];
                    cubeSpawner.allCube[(int)transform.position.x + 1, (int)transform.position.z] = null;
                }

                else if (cubeSpawner.allCube[(int)transform.position.x - 1, (int)transform.position.z].Num == cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    cubeSpawner.allCube[(int)transform.position.x - 1, (int)transform.position.z].Num *= 2;
                    
                    --cubeSpawner.count;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    --cubeSpawner.CreateCount;
                    break;
                }
            }
        }
    }
    public void Down()
    {
        if (gameObject.transform.position.z > 0)
        {
            ++cubeSpawner.CreateCount;
            while (gameObject.transform.position.z > 0)
            {
                if (cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z - 1] == null)
                {
                    transform.position += Vector3.back;
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z + 1];
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z + 1] = null;
                }

                else if (cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z - 1].Num == cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z].Num)
                {
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z] = null;
                    cubeSpawner.allCube[(int)transform.position.x, (int)transform.position.z - 1].Num *= 2;
                    
                    --cubeSpawner.count;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    --cubeSpawner.CreateCount;
                    break;
                }
            }
        }
    }

   


}
