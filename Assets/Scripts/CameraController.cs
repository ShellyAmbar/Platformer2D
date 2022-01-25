using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


   [SerializeField] private Transform player;
    [SerializeField] private float additionY;
     private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + additionY , transform.position.z);
    }
 
}
