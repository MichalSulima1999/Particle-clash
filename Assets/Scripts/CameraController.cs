using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;

	public float targetOffset = -2f;
	private float offset;
	public float moveSpeed = 5f;
	private Vector3 targetPos;

	// Update is called once per frame
	void Update()
	{
		targetPos = new Vector3(player.transform.position.x - targetOffset, player.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
