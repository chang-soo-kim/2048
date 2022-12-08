using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    
    int maxHP = 10;
    public int curHP;
    int speed = 1;
    Vector3 dir;
    int dropGold = 10;
    [SerializeField]
    TextMeshPro curHPtxt;

    void Start()
    {
        dir = Vector3.forward;
        curHP = maxHP * GameController.Instance.Wave;
    }

    
    void Update()
    {
        Vector3 Move = dir * Time.deltaTime * speed;
        transform.Translate(Move, Space.World);
        if (transform.position.z > 4.5f && dir == Vector3.forward)
        {
            transform.position = new Vector3(-1.5f, 1.25f,4.5f);
            dir = Vector3.right;
        }
        else if (transform.position.x > 4.5f && dir == Vector3.right)
        {
            transform.position = new Vector3(4.5f, 1.25f, 4.5f);
            dir = Vector3.back;
        }
        else if (transform.position.z < -1f && dir == Vector3.back)
        {
            --GameController.Instance.enemyLiveCount;
            GameController.Instance.GameOver();
            Destroy(gameObject);
        }
        Debug.Log(curHP);

        if(curHP <= 0f)
        {
            Die();
        }
        curHPtxt.text = curHP.ToString();
    }
    void Die()
    {
        GameController.Instance.Gold += dropGold;

        Destroy(gameObject);
    }
}
