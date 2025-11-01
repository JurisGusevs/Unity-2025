using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public int lifeCount = 3;

    public static GameManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        text.text = "Lifes: " + lifeCount;
    }

    public void LooseLife(bool shouldDie = false)
    {
        if (lifeCount > 0)
        {
            if (shouldDie)
            {
                lifeCount = 0;
            } 
            else
            {
                lifeCount--;
            }
            text.text = "Lifes: " + lifeCount;
        }
    }
}
