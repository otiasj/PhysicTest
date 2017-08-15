using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    public float speed = 5f;
    private Vector2 offset = new Vector2(0f, 0f);

    public Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        float offset = Time.time * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    void OnCollisionStay(Collision collided)
    {
//        Debug.Log(GetComponent<Collider>().name + "<->" + collided.rigidbody.name);
        Debug.DrawRay(collided.transform.position, transform.right * speed, Color.white);
        //collided.rigidbody.MovePosition(collided.transform.position + transform.right * Time.deltaTime * speed);
        collided.rigidbody.AddForce(transform.right * speed, ForceMode.Impulse);
            //AddForce(collided.transform.position + transform.right * Time.deltaTime * speed);
    }

}
