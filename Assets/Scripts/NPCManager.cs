using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
  public GameObject[] carTextures;
  public static List<GameObject> activeNPCs;
  public Transform playerTransform;
  private float npcSpeed = 4.1f;
  private int maxNPCs = 6;
  private int minNPCSpawnY = 25;
  private int maxNPCSpawnY = 80;
  private float minimalNPCDistance = 17f;
  private float minYNPCDistance = 12f;
  private float leftTrack = -3.2f;
  private float middleTrack = 0f;
  private float rightTrack = 3.2f;

  void Start()
  {
    activeNPCs = new List<GameObject>();
    for (int i = 0; i < maxNPCs; i++)
    {
      spawnNPC(randomNPCIndex(), playerTransform);
    }
  }

  void FixedUpdate()
  {
    int n = maxNPCs - activeNPCs.Count;
    for (int i = 0; i < n; i++)
    {
      spawnNPC(randomNPCIndex(), playerTransform);
      Transform t = activeNPCs[i].GetComponent<Transform>();
    }
    for (int i = 0; i < activeNPCs.Count; i++)
    {
      activeNPCs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, activeNPCs[i].GetComponent<NPC>().speed * Time.timeScale);
    }
  }

  public void spawnNPC(int carTextureIndex, Transform t)
  {
    float x = 0, y = 0;
    bool positionFound = false;
    while (!positionFound)
    {
      int xTmp = Random.Range(0, 3);
      if (xTmp == 0)
      {
        x = leftTrack;
      }
      else if (xTmp == 1)
      {
        x = middleTrack;
      }
      else if (xTmp == 2)
      {
        x = rightTrack;
      }
      int yOffset = Random.Range(minNPCSpawnY, maxNPCSpawnY);
      y = t.position.y + yOffset;

      positionFound = true;
      int nearNPCs = 0;
      foreach (GameObject npc in activeNPCs)
      {
        Transform npcT = npc.GetComponent<Transform>();
        bool isYAlreadyInUse = (npcT.position.y - minYNPCDistance < y && y < npcT.position.y + minYNPCDistance);
        if (Vector2.Distance(npcT.position, new Vector2(x, y)) <= minimalNPCDistance)
        {
          nearNPCs++;
        }
        if (nearNPCs >= 2)
        {
          positionFound = false;
          break;
        }
        if (npcT.position.x == x && isYAlreadyInUse)
        {
          positionFound = false;
          break;
        }
      }
    }
    GameObject newNPC = Instantiate(carTextures[carTextureIndex], new Vector3(x, y, 0), Quaternion.identity);
    newNPC.GetComponent<NPC>().speed = npcSpeed;
    newNPC.GetComponent<Rigidbody2D>().velocity = new Vector2(0, newNPC.GetComponent<NPC>().speed);
    activeNPCs.Add(newNPC);
  }

  public int randomNPCIndex()
  {
    return Random.Range(0, carTextures.Length);
  }
}
