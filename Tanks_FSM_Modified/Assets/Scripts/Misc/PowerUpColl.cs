using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpColl : MonoBehaviour
{
    private int numOfBlinks = 10;
    private bool coroutineStarted;

    private PlayerTankController playerScript;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//only the player can get the powerup
        {
             playerScript = other.gameObject.GetComponent<PlayerTankController>();

            if (!coroutineStarted)
            StartCoroutine(GetPowerUp(playerScript));          
        }
    }

    private IEnumerator GetPowerUp(PlayerTankController playerScript)
    {
        coroutineStarted = true;        
        playerScript.glow.enabled = true;//we glowwwww
        playerScript.isPoweredUp = true;//WE OFFICIALLY POWERED UP

        yield return new WaitForSeconds(5);//powerup lasts for 5 seconds and then blinks for 3??

        for (int i = 0; i < numOfBlinks; i++)
        {
            playerScript.glow.enabled = false;
            yield return new WaitForSeconds(.2f);
            playerScript.glow.enabled = true;
            yield return new WaitForSeconds(.2f);
        }

        playerScript.glow.enabled = false;//we not glow anymoreeeeee
        coroutineStarted = false;
        playerScript.isPoweredUp = false;//We not powered up anymore
    }
}
