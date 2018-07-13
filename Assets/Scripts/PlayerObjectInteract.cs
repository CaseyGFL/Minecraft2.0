using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerObjectInteract : MonoBehaviour {
    public float rayLength = 5;
    public LayerMask layermask;
    public LayerMask layermaskBuild;
    public Image aimer;
    RaycastHit hit;

    public GameObject pickaxe;
    public GameObject shovel;
    private GameObject currentTool;
    public GameObject buildGrassBlock;
    public GameObject buildDirtBlock;
    public GameObject buildStoneBlock;
    public GameObject buildDarkMatterBlock;
    private GameObject currentBuildBlock;
    public GameObject grassBlock;
    public GameObject dirtBlock;
    public GameObject stoneBlock;
    public GameObject darkMatterBlock;
    Vector3 currentBuildBlockPos = Vector3.zero;
    private int currentHard = 0;
    private bool isDestroying = false;
    public bool tool = true;
    public ToolHandle toolhandle;
    bool timerRun = true;
    bool goingUp = false;
    int power = 0;
    int id;
    int i = 1;


    private void Start()
    {
        toolhandle = GetComponent<ToolHandle>();
        tool = toolhandle.pickaxePicked;
        Quaternion quat = new Quaternion(0, 0, 0, 0);
        currentBuildBlock = buildGrassBlock;
        checkTools();
    }

    void Update () {
        checkCurrentBlock();
        if (toolhandle.isDestroyMode && currentTool.gameObject.active==false)
        {
            currentTool.gameObject.SetActive(true);
            currentTool.gameObject.GetComponent<Renderer>().enabled = true;
        }
        if (toolhandle.isDestroyMode)
        {
            checkTools();
            tool = toolhandle.pickaxePicked;
            checkTools();


            if (Input.GetKey(KeyCode.Mouse0))
            {
                ToolAnimation();
                Ray ray = Camera.main.ScreenPointToRay(aimer.transform.position);
                if (Physics.Raycast(ray, out hit, rayLength, layermask))
                {
                    SetCurrentHard(hit.collider.gameObject.layer);


                    tool = toolhandle.pickaxePicked;
                    if (timerRun)
                    {
                        id = hit.collider.gameObject.GetInstanceID();
                        if (timerRun)
                        {
                            timerRun = false;
                            Invoke("destroyObject", currentHard);
                        }
                    }

                }
            }
            checkTools();
        }
        else
        {
            ShootRayForBlock();
            OnClickCreateBlock();

        }
    }
    void destroyObject()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
                    if (tool == toolhandle.pickaxePicked) {
                    hit.collider.gameObject.SetActive(false);
                    hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
                    GameObject.Destroy(hit.collider.gameObject);
            }

        }
        timerRun = true;
    }

    bool isBetween(float value, float min, float max)
    {
        bool ahoj = false;
        if((value > min) && (value < max))
        {
            
            ahoj =  true;
        }
        else { ahoj =  false; }
        return ahoj;
    }

    public void checkTools()
    {
        if (toolhandle.isDestroyMode) {
            if (tool)
            {
            
                currentTool = pickaxe;
                pickaxe.gameObject.SetActive(true);
                shovel.gameObject.SetActive(false);
                pickaxe.gameObject.GetComponent<Renderer>().enabled = true;
                shovel.gameObject.GetComponent<Renderer>().enabled = false;
            
            
            }
            else
            {
                currentTool = shovel;
                pickaxe.gameObject.SetActive(false);
                shovel.gameObject.SetActive(true);
                pickaxe.gameObject.GetComponent<Renderer>().enabled = false;
                shovel.gameObject.GetComponent<Renderer>().enabled = true;

            
            
            }
        }
        else
        {
            shovel.gameObject.SetActive(false);
            shovel.gameObject.GetComponent<Renderer>().enabled = true;
            pickaxe.gameObject.SetActive(false);
            pickaxe.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
    
    void setPositionByLayer(GameObject collider, int layer)
    {
        currentBuildBlockPos = collider.transform.position;
        switch (layer)
        {
            case 13:
                
                
                break;
            case 14:

                currentBuildBlockPos.y -= 1;
                break;

            case 15:
                currentBuildBlockPos.x -= 0.5f;

                currentBuildBlockPos.y -= 0.5f;
                break;
            case 16:
                currentBuildBlockPos.x += 0.5f;

                currentBuildBlockPos.y -= 0.5f;
                break;
            case 17:

                currentBuildBlockPos.z += 0.5f;

                currentBuildBlockPos.y -= 0.5f;
                break;
            case 18:
                currentBuildBlockPos.z -= 0.5f;

                currentBuildBlockPos.y -= 0.5f;
                break;

        }

        currentBuildBlock.transform.position = currentBuildBlockPos;
    }

    void checkCurrentBlock()
    {
        buildGrassBlock.gameObject.SetActive(false);
        buildDirtBlock.gameObject.SetActive(false);
        buildStoneBlock.gameObject.SetActive(false);
        buildDarkMatterBlock.gameObject.SetActive(false);
        switch (toolhandle.currentBlock)
        {
            case ToolHandle.Blocks.Grass:
                currentBuildBlock = buildGrassBlock;
                break;
            case ToolHandle.Blocks.Dirt:
                currentBuildBlock = buildDirtBlock;
                break;
            case ToolHandle.Blocks.Stone:
                currentBuildBlock = buildStoneBlock;
                break;
            case ToolHandle.Blocks.DarkMatter:
                currentBuildBlock = buildDarkMatterBlock;
                break;
        }
    }

    private void ToolAnimation()
    {
        currentTool.transform.Rotate(0, 0, -i);
        if (isBetween(currentTool.gameObject.transform.rotation.eulerAngles.z, 25, 360))
        {
            if (isBetween(currentTool.gameObject.transform.rotation.eulerAngles.z, 25, 200))
            {
                i = 5;
            }
            else
            {
                i = -5;
            }

        }
    }

    private void SetCurrentHard(int layer)
    {
        switch (layer)
        {

            case 9:
                if (toolhandle.pickaxePicked)
                {
                    currentHard = 2;
                }
                else
                {
                    currentHard = 1;
                }
                break;
            case 10:
                if (toolhandle.pickaxePicked)
                {
                    currentHard = 3;
                }
                else
                {
                    currentHard = 2;
                }
                break;
            case 11:
                if (toolhandle.pickaxePicked)
                {
                    currentHard = 2;
                }
                else
                {
                    currentHard = 5;
                }
                break;
            case 12:
                if (toolhandle.pickaxePicked)
                {
                    currentHard = 10;
                }
                else
                {
                    currentHard = 100;
                }
                break;
        }
    }
    void OnClickCreateBlock()
    {
        if (Input.GetMouseButtonDown(1))
        {
            grassBlock.transform.tag = currentBuildBlock.tag;
            dirtBlock.transform.tag = currentBuildBlock.tag;
            stoneBlock.transform.tag = currentBuildBlock.tag;
            darkMatterBlock.transform.tag = currentBuildBlock.tag;
            switch (toolhandle.currentBlock)
            {
                case ToolHandle.Blocks.Grass:
                    grassBlock.transform.position = currentBuildBlock.transform.position;
                    Instantiate(grassBlock);
                    break;
                case ToolHandle.Blocks.Dirt:
                    dirtBlock.transform.position = currentBuildBlock.transform.position;
                    Instantiate(dirtBlock);
                    break;
                case ToolHandle.Blocks.Stone:
                    stoneBlock.transform.position = currentBuildBlock.transform.position;
                    Instantiate(stoneBlock);
                    break;
                case ToolHandle.Blocks.DarkMatter:
                    darkMatterBlock.transform.position = currentBuildBlock.transform.position;
                    Instantiate(darkMatterBlock);
                    break;
            }
        }
    }
    private void ShootRayForBlock()
    {
        Ray ray = Camera.main.ScreenPointToRay(aimer.transform.position);
        if (Physics.Raycast(ray, out hit, rayLength, layermaskBuild))
        {
            setPositionByLayer(hit.collider.gameObject, hit.collider.gameObject.layer);
            currentBuildBlock.tag = hit.collider.transform.parent.transform.parent.tag;
            currentBuildBlock.gameObject.SetActive(true);
        }
        else
        {
            currentBuildBlock.gameObject.SetActive(false);

        }
    }
}
