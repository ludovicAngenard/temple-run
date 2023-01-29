using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class Ground : MonoBehaviour
{
    private GameObject currentCoin;
    private GameObject coin;
    private GameObject diamond;
    private GameObject emerald;
    private GameObject ruby;
    private GameObject darkDiamond;
    private Quaternion spawnDirection;
    public static MeshRenderer meshRenderer;
    private int groundSize;
    private float groundStartPoint;
    private float groundEndPoint;
    private const string OBSTACLE_NAME = "Obstacle";
    private List<Vector3> spawnPositionsList = new List<Vector3>();
    private List<RaycastHit[]> hitsList = new List<RaycastHit[]>();
    private Manager manager;
    bool isStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        coin = Resources.Load("Prefabs/Coins/Pièce") as GameObject;
        emerald = Resources.Load("Prefabs/Coins/Emeraude") as GameObject;
        ruby = Resources.Load("Prefabs/Coins/Rubis") as GameObject;
        diamond = Resources.Load("Prefabs/Coins/Diamant") as GameObject;
        darkDiamond = Resources.Load("Prefabs/Coins/DarkDiamant") as GameObject;
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        meshRenderer = GetComponent<MeshRenderer>();
        groundSize = (int)Math.Round(meshRenderer.bounds.size.z, MidpointRounding.AwayFromZero);
        groundStartPoint = (int)Math.Round(transform.position.z - (groundSize / 2));
        groundEndPoint = (int)Math.Round(transform.position.z + (groundSize / 2));
        var random = new Random();
        int index = random.Next(manager.roadsXList.Count);
        for (float zPoint = groundStartPoint; zPoint <= groundEndPoint; zPoint += 3)
        {
            Vector3 spawnPosition = new Vector3(manager.roadsXList[index], transform.position.y + 1, zPoint);
            spawnPositionsList.Add(spawnPosition);
            ChoseCoin(spawnPosition);
        }
        isStarted = true;
        
    }
        // Update is called once per frame
    void Update()
    {
         
        // Définition de tous les raycasts

       
    }

    void ChoseCoin(Vector3 spawn)
    {
        float perCent = new Random().Next(0, 100);    
        if (perCent < 80)
        {
            currentCoin = coin;
            spawnDirection = Quaternion.Euler(145, -95, -278);
        }
        else if (perCent < 94)
        {
            spawnDirection = Quaternion.identity;
            currentCoin = emerald;
        }
        else if (perCent < 99)
        {
            spawnDirection = Quaternion.identity;
            currentCoin = ruby;
        }
        else if (perCent < 99.5)
        {
            spawnDirection = Quaternion.identity;
            currentCoin = diamond;
        }
        else
        {
            spawnDirection = Quaternion.identity;
            currentCoin = darkDiamond;
        }
        Instantiate(currentCoin, spawn, spawnDirection);
    }
}
