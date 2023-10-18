using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public bool gameIsStart = false;
    public bool startGame = false;
    public bool gameIsLose = false;
    public GameObject containers;
    public int totalRed;
    public int totalGreen;
    public int totalYellow;
    public int totalPurple;
    public int totalPink;

    public AudioSource adSource;
    public AudioClip getPointSound;
    public AudioClip startGameSound;
    public int totalTile ;
    public int totalSpawnTile;
    [SerializeField] int totolCellIsFull;

    [SerializeField] float userPoint = 0;
    public Text userPointText;
    [SerializeField] int userLevel;
    public Text userLevelText;
    [SerializeField] int timeCounter;
    public Text timeCounterText;
    private float timeCell;
    private float timeMin = 2;
    private float timeSec = 59;

    public GameObject menuGame;
    public GameObject winGamePopup;
    public GameObject loseGamePopup;
    public Text winGameText;
    // Start is called before the first frame update
    void Start()
    {
        startTime();
        level = 1;
        totalRed = 0;
        containers = GameObject.Find("Containers");
        menuGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        totalSpawnTile = GameObject.FindGameObjectsWithTag("TileRed").Length 
            + GameObject.FindGameObjectsWithTag("TileGreen").Length 
            + GameObject.FindGameObjectsWithTag("TileYellow").Length
            + GameObject.FindGameObjectsWithTag("TilePink").Length
            + GameObject.FindGameObjectsWithTag("TilePurple").Length;
        totalRed = 0; //resetCounter
        totalGreen = 0;
        totalYellow = 0;
        totalPurple = 0;
        totalPink = 0;
        for (int i = 0; i < containers.transform.childCount; i++)
        {
            totalRed += containers.transform.GetChild(i).GetComponent<CellPoint>().cellReturnCountRed;
            totalYellow += containers.transform.GetChild(i).GetComponent<CellPoint>().cellReturnCountYellow;
            totalGreen += containers.transform.GetChild(i).GetComponent<CellPoint>().cellReturnCountGreen;
            totalPink += containers.transform.GetChild(i).GetComponent<CellPoint>().cellReturnCountPink;
            totalPurple += containers.transform.GetChild(i).GetComponent<CellPoint>().cellReturnCountPurple;
        }
        checkTileAndGetPoint();
        WinGame();
        LoseGame();
        TimeCounterDown();
        userLevelText.text = level.ToString();
    }
    public void startTime()
    {
        timeMin = 2;
        timeSec = 59;
    }
    public void checkTileAndGetPoint()
    {
        if(totalSpawnTile < totalTile)
        {
            adSource.PlayOneShot(getPointSound);
            totalTile = totalSpawnTile;
            Debug.Log("GetPoint");
            userPoint += 10;
            userPointText.text = userPoint.ToString();
        }
    }
    public void StartGame()
    {
        
        Time.timeScale = 1;
        adSource.PlayOneShot(startGameSound);
        startGame = true;
        menuGame.SetActive(false);
    }
    public void WinGame()
    {
        if (gameIsStart == true && totalSpawnTile == 0)
        {
            Debug.Log("YouWin");
            winGamePopup.SetActive(true);
            winGameText.text = "+" + userPoint.ToString();
            gameIsStart = false;
        }
    }
    public void LoseGame()
    {
        totolCellIsFull = 0;
        for (int i = 0; i < containers.transform.childCount; i++)
        {
            if(containers.transform.GetChild(i).GetComponent<CellPoint>().isFull == true)
            {
                totolCellIsFull += 1;
            }
        }
        if(gameIsStart && totolCellIsFull == 7)
        {
            Debug.Log("YOU LOSE");
            gameIsStart = false;
            loseGamePopup.SetActive(!gameIsStart);
        }
        if (timeMin < 0)
        {
            Debug.Log("YOU LOSE");
            gameIsStart = false;
            loseGamePopup.SetActive(!gameIsStart);
        }
    } 
    public void TimeCounterDown()
    {
        if (gameIsStart)
        {
            timeCell += Time.deltaTime;
            if (timeCell >= 1)
            {
                timeSec -= timeCell;
                timeCell = 0;
            }
            if (timeSec <= 0)
            {
                timeSec = 60;
                timeMin -= 1;
            }
            timeSec = Mathf.RoundToInt(timeSec);
            if (timeSec < 10)
            {
                timeCounterText.text = "0" + timeMin.ToString() + ":0" + timeSec.ToString();
            }
            else
            {
                timeCounterText.text = "0" + timeMin.ToString() + ":" + timeSec.ToString();
            }
        }
        else timeCounterText.text = "00:00";


    }
    public void PauseGame()
    {
        adSource.PlayOneShot(startGameSound);
        Time.timeScale = 0;
        menuGame.SetActive(true);
    }
    public void StopGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void NextLevel()
    {
        startTime();
        level += 1;
        if (level > 3) level = 1;
        StartGame();
        winGamePopup.SetActive(false);
    }
}
