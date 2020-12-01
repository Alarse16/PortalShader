using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	private CharacterController characterController;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float playerSpeed = 2.0f, jumpHeight = 1.0f, gravityValue = -9.81f, Sensitivity = 1000;
	[SerializeField] private new Camera camera = null;

	private void Awake() {
		characterController = gameObject.GetComponent<CharacterController>();
		Cursor.visible = false;
	}

	void Update() {
		groundedPlayer = characterController.isGrounded;
		if(groundedPlayer && playerVelocity.y < 0) {
			playerVelocity.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		move = transform.TransformDirection(move);
		characterController.Move(move * Time.deltaTime * playerSpeed);

		transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime, Space.World);
		camera?.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime);

		// Changes the height position of the player..
		if(Input.GetButtonDown("Jump") && groundedPlayer) {
			playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}

		playerVelocity.y += gravityValue * Time.deltaTime;
		characterController.Move(playerVelocity * Time.deltaTime);
	}
}
