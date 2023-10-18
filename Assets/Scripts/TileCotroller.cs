using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCotroller : MonoBehaviour
{
    public Renderer rend;
    public Color hoverColor;
    private Color startColor;
    public bool isSelected = false;
    public GameObject containers;
    public GameManager gameManager;
    public Rigidbody tileRb;
    public AudioSource adSource;
    public AudioClip clickTileSound;
    public AudioClip getPointSound;
    public GameObject gameManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        containers = GameObject.Find("Containers");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        tileRb = GetComponent<Rigidbody>();
        adSource = GetComponent<AudioSource>();
        
        gameManagerObject = GameObject.Find("GameManager");
        transform.parent = gameManagerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.totalRed == 3 && isSelected == true && gameObject.CompareTag("TileRed"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.totalGreen == 3 && isSelected == true && gameObject.CompareTag("TileGreen"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.totalYellow == 3 && isSelected == true && gameObject.CompareTag("TileYellow"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.totalPink == 3 && isSelected == true && gameObject.CompareTag("TilePink"))
        {
            DestroyCommandFromGameManager();
        }
        if (gameManager.totalPurple == 3 && isSelected == true && gameObject.CompareTag("TilePurple"))
        {
            DestroyCommandFromGameManager();
        }
    }
    private void OnMouseEnter()
    {
        if (isSelected == false)
        {
            //rend.material.color = hoverColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if(gameManager.gameIsStart == true)
        {
            for (int i = 0; i < containers.transform.childCount; i++)
            {
                if (containers.transform.GetChild(i).GetComponent<CellPoint>().isFull == false && isSelected == false)
                {
                    adSource.PlayOneShot(clickTileSound);
                    isSelected = true;
                    transform.position = containers.transform.GetChild(i).transform.position;
                    transform.parent = containers.transform.GetChild(i).transform; //move into parent
                    transform.rotation = Quaternion.identity;
                    containers.transform.GetChild(i).GetComponent<CellPoint>().isFull = true;
                    break;
                }
            }
        }
    }
    public void DestroyCommandFromGameManager()
    {
        gameObject.GetComponentInParent<CellPoint>().isFull = false;
        Destroy(gameObject,0.3f);
    }

}
