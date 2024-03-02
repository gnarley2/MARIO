using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnim : MonoBehaviour
{
    private float duration = 0.5f;
    private Vector2 offset = new Vector2(0, 1);

    private Vector2 startPos;
    private Vector2 endPos;
    
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
        Destroy(gameObject);
    }
}
