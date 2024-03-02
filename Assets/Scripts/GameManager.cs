using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int lives { get; private set; }
    public int coins { get; private set; }  

    void Start()
    {
        Instance = this;
        // NewGame();
    }

    private void NewGame()
    {
        // TODO
    }

    public void AddCoin()
    {
        coins++;

        if (coins == 100)
        {
            AddLife();
            coins = 0;
        }
    }

    public void AddLife()
    {
        lives++;
    }
}
