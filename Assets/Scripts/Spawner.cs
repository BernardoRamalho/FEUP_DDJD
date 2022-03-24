using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Spawner : MonoBehaviour
{
    private Vector2 screenBounds;

    [Serializable]
    public class ObjectToSpawn
    {
        public GameObject gameObject;
        public float respawnRatio;
    }

    public List<ObjectToSpawn> objectsToSpawn = new List<ObjectToSpawn>();
    private List<GameObject> startingOrder = new List<GameObject>();
    private List<GameObject> objectsOrder = new List<GameObject>();

    public float bottomMargin;
    public float topMargin;

    void Awake()
    {
      screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
      transform.position = new Vector2(screenBounds.x * 2, 0f);

      foreach(ObjectToSpawn objectToSpawn in objectsToSpawn) {
        for(int i = 0; i < objectToSpawn.respawnRatio; i++) {
          startingOrder.Add(objectToSpawn.gameObject);
        }
      }

      restartSpawningList();
    }

    void Start()
    {
      StartCoroutine(objectWave());
    }

    private void spawnObject(){
        GameObject obj = Instantiate(getElementFromSpawningList()) as GameObject;
        float minY = -screenBounds.y + (obj.GetComponent<SpriteRenderer>().bounds.size[1] / 2) + bottomMargin;
        float maxY = screenBounds.y - (obj.GetComponent<SpriteRenderer>().bounds.size[1] / 2) - topMargin;
        obj.transform.position = new Vector2(screenBounds.x * 2,  UnityEngine.Random.Range(minY, maxY));
    }

    IEnumerator objectWave(){
        while(true){
            yield return new WaitForSeconds(1);
            spawnObject();
        }
    }

    private void restartSpawningList() {
      objectsOrder = new List<GameObject>(startingOrder);
    }

    private GameObject getElementFromSpawningList() {
      GameObject gObject;

      if (objectsOrder.Count == 0) {
        restartSpawningList();
      }
      gObject = objectsOrder[0];

      objectsOrder.RemoveAt(0);

      return gObject;
    }
}
