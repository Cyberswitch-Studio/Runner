using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    // czas pomiedzy respawnem przeszkod i czas przed zaczeciem spawnowania (do ustalenia)
    private float timeToRespawn = 2f;
    private float delayBeforeRespawn = 2f;

    // koordynaty trzech sciezek po ktorych sie biegnie 
    private Vector3 firstPath;
    private Vector3 secondPath;
    private Vector3 thirdPath;

    // array przeszkod do spawnowania do przydzielenia w inspectorze
    [SerializeField]
    private GameObject[] obstacles = null;
    private GameObject spawnedObject = null;
    

    // array sciezek po ktorych sie biegnie
    private Vector3[] runningPaths;

    private void Awake()
    {
        firstPath = new Vector3(0, 2);
        secondPath = new Vector3(2, 2);
        thirdPath = new Vector3(4, 2);

        runningPaths = new Vector3[3] { firstPath, secondPath, thirdPath };
    }

    private void Start()
    {
        InvokeRepeating("SpawnObstacles", delayBeforeRespawn, timeToRespawn);
    }

    private void SpawnObstacles()
    {
        int randomObstacleIndex = Random.Range(0, obstacles.Length);
        int randomPathIndex = Random.Range(0, runningPaths.Length);
        spawnedObject = Instantiate(obstacles[randomObstacleIndex], runningPaths[randomPathIndex], Quaternion.identity);
        StartCoroutine("DestroyObstacle");

    }

    

    IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(1.0f);
        DestroyObject(spawnedObject);
        
    }

    private void DestroyObject(GameObject gm)
    {
        Destroy(gm);
    }
}

