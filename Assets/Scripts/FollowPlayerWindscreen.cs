using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerWindscreen : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2, 0);

    // Update is called once per frame
    void LateUpdate()
    {
        //offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;
    }
}
