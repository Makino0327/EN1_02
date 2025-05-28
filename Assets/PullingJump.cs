using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float jumpPower = 10;
    private Vector3 clickPosition;
    private bool isCanJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPosition=Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            if (dist.sqrMagnitude == 0)
            {
                return;
            }
            rb.linearVelocity=dist.normalized * jumpPower;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contacts=collision.contacts;
        Vector3 otherNormal = contacts[0].normal;
        Vector3 upVector= new Vector3(0, 1, 0);
        float dotUN = Vector3.Dot(upVector, otherNormal);
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        if (dotDeg<=45)
        {
            isCanJump = true;
        }
       
    }

    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
    }
}
