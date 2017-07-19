using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	Rigidbody rb;

	[SerializeField]float power = 10;
	void Awake(){
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		rb.useGravity = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jump (Vector3 clickPoint)
	{
		if (rb.velocity.y > 0) {
			return;
		}
		rb.useGravity = true; 
		Vector3 clickPoint2D = PointTo2D (clickPoint);
		Vector3 ballPoint2D = PointTo2D (transform.position);

		Vector3 direction = (ballPoint2D - clickPoint2D).normalized;
		if (direction.y < 0) {

			direction = direction + new Vector3(0,1,0)*(-2)*direction.y;
		}
		direction = direction.normalized;
		Debug.Log(direction);
		rb.velocity = direction*power;
		ScoreManager.Instance.AddScore();
	}

	Vector3 PointTo2D(Vector3 input){
		return Vector3.Scale(input,new Vector3(1,1,0));
	}
}
