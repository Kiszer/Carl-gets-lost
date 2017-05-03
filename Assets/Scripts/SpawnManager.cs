using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] npcPrefabs;
    public bool difficultyTimer = true;
    public static int difficulty;
    public int spawnMin;
    public int spawnMax;
    private float playTime = 0;
    private Color[] colors = { Color.green, Color.red, Color.blue, Color.yellow };

	void Start () {
        StartCoroutine(Spawn());
	}

    void FixedUpdate()
    {
        playTime += Time.fixedDeltaTime;
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            int spawnNum = Random.Range(spawnMin, spawnMax + difficulty*(int)(playTime/15));
            int spawnChoice = Random.Range(0, 100) >= 20 ? 0 : Random.Range(0,npcPrefabs.Length);
            float spawnX = Random.Range(0f, 1f) > 0.5f ? -1 : 1;
            Color randColor = colors[Random.Range(0, difficulty)];
            for (int i = 0; i < spawnNum; i++)
            {
                GameObject newNPC = Instantiate(npcPrefabs[spawnChoice]);
                NPCController npcScript = newNPC.GetComponent<NPCController>();
                npcScript.SetColor(randColor);
                npcScript.Destination = new Vector2(12 * (spawnX), Random.Range(-6f, 6f));
                newNPC.transform.position = new Vector2(-npcScript.Destination.x, Random.Range(-6, 6f));
            }
        }
    }
}
