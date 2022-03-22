using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployGameObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(objectWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnObject(){
        GameObject obj = Instantiate(objectToSpawn) as GameObject;
        obj.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + 1.8f, screenBounds.y - (obj.GetComponent<SpriteRenderer>().bounds.size[1] / 2)));
    }
 
    IEnumerator objectWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnObject();
        }
        
    }
}
