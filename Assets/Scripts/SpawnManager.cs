using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    Vector3 randomPos;
    public float rangeX = 1.5f;
    public float rangeZ = 4.0f;
    public AudioSource adSource;
    public AudioClip dominoSound;
    public float timeDelaySound = 1f;
    public GameManager gameManagerCs;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerCs = GameObject.Find("GameManager").GetComponent<GameManager>(); 
        adSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerCs.startGame == true && gameManagerCs.gameIsStart == false)
        {
            gameManagerCs.startGame = false;
            gameManagerCs.gameIsStart = true;
            SpawnTile();
            StartCoroutine(DelaySound());
            gameManagerCs.totalSpawnTile = GameObject.FindGameObjectsWithTag("TileRed").Length 
                + GameObject.FindGameObjectsWithTag("TileGreen").Length 
                + GameObject.FindGameObjectsWithTag("TileYellow").Length
                + GameObject.FindGameObjectsWithTag("TilePink").Length
                + GameObject.FindGameObjectsWithTag("TilePurple").Length;
            gameManagerCs.totalTile = gameManagerCs.totalSpawnTile;
        }
        
    }
    void SpawnTile()
    {
        for (int i = 0; i < (gameManagerCs.level + 2); i++)
        {
            for (int j = 0; j < 9; j++)
            {
                float randomX = Random.Range(-rangeX, rangeX);
                float randomZ = Random.Range(-rangeZ + 2f, rangeZ);
                randomPos = new Vector3(randomX, transform.position.y, randomZ);
                Instantiate(tilePrefabs[i], randomPos, transform.rotation);
            }
        }
    }
    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(timeDelaySound);
        adSource.PlayOneShot(dominoSound);
    }
}
