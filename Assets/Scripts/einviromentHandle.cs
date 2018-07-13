using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class einviromentHandle : MonoBehaviour {
    public GameObject Dirt;
    public GameObject DarkMatter;
    public GameObject Grass;
    public GameObject Stone;
    public GameObject loadDetector;
    private Vector3 spawnPos;
    private Vector3 defaultPos;
    private Vector3 loadDefaultPos;
    private GameObject currentObject;
    public int loadAreaSize;
    public float terDetail;
    public float terHeigt;
    int seed;

    public GameObject player;


    [HideInInspector]
    public GameObject[] blocks;

    public float depth;
    void Start () {
        seed = Random.Range(0, 9000);
        player = GameObject.FindGameObjectWithTag("Player");
        loadAreaSize = 20;
        defaultPos = new Vector3(0,0, 0);
        loadDefaultPos = defaultPos;
        loadDefaultPos.x += loadAreaSize / 2;
        loadDefaultPos.z += (loadAreaSize / 2) -0.5f ;
        depth = Random.value*5;
        loadDetector.transform.localScale = new Vector3(loadAreaSize, 3*loadAreaSize, loadAreaSize);
        loadAll();
    }
    private void Update()
    {
       
    }

    public void loadTerrain(Vector3 spawnPos, string chunk)
    {
        defaultPos = spawnPos;
        defaultPos.x -= loadAreaSize / 2 - 0.5f;
        defaultPos.z -= loadAreaSize / 2 - 0.5f;
        //DestroyAllObjects();
        for (int z = 0; z < loadAreaSize; z++)
        {
            spawnPos = new Vector3(spawnPos.x, spawnPos.y, defaultPos.z + z);
            for (int x = 0; x < loadAreaSize; x++)
            {
                spawnPos = new Vector3(defaultPos.x + x, spawnPos.y, spawnPos.z);
                int Perlin1 = (int)(Mathf.PerlinNoise((spawnPos.z/2 + seed) / terDetail , (spawnPos.x/2 + seed) / terDetail) *terHeigt);
                spawnPos = new Vector3(spawnPos.x, Perlin1, spawnPos.z);
                Grass.tag = chunk;
                Instantiate(Grass, spawnPos, transform.rotation, this.transform);
                for(int i = 0; i<4; i++)
                {
                    if (i == 0)
                    {
                        Debug.Log("nacitam hlinu");
                        Vector3 tmp = spawnPos;
                        tmp.y -= i + 1;
                        Dirt.tag = chunk;
                        Instantiate(Dirt, tmp, transform.rotation, this.transform);
                    }

                    else if (i == 1)
                    {
                        Vector3 tmp = spawnPos;
                        tmp.y -= i + 1;
                        Stone.tag = chunk;
                        Instantiate(Stone, tmp, transform.rotation, this.transform);
                    }
                    else
                    {
                        Vector3 tmp = spawnPos;
                        tmp.y -= i + 1;
                        DarkMatter.tag = chunk;
                        Instantiate(DarkMatter, tmp, transform.rotation, this.transform);
                    }
                }
            }
        }

    }

    public void loadNewCube(int index, Vector3 loadDefaultPos, bool first)
    {
        Debug.Log("Loaduju novou cubu " + index);
        switch (index)
        {
            case 0:
                loadDetector.tag = "Col0";
                if (first == true) {
                    Instantiate(loadDetector, loadDefaultPos, transform.rotation, this.transform);
                }
                loadTerrain(loadDefaultPos, "Chunk0");
                break;
            case 1:
                loadDetector.tag = "Col1";
                Vector3 pos1 = loadDefaultPos;
                pos1.x -= loadAreaSize;
                pos1.z += loadAreaSize;
                if(first == true) { 
                Instantiate(loadDetector, pos1, transform.rotation, this.transform);
                }
                loadTerrain(pos1,"Chunk1");
                break;
            case 2:
                
                Vector3 pos2 = loadDefaultPos;
                pos2.z += loadAreaSize;
                
                
                loadDetector.tag = "Col2";
                loadTerrain(pos2,"Chunk2");
                if (first == true)
                {
                    Instantiate(loadDetector, pos2, transform.rotation, this.transform);
                }
                break;
            case 3:
                loadDetector.tag = "Col3";
                Vector3 pos3 = loadDefaultPos;
                pos3.x += loadAreaSize;
                pos3.z += loadAreaSize;
                if (first == true)
                {
                    Instantiate(loadDetector, pos3, transform.rotation, this.transform);
                }
                loadTerrain(pos3,"Chunk3");
                break;
            case 4:
                loadDetector.tag = "Col4";
                Vector3 pos4 = loadDefaultPos;
                pos4.x += loadAreaSize;
                if (first == true)
                {
                    Instantiate(loadDetector, pos4, transform.rotation, this.transform);
                }
                loadTerrain(pos4, "Chunk4");
                break;
            case 5:
                loadDetector.tag = "Col5";
                Vector3 pos5 = loadDefaultPos;
                pos5.x += loadAreaSize;
                pos5.z -= loadAreaSize;
                if (first == true)
                {
                    Instantiate(loadDetector, pos5, transform.rotation, this.transform);
                }
                loadTerrain(pos5, "Chunk5");
                break;
            case 6:
                loadDetector.tag = "Col6";
                Vector3 pos6 = loadDefaultPos;
                pos6.z -= loadAreaSize;
                if (first == true)
                {
                    Instantiate(loadDetector, pos6, transform.rotation, this.transform);
                }
                loadTerrain(pos6, "Chunk6");
                break;
            case 7:
                loadDetector.tag = "Col7";
                Vector3 pos7 = loadDefaultPos;
                pos7.x -= loadAreaSize;
                pos7.z -= loadAreaSize;
                if (first == true)
                {
                    Instantiate(loadDetector, pos7, transform.rotation, this.transform);
                }
                loadTerrain(pos7, "Chunk7");
                break;
            case 8:
                loadDetector.tag = "Col8";
                Vector3 pos8 = loadDefaultPos;
                pos8.x -= loadAreaSize;
                if (first == true)
                {
                    Instantiate(loadDetector, pos8, transform.rotation, this.transform);
                }
                loadTerrain(pos8, "Chunk8");
                break;


        }
    }
    public void loadAll()
    {
        for(int i = 0; i <9; i++)
        {

            loadNewCube(i, loadDefaultPos, true);
            if (i == 0)
            {
                blocks = GameObject.FindGameObjectsWithTag("Chunk0");
                int which = 0;
                while (blocks[which ].gameObject.layer != 9) {
                which = Random.Range(0, blocks.Length);
                }
                player.transform.position = blocks[which].gameObject.transform.position;
                Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
                player.transform.position = newPos;
            }
        }
    }
    public void createUp(Vector3 zeroVec)
    {

    }

}
