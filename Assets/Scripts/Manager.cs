using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Manager : MonoBehaviour
{

    private GameObject currentGround;
    [SerializeField] private List<GameObject> groundsList;
    [SerializeField] public  int maxGround;
    public List<int> roadsXList = new List<int>() { -4, 0, 4 };
    private GameObject player;
    private List<string> groundsNameList = new List<string>() { "GroundObstacleNoJump", "GroundObstacleJump", "GroundObstacleRight" };
    private const string path = "/scores.json";
    private int level = 1;
    // Start is called before the first frame update
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        maxGround = 5 * level;

        player = Resources.Load("Prefabs/Player") as GameObject;
        Instantiate(player, new Vector3(0, 0, -5), Quaternion.identity);
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.speed = 6 + level;
        var random = new System.Random();

        for (int i = 1; i <= maxGround; i++)
        {
            int index = random.Next(groundsNameList.Count);
            GameObject currentGround = Resources.Load("Prefabs/" + groundsNameList[index]) as GameObject;
            Instantiate(currentGround, new Vector3(0, 0, i * 16), Quaternion.identity);
        }
    }

    public void SaveData(int score)
    {
        
        string json = JsonUtility.ToJson(player.GetComponent<PlayerController>());
        File.WriteAllText(path, json.ToString());
    }
    public void StartGame(int level)
    {

        this.level = level;
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
