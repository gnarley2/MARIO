using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private float velocity = 2f;
    
    private float duration = 0.5f;
    private Vector2 offset = new Vector2(0, 1);

    private Vector2 startPos;
    private Vector2 endPos;

    private bool canRun = false;
    
    private void Awake()
    {
        startPos = transform.position;
        endPos = startPos + offset;
        StartCoroutine(PlayAnimCoroutine());
    }

    IEnumerator PlayAnimCoroutine()
    {
        float time = Time.time;
        while (time + duration >= Time.time)
        {
            transform.position = Vector2.Lerp(startPos, endPos, (Time.time - time) / duration);
            yield return null;
        }

        transform.position = endPos;
        canRun = true;
    }

    private void Update()
    {
        if (!canRun) return;
        
        Move();
    }

    void Move()
    {
        transform.position += Vector3.right * velocity * Time.deltaTime;
    }
}
