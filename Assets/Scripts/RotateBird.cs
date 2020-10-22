using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour {

    public float MaxDownVelocity = -5f;
    public float MaxDownAngle = -90f;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        if (rb2d != null)
        {
            float currentVelocity = Mathf.Clamp(rb2d.velocity.y, MaxDownVelocity, 0);
            float angle = (currentVelocity / MaxDownVelocity) * MaxDownAngle;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
        }	
	}
}
