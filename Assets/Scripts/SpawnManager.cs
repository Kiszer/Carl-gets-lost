using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject npcPrefab;
    public float difficulty;
    public int spawnMin;
    public int spawnMax;

	void Start () {
        StartCoroutine(Spawn());
	}

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            int spawnNum = Random.Range(spawnMin, spawnMax);
            for(int i = 0; i < spawnNum; i++)
            {
                GameObject newNPC = Instantiate(npcPrefab);
                newNPC.transform.position = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }
        }
    }
}
