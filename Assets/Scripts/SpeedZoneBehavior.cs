using UnityEngine;
using System.Collections;

/**
 * this class increases the speed everytime the player passes a set of 100 blocks 
 * @Author: Jonathan Fils-Aime 
 */
public class SpeedZoneBehavior : MonoBehaviour 
{
    public void OnTriggerExit() 
	{
        PlayerControl pc = GameObject.FindObjectOfType(typeof(PlayerControl)) as PlayerControl;
        pc.speed += 2;
    }
}
