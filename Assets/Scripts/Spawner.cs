using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public GameObject devil;

    // Start is called before the first frame update
    void Start()
    {
        spawnObject();
    }

    public void spawnObject()
    {
        StartCoroutine(SpawnAfterTime());
    }


    IEnumerator SpawnAfterTime()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            yield return new WaitForSeconds(10);
            float screenX, screenY;
            Vector2 pos;

            screenX = Random.Range(Camera.main.transform.position.x - Screen.width, Camera.main.transform.position.y - Screen.height);
            screenY = Random.Range(Camera.main.transform.position.x - Screen.width, Camera.main.transform.position.y - Screen.height);
            pos = new Vector2(screenX, screenY);
            Instantiate(devil, pos, devil.transform.rotation);
        }

    }

    private void DestroyDevil()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Devil"))
        {
            Destroy(o);
        }
    }
}
