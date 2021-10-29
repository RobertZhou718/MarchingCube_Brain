using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private GameObject gameobject;
    // Start is called before the first frame update
    void Start()
    {
        gameobject = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Space))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
		}

		if (Input.GetKey(KeyCode.X))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
		}

		if (Input.GetKey(KeyCode.W))
		{
			this.gameObject.transform.Translate(new Vector3(0, 0, 80 * Time.deltaTime));
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			this.gameObject.transform.Translate(new Vector3(0, 0, -80 * Time.deltaTime));
		}
		
		if (Input.GetKey(KeyCode.A))
		{
			this.gameObject.transform.Translate(new Vector3(-5, 0, 0 * Time.deltaTime));
		}
		
		if (Input.GetKey(KeyCode.D))
		{
			this.gameObject.transform.Translate(new Vector3(5, 0, 0 * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.Q))
		{
			
			this.gameObject.transform.Rotate(0, -50 * Time.deltaTime, 0, Space.Self);
		}
		if (Input.GetKey(KeyCode.E))
		{
			this.gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0, Space.Self);
		}	

		if (Input.GetKey(KeyCode.Z))
		{
			this.gameObject.transform.Rotate(-30 * Time.deltaTime, 0, 0, Space.Self);
		}
		if (Input.GetKey(KeyCode.C))
		{
			this.gameObject.transform.Rotate(30 * Time.deltaTime, 0, 0, Space.Self);
		}

	}
}
