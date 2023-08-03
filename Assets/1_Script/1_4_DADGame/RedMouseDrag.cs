using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RedMouseDrag : MonoBehaviour
{
    public GameObject BallPos;
    public Rigidbody rb;
    

    bool ballBox = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            ballBox = true;
            if (ballBox == true) 
            {
                rb.useGravity = true;
            }

        }
    }

    private void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        objPos.z = 0;

        transform.position = objPos;

        rb.velocity = Vector3.zero;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bag")
        {
            rb.useGravity = false;
            Destroy(this.gameObject);
            Instantiate(this.gameObject, BallPos.transform.position, transform.rotation);

        }
        else if (other.gameObject.tag == "Destroy_Line")
        {
            rb.useGravity = false;
            Destroy(this.gameObject);
            Instantiate(this.gameObject, BallPos.transform.position, transform.rotation);

        }
    }
}
