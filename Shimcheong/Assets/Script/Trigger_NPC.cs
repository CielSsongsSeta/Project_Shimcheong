using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_NPC : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D npc_collider)
	{
		Debug.Log("Touch!");
	}
}
