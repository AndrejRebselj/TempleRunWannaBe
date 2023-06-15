using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject spawningGameObject;
    [SerializeField]
    GameObject badSpawningObject;
    List<GameObject> spawningList = new List<GameObject>();
    void Start()
    {
        spawningList.Add(gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject);
        spawningList.Add(gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject);
        spawningList.Add(gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject);

        List<int> potentialBasSpawners = new List<int>() {0,1,2};
        int randomRange = Random.Range(0, 3);
        potentialBasSpawners.Remove(randomRange);
        int badRandomRange=Random.Range(0, 2);
        Instantiate(badSpawningObject, spawningList[potentialBasSpawners[badRandomRange]].transform);
        Instantiate(spawningGameObject, spawningList[randomRange].transform);
    }
}
