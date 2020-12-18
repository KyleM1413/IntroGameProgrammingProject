using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using TMPro;
namespace Assets.Scripts
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
	public class JumpPowerup : Pickup
    {
        protected override int value()
        {
            return base.value() * 5;
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
              var powerupText = GameObject.Find("PowerupText")?.GetComponent<TextMeshProUGUI>();
               if(powerupText) powerupText.text = "Jump Power Increased!";
                collision.GetComponent<Rigidbody2D>().gravityScale = 1;
                collision.GetComponent<PlayerController>().playerJumpForce *= 3;
                base.OnTriggerEnter2D(collision);
            }
        }
    }
}
