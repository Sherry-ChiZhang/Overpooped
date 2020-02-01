﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    White,
    Black,
    Double
};

public enum CreamType
{
    Unfilled,
    Filled,
    Overfilled
}

public class Order : MonoBehaviour
{
    public OrderType type;
    public CreamType state;
    public float speed;
    public int value;

    float delaytime = 5f;
    bool isMove = false;
    bool isReadyMake, isReadyAssess;

    public bool IsMove
    {
        get { return isMove; }
    }

    public bool IsReadyMake
    {
        get { return isReadyMake; }
    }
    public bool IsReadyAssess
    {
        get { return isReadyAssess; }
    }

    void Start()
    {
        isReadyMake = isReadyAssess = false;
    }

    void Update()
    {
        if (isMove)
        {
            Vector3 tmp = transform.position;
            tmp.x += speed * Time.deltaTime;
            transform.position = tmp;
        }
    }

    public void Initailize(OrderType curType, float curSpeed)
    {
        speed = curSpeed;
        value = 0;
        StartMove();
    }

    public void StartMove()
    {
        isMove = true;
    }

    public void PauseMove()
    {
        isMove = false;
    }

    public void DestroyOrder()
    {
        Debug.Log("Order: destroy the order");
        Destroy(this.gameObject, delaytime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Machine")
        {
            isReadyMake = true;
        }
        else if(collision.gameObject.tag == "Assessor")
        {
            isReadyMake = false;
            isReadyAssess = true;
        }
        PauseMove();
    }
}
