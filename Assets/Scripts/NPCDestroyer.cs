using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroyer : MonoBehaviour
{
    public Transform playerTransform; 
    public Transform NPCDestroyerTransform;
    private float yOffset = 12f;

    void Update()
    {
        NPCDestroyerTransform.position = new Vector3(0, playerTransform.position.y-yOffset, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("NPC")){
            for(int i = 0; i<NPCManager.activeNPCs.Count; i++){
                if(NPCManager.activeNPCs[i].GetInstanceID()==collision.gameObject.GetInstanceID()){
                    Destroy(NPCManager.activeNPCs[i]);
                    NPCManager.activeNPCs.RemoveAt(i);
                    break;
                }
            }
        }
    }

}
