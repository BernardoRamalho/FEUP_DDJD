using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemies : MonoBehaviour
{
    public GameObject enemy;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy(){
        GameObject enem = Instantiate(enemy) as GameObject;
        Debug.Log(enem.GetComponent<SpriteRenderer>().bounds.size);
        enem.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + 1.8f, screenBounds.y - (enem.GetComponent<SpriteRenderer>().bounds.size[1] / 2)));
    }
 
    IEnumerator enemyWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
        
    }
}
