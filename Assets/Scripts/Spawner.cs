using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
public class Spawner : MonoBehaviour
{
  private enum spawnType {
    Obstacle,
    PowerUp,
    Enemy
  }

  private spawnType typeToSpawn = spawnType.Obstacle;

  private string[] spawnTypes = Enum.GetNames(typeof(spawnType));
  public List<Obstacle> obstacles = new List<Obstacle>();
  public List<PowerUp> powerUps = new List<PowerUp>();
  public List<Enemy> enemies = new List<Enemy>();

  private int spawnedObjects = 0;
  public int maxSpawnedObstacles;
  public int minSpawnedObstacles;
  private int objectsToSpawn;
  private Vector2 screenBounds;
  public float bottomMargin;
  public float topMargin;

  private ScoreManager scoreManager;

  void Awake()
  {
    screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    transform.position = new Vector2(screenBounds.x * 2, 0f);

    scoreManager = FindObjectOfType<ScoreManager>();

    objectsToSpawn = UnityEngine.Random.Range(minSpawnedObstacles, maxSpawnedObstacles);
  }

  void Start()
  {
    StartCoroutine(objectWave());
  }

  IEnumerator objectWave(){
      while(true){
          yield return new WaitForSeconds(1);
          spawnObject();
      }
  }

  private void spawnObject(){
      spawnedObjects++;

      switch(typeToSpawn){
        case spawnType.Obstacle:
          spawnObstacle();        
          break;
        case spawnType.PowerUp:
          spawnPowerUp();
          break;
        case spawnType.Enemy:
          spawnEnemy();
          break;
      }

      if(spawnedObjects == objectsToSpawn){
        getNewSpawnType();
        spawnedObjects = 0;
      }
  }

  private void spawnObstacle(){
    int obstacleIndex = UnityEngine.Random.Range(0, obstacles.Count);

    Obstacle obstacle = Instantiate(obstacles[obstacleIndex]);

    obstacle.transform.position = new Vector2(screenBounds.x * 2,  getYPosition(obstacle.GetComponent<SpriteRenderer>()));
  }

  private void spawnPowerUp(){
    int powerUpIndex = UnityEngine.Random.Range(0, powerUps.Count);

    PowerUp powerUp = Instantiate(powerUps[powerUpIndex]);

    powerUp.transform.position = new Vector2(screenBounds.x * 2,  getYPosition(powerUp.GetComponent<SpriteRenderer>()));
  }
  private void spawnEnemy(){
    int enemyIndex = UnityEngine.Random.Range(0, enemies.Count);

    Enemy enemy = Instantiate(enemies[enemyIndex]);

    enemy.transform.position = new Vector2(screenBounds.x * 2,  getYPosition(enemy.GetComponent<SpriteRenderer>()));
  }

  private float getYPosition(SpriteRenderer sprite){
    float minY = -screenBounds.y + (sprite.bounds.size[1] / 2) + bottomMargin;
    float maxY = screenBounds.y - (sprite.bounds.size[1] / 2) - topMargin;

    return UnityEngine.Random.Range(minY, maxY);
  }


  private void getNewSpawnType(){
    if(typeToSpawn != spawnType.Obstacle){
      typeToSpawn = spawnType.Obstacle;

      objectsToSpawn = UnityEngine.Random.Range(minSpawnedObstacles, maxSpawnedObstacles);
      return;
    }

    int spawnTypeIndex = UnityEngine.Random.Range(1, spawnTypes.Length);

    // TODO: Refactor This
    if(spawnTypeIndex == 1){
      typeToSpawn = spawnType.PowerUp;
    }
    else{
      Enemy enemy = FindObjectOfType<Enemy>();

      if(enemy != null){
        typeToSpawn = spawnType.PowerUp;
      } else{
        typeToSpawn = spawnType.Enemy;
      }
    }

    objectsToSpawn = 1;
  }
}
