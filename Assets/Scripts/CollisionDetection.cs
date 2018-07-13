using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public GameObject gameCubes;
    private einviromentHandle einHandle;
    GameObject[] chunk0;
    GameObject[] chunk1;
    GameObject[] chunk2;
    GameObject[] chunk3;
    GameObject[] chunk4;
    GameObject[] chunk5;
    GameObject[] chunk6;
    GameObject[] chunk7;
    GameObject[] chunk8;
    GameObject[] collisionDetectors;
    GameObject collisionDetector0;
    GameObject collisionDetector1;
    GameObject collisionDetector2;
    GameObject collisionDetector3;
    GameObject collisionDetector4;
    GameObject collisionDetector5;
    GameObject collisionDetector6;
    GameObject collisionDetector7;
    GameObject collisionDetector8;

    private void Update()
    {
    }
    private void Start()
    {
        loadChunks();
        
        gameCubes = GameObject.Find("GameCubes");
        einHandle = gameCubes.GetComponent<einviromentHandle>();
        collisionDetectors = new GameObject[9];
        collisionDetector0 = GameObject.FindGameObjectWithTag("Col0");
        collisionDetectors[0] = collisionDetector0;
        collisionDetector1 = GameObject.FindGameObjectWithTag("Col1");
        collisionDetectors[1] = collisionDetector1;
        collisionDetector2 = GameObject.FindGameObjectWithTag("Col2");
        collisionDetectors[2] = collisionDetector2;
        collisionDetector3 = GameObject.FindGameObjectWithTag("Col3");
        collisionDetectors[3] = collisionDetector3;
        collisionDetector4 = GameObject.FindGameObjectWithTag("Col4");
        collisionDetectors[4] = collisionDetector4;
        collisionDetector5 = GameObject.FindGameObjectWithTag("Col5");
        collisionDetectors[5] = collisionDetector5;
        collisionDetector6 = GameObject.FindGameObjectWithTag("Col6");
        collisionDetectors[6] = collisionDetector6;
        collisionDetector7 = GameObject.FindGameObjectWithTag("Col7");
        collisionDetectors[7] = collisionDetector7;
        collisionDetector8 = GameObject.FindGameObjectWithTag("Col8");
        collisionDetectors[8] = collisionDetector8;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerColider") {
            
            switch (transform.tag)
            {
                case "Col8":
                    loadChunks();
                    deleteChunk(chunk4);
                    deleteChunk(chunk5);
                    deleteChunk(chunk3);
                    changeTags(chunk6, "Chunk5", collisionDetector6, "Col5");
                    changeTags(chunk7, "Chunk6", collisionDetector7, "Col6");
                    changeTags(chunk0, "Chunk4", collisionDetector0, "Col4");
                    changeTags(chunk8, "Chunk0", collisionDetector8, "Col0");
                    changeTags(chunk2, "Chunk3", collisionDetector2, "Col3");
                    changeTags(chunk1, "Chunk2", collisionDetector1, "Col2");
                    for (int i = 0; i < collisionDetectors.Length; i++)
                    {
                        Vector3 vec = collisionDetectors[i].transform.position;
                        vec.x -= 20;
                        collisionDetectors[i].transform.position = vec;
                    }
                
                    einHandle.loadNewCube(7, collisionDetector0.transform.position,false);
                    einHandle.loadNewCube(8, collisionDetector0.transform.position,false);
                    einHandle.loadNewCube(1, collisionDetector0.transform.position,false);
                    loadChunks();

                    break;
                case "Col2":

                    loadChunks();
                    deleteChunk(chunk7);
                    deleteChunk(chunk6);
                    deleteChunk(chunk5);
                    changeTags(chunk8, "Chunk7", collisionDetector8, "Col7");
                    changeTags(chunk1, "Chunk8", collisionDetector1, "Col8");
                    changeTags(chunk0, "Chunk6", collisionDetector0, "Col6");
                    changeTags(chunk2, "Chunk0", collisionDetector2, "Col0");
                    changeTags(chunk4, "Chunk5", collisionDetector4, "Col5");
                    changeTags(chunk3, "Chunk4", collisionDetector3, "Col4");
                    for (int i = 0; i < collisionDetectors.Length; i++)
                    {
                        Vector3 vec = collisionDetectors[i].transform.position;
                        vec.z += 20;
                        collisionDetectors[i].transform.position = vec;
                    }
                    einHandle.loadNewCube(1, collisionDetector0.transform.position, false);
                    einHandle.loadNewCube(2, collisionDetector0.transform.position, false);
                    einHandle.loadNewCube(3, collisionDetector0.transform.position, false);

                    loadChunks();

                    break;
                case "Col4":
                    loadChunks();
                    deleteChunk(chunk7);
                     deleteChunk(chunk8);
                     deleteChunk(chunk1);
                     changeTags(chunk2, "Chunk1", collisionDetector2, "Col1");
                     changeTags(chunk3, "Chunk2", collisionDetector3, "Col2");
                     changeTags(chunk0, "Chunk8", collisionDetector0, "Col8");
                     changeTags(chunk4, "Chunk0", collisionDetector4, "Col0");
                     changeTags(chunk6, "Chunk7", collisionDetector6, "Col7");
                     changeTags(chunk5, "Chunk6", collisionDetector5, "Col6");
                     for (int i = 0; i < collisionDetectors.Length; i++)
                     {
                         Vector3 vec = collisionDetectors[i].transform.position;
                         vec.x += 20;
                         collisionDetectors[i].transform.position = vec;
                     }
                     einHandle.loadNewCube(3, collisionDetector0.transform.position, false);
                     einHandle.loadNewCube(4, collisionDetector0.transform.position, false);
                     einHandle.loadNewCube(5, collisionDetector0.transform.position, false);
                    loadChunks();
                    break;
                case "Col6":
                    loadChunks();
                    deleteChunk(chunk1);
                    deleteChunk(chunk2);
                    deleteChunk(chunk3);
                    
                    changeTags(chunk4, "Chunk3", collisionDetector4, "Col3");
                    changeTags(chunk5, "Chunk4", collisionDetector5, "Col4");
                    changeTags(chunk0, "Chunk2", collisionDetector0, "Col2");
                    changeTags(chunk6, "Chunk0", collisionDetector6, "Col0");
                    changeTags(chunk8, "Chunk1", collisionDetector8, "Col1");
                    changeTags(chunk7, "Chunk8", collisionDetector7, "Col8");
                    for (int i = 0; i < collisionDetectors.Length; i++)
                    {
                        Vector3 vec = collisionDetectors[i].transform.position;
                        vec.z -= 20;
                        collisionDetectors[i].transform.position = vec;
                    }
                    einHandle.loadNewCube(5, collisionDetector0.transform.position, false);
                    einHandle.loadNewCube(6, collisionDetector0.transform.position, false);
                    einHandle.loadNewCube(7, collisionDetector0.transform.position, false);
                    loadChunks();
                    break;
            }

        }
    }

    void deleteChunk(GameObject[] chunk)
    {
        loadChunks();
        for(int i = 0; i< chunk.Length; i++)
        {
            GameObject.Destroy(chunk[i]);
        }
        loadChunks();



    }
    void changeTags(GameObject[] chunk, string tag, GameObject detector, string deteTag)
    {
        for (int i = 0; i < chunk.Length; i++)
        {
            chunk[i].tag = tag;
        }

    }
    void loadChunks() {
        chunk0 = GameObject.FindGameObjectsWithTag("Chunk0");
        chunk1 = GameObject.FindGameObjectsWithTag("Chunk1");
        chunk2 = GameObject.FindGameObjectsWithTag("Chunk2");
        chunk3 = GameObject.FindGameObjectsWithTag("Chunk3");
        chunk4 = GameObject.FindGameObjectsWithTag("Chunk4");
        chunk5 = GameObject.FindGameObjectsWithTag("Chunk5");
        chunk6 = GameObject.FindGameObjectsWithTag("Chunk6");
        chunk7 = GameObject.FindGameObjectsWithTag("Chunk7");
        chunk8 = GameObject.FindGameObjectsWithTag("Chunk8");
    }
    void sortChunks()
    {

    }


}
