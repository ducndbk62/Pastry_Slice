using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerating : MonoBehaviour
{
    public GameObject[] mapModuleList;
    public GameObject victoryTable;
    public GameObject[] endingStage;

    GameObject[] currentModules;
    // Start is called before the first frame update
    void Start()
    {
        DestroyCurrentModules();
        GenerateRandomMap();
    }

    // Update is called once per frame

    public void DestroyCurrentModules()
    {
        currentModules = GameObject.FindGameObjectsWithTag("MapModule");
        foreach (GameObject module in currentModules)
            Destroy(module);
    }

    public void GenerateRandomMap()
    {
        float x = 0; //toa do x cua cac object duoc tao ra
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, mapModuleList.Length);
            Vector3 locate = new Vector3(x, 0, 0);
            Instantiate(mapModuleList[index], locate, Quaternion.identity);
            x += mapModuleList[index].GetComponent<ModuleLength>().length + 5;
        }

        x += 5;
        Instantiate(victoryTable, new Vector3(x, 6, 0), Quaternion.identity);
        x += 13;

        for (int i = 0; i < 2; i++)
        {
            float randomHigh = Random.Range(20, 30);
            Instantiate(endingStage[i], new Vector3(x, randomHigh, 0), Quaternion.identity);
            x += 11;
        }
    }
}