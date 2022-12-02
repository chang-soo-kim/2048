using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    int maxHP = 10;
    public int curHP;
    int speed = 1;
    Vector3 dir;
    int dropGold = 10;
    
    void Start()
    {
        dir = Vector3.forward;
        curHP = maxHP;
    }

    
    void Update()
    {
        Vector3 Move = dir * Time.deltaTime * speed;
        transform.Translate(Move, Space.World);
        if (transform.position.z > 5.5f && dir == Vector3.forward)
        {
            transform.position = new Vector3(-1.5f, 1.25f,5.5f);
            dir = Vector3.right;
        }
        else if (transform.position.x > 5.5f && dir == Vector3.right)
        {
            transform.position = new Vector3(5.5f, 1.25f, 5.5f);
            dir = Vector3.back;
        }
        else if (transform.position.z < -1f && dir == Vector3.back)
        {
            Destroy(gameObject);
        }
        Debug.Log(curHP);

        if(curHP > 0f)
        {
            Die();
        }

    }
    void Die()
    {
        Destroy(gameObject);
    }
}
