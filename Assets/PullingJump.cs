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
        isCanJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
    }
}
