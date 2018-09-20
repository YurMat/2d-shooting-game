using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed = 10;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}
}
