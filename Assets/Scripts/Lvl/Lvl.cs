using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl : MonoBehaviour
{
    public NewLvL newLvl;
    [SerializeField] private List<GameObject> pullBuff = new List<GameObject>();
    public void Start()
    {
        SpawnBuffLvL();
    }

    private void SpawnBuffLvL()
    {
        Debug.Log(1);
        var temp = Instantiate(pullBuff[Random.Range(0, pullBuff.Count)], transform.position-Vector3.forward, Quaternion.identity);
        temp.transform.SetParent(transform);
    }
}
