using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolHandle : MonoBehaviour {
    public Image pickaxe;
    public Image shovel;
    public bool pickaxePicked = true;
    PlayerObjectInteract playScript;
    private Vector3 originSize;
    private Vector3 pickedSize;
    public Blocks currentBlock = Blocks.Grass;
    public bool isDestroyMode = true;
    public Modes currentMode = Modes.Destroy;
    public GameObject pickaxeImage;
    public GameObject shovelImage;
    public GameObject grassImage;
    public GameObject dirtImage;
    public GameObject stoneImage;
    public GameObject darkMatterImage;
    public GameObject grassBlock;
    public GameObject dirtBlock;
    public GameObject stoneBlock;
    public GameObject darkMatterBlock;

    public Image aimer;
    public float rayLength = 5;
    public LayerMask layermask;
    public enum Modes
    {
        Destroy = 1,
        Build = 2
    }
    public enum Blocks
    {
        Grass =1,
        Dirt = 2,
        Stone = 3,
        DarkMatter =4
    }


    // Use this for initialization
    private void Start()
    {
        playScript = GetComponent<PlayerObjectInteract>();
        originSize = new Vector3(1, 1, 1);
        pickedSize = new Vector3(1.2f, 1.2f, 1.2f);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchModes();
        }
        if (currentMode == Modes.Destroy) {
            switchTools();
        }
        else
        {
            
            switchBlocks();
        }

    }
    private void switchBlocks()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBlock = Blocks.Grass;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBlock = Blocks.Dirt;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBlock = Blocks.Stone;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentBlock = Blocks.DarkMatter;
        }
        switch (currentBlock)
        {
            case Blocks.Grass:
                grassImage.transform.localScale = pickedSize;
                dirtImage.transform.localScale = originSize;
                stoneImage.transform.localScale = originSize;
                darkMatterImage.transform.localScale = originSize;
                grassBlock.gameObject.SetActive(true);
                grassBlock.gameObject.GetComponent<Renderer>().enabled = true;
                dirtBlock.gameObject.SetActive(false);
                dirtBlock.gameObject.GetComponent<Renderer>().enabled = false;
                stoneBlock.gameObject.SetActive(false);
                stoneBlock.gameObject.GetComponent<Renderer>().enabled = false;
                darkMatterBlock.gameObject.SetActive(false);
                darkMatterBlock.gameObject.GetComponent<Renderer>().enabled = false;
                break;
            case Blocks.Dirt:
                grassImage.transform.localScale = originSize;
                dirtImage.transform.localScale = pickedSize;
                stoneImage.transform.localScale = originSize;
                darkMatterImage.transform.localScale = originSize;
                grassBlock.gameObject.SetActive(false);
                grassBlock.gameObject.GetComponent<Renderer>().enabled = false;
                dirtBlock.gameObject.SetActive(true);
                dirtBlock.gameObject.GetComponent<Renderer>().enabled = true;
                stoneBlock.gameObject.SetActive(false);
                stoneBlock.gameObject.GetComponent<Renderer>().enabled = false;
                darkMatterBlock.gameObject.SetActive(false);
                darkMatterBlock.gameObject.GetComponent<Renderer>().enabled = false;
                break;
            case Blocks.Stone:
                grassImage.transform.localScale = originSize;
                dirtImage.transform.localScale = originSize;
                stoneImage.transform.localScale = pickedSize;
                darkMatterImage.transform.localScale = originSize;
                grassBlock.gameObject.SetActive(false);
                grassBlock.gameObject.GetComponent<Renderer>().enabled = false;
                dirtBlock.gameObject.SetActive(false);
                dirtBlock.gameObject.GetComponent<Renderer>().enabled = false;
                stoneBlock.gameObject.SetActive(true);
                stoneBlock.gameObject.GetComponent<Renderer>().enabled = true;
                darkMatterBlock.gameObject.SetActive(false);
                darkMatterBlock.gameObject.GetComponent<Renderer>().enabled = false;
                break;
            case Blocks.DarkMatter:
                grassImage.transform.localScale = originSize;
                dirtImage.transform.localScale = originSize;
                stoneImage.transform.localScale = originSize;
                darkMatterImage.transform.localScale = pickedSize;
                grassBlock.gameObject.SetActive(false);
                grassBlock.gameObject.GetComponent<Renderer>().enabled = false;
                dirtBlock.gameObject.SetActive(false);
                dirtBlock.gameObject.GetComponent<Renderer>().enabled = false;
                stoneBlock.gameObject.SetActive(false);
                stoneBlock.gameObject.GetComponent<Renderer>().enabled = false;
                darkMatterBlock.gameObject.SetActive(true);
                darkMatterBlock.gameObject.GetComponent<Renderer>().enabled = true;
                break;
        }
    }
    private void switchTools()
    {
        grassBlock.gameObject.GetComponent<Renderer>().enabled = false;
        dirtBlock.gameObject.GetComponent<Renderer>().enabled = false;
        stoneBlock.gameObject.GetComponent<Renderer>().enabled = false;
        darkMatterBlock.gameObject.SetActive(false);
        darkMatterBlock.gameObject.GetComponent<Renderer>().enabled = false;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pickaxePicked = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pickaxePicked = false;

        }
        playScript.checkTools();
        if (pickaxePicked)
        {
            pickaxe.transform.localScale = pickedSize;
            shovel.transform.localScale = originSize;
        }
        else
        {
            pickaxe.transform.localScale = originSize;
            shovel.transform.localScale = pickedSize;
        }
    }

    void SwitchModes()
    {
        if (currentMode == Modes.Destroy)
        {
            currentMode = Modes.Build;
            isDestroyMode = false;
            pickaxeImage.SetActive(false);
            shovelImage.SetActive(false);
            grassImage.SetActive(true);
            dirtImage.SetActive(true);
            stoneImage.SetActive(true);
            darkMatterImage.SetActive(true);
            playScript.checkTools();
        }
        else
        {
            currentMode = Modes.Destroy;
            isDestroyMode = true;
            pickaxeImage.SetActive(true);
            shovelImage.SetActive(true);
            grassImage.SetActive(false);
            dirtImage.SetActive(false);
            stoneImage.SetActive(false);
            darkMatterImage.SetActive(false);
            playScript.checkTools();
        }
    }

}
