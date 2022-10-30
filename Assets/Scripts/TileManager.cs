using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
  public GameObject[] tilePrefabs;
  public float ySpawn = 0f;
  public static float tileLength = 24f;
  public int tileAmount = 6;
  public Transform playerTransform; 
  private List<GameObject> activeTiles = new List<GameObject>();
  
  void Start()
  {
    for(int i = 0; i < tileAmount; i++){
      spawnTile(randomTileIndex());
    }
  }

  void Update()
  {
    if(playerTransform.position.y-tileLength*2>ySpawn-(tileAmount*tileLength)){
      spawnTile(randomTileIndex());
      DeleteTile();
    }
  }

  public void spawnTile(int tileIndex)
  {
    GameObject go = Instantiate(tilePrefabs[tileIndex], new Vector3(0,ySpawn, 0), transform.rotation);
    activeTiles.Add(go);
    ySpawn+=tileLength;
  }

  public int randomTileIndex(){
    return Random.Range(0, tilePrefabs.Length);
  }

  private void DeleteTile(){
    Destroy(activeTiles[0]);
    activeTiles.RemoveAt(0);
  }
}
