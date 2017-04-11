using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] npcPrefabs;
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
            int spawnChoice = Random.Range(0, npcPrefabs.Length);
            for(int i = 0; i < spawnNum; i++)
            {
                GameObject newNPC = Instantiate(npcPrefabs[spawnChoice]);
                newNPC.transform.position = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }
        }
    }
}
