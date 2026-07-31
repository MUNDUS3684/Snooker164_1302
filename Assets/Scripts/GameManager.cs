using System;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    public static GameManager instance;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPosition;
    [SerializeField]
    private GameObject ballPrefab;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        int i = 0;
        foreach (GameObject go in ballPosition)
        {
            SetBall((BallColor)i, i);
            i++;

        }
    }
    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab,
                    ballPosition[i].transform.position,
                    Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.Color(col);
    }
}
