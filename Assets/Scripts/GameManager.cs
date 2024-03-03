using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Canvas ui;

    public int lives { get; private set; }
    public int coins { get; private set; }

    private Text[] textComponents;

    private Text coinsText;

    void Start()
    {
        Instance = this;

        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        coins = 0;

        // TODO: add coins to coinsText
        textComponents = ui.GetComponentsInChildren<Text>();

        foreach (Text ct in textComponents)
        {
            if (ct.name == "Coins")
            {
                coinsText = ct;
            }
        }

        coinsText.text = "x " + coins.ToString();
    }

    public void AddCoin()
    {
        coins++;

        if (coins == 100)
        {
            AddLife();
            coins = 0;
        }

        coinsText.text = "x " + coins.ToString();
    }

    public void AddLife()
    {
        lives++;
    }
}
