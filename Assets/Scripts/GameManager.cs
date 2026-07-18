using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerscore;
    public int Playerscore { get { return playerscore; } set { playerscore = value; } }

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
