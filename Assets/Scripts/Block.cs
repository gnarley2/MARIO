using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    enum BlockType
    {
        None,
        Coin,
        Mushroom,
        
    }

    [SerializeField] private BlockType blockType;
    [SerializeField] private int numBreak;
    [SerializeField] private bool isQuestionBlock;
    [SerializeField] private Sprite questionBlockToNormal;

    [Header("Coin")] 
    [SerializeField] private CoinAnim coin;
    
    [Header("Mushroom")]
    [SerializeField] private Mushroom mushroom;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // if (isQuestionBlock)
        // {
        //     isQuestionBlock = false;
        //     Break();
        // }
    }

    public void Break()
    {
        if (numBreak <= 0) return;
        
        switch (blockType)
        {
            case BlockType.Coin:
                SpawnCoin();
                break;
            case BlockType.Mushroom:
                SpawnMushroom();
                break;
            
        }

        numBreak -= 1;
        if (numBreak <= 0)
        {
            if (!isQuestionBlock) Destroy(gameObject);
            else
            {
                sprite.sprite = questionBlockToNormal;
            }
        }
    }

    void SpawnCoin()
    {
        GameManager.Instance.AddCoin();
        
        Vector3 offset = new Vector3(0, 0.5f, 0);
        Instantiate(coin, transform.position + offset, Quaternion.identity);
    }

    void SpawnMushroom()
    {
        Vector3 offset = new Vector3(0, 0.5f, 0);
        Instantiate(mushroom, transform.position + offset, Quaternion.identity);
    }
}
