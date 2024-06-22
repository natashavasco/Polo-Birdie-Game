using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POLO
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private GameObject m_Player;
		[SerializeField] private float m_SpeedMultiplier = 0.1f;
		[SerializeField] private Camera m_Camera;
		
		private void MovePlayerPosition(Vector3 movementToAdd)
		{
			m_Player.gameObject.transform.position += movementToAdd;
		}

		private void Update()
		{
			LookAtMouse();
		}

		private void MoveWithWASD()
		{
			if (Input.GetKey(KeyCode.W))
			{
				MovePlayerPosition(transform.forward * m_SpeedMultiplier);
			}
			else if (Input.GetKey(KeyCode.A))
			{
				MovePlayerPosition(-transform.right * m_SpeedMultiplier);
			}
			else if (Input.GetKey(KeyCode.S))
			{
				MovePlayerPosition(-transform.forward * m_SpeedMultiplier);
			}
			else if (Input.GetKey(KeyCode.D))
			{
				MovePlayerPosition(transform.right * m_SpeedMultiplier);
			}
		}

		private void LookAtMouse()
		{
			Vector3 point = m_Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
			float t = m_Camera.transform.position.y / (m_Camera.transform.position.y - point.y);
			Vector3 finalPoint = new Vector3(t * (point.x - m_Camera.transform.position.x) + m_Camera.transform.position.x,
					t * (point.z - m_Camera.transform.position.z) + m_Camera.transform.position.z);
			transform.LookAt(finalPoint, Vector3.up);

		}
	}
}

