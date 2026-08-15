using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerScore;

    public static GameManager instance;

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    [SerializeField]
    private GameObject[] ballPosition;

    [SerializeField]
    private GameObject ballPrefab;

    private GameObject currentBall;

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

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootBall();
        }
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(
            ballPrefab,
            ballPosition[i].transform.position,
            Quaternion.identity
        );

        Ball b = obj.GetComponent<Ball>();
        b.Color(col);

        // เก็บเฉพาะลูกที่ 0 ไว้สำหรับยิง
        if (i == 0)
        {
            currentBall = obj;
        }
    }

    private void ShootBall()
    {
        if (currentBall == null)
            return;

        Rigidbody rb = currentBall.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddRelativeForce(
                Vector3.forward * 50,
                ForceMode.Impulse
            );
        }
    }
}