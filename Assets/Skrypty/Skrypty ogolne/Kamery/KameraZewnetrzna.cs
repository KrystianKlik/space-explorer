using UnityEngine;
using System.Collections;

public class KameraZewnetrzna : MonoBehaviour
{
    public Transform player;

     void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(180f, 0f, 0f);
    }



}
