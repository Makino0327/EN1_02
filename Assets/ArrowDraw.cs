using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 dist =clickPosition - Input.mousePosition;
            float size = dist.magnitude;
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            arrowImage.rectTransform.position = clickPosition;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }

        if(Input.GetMouseButtonUp(0))
        {
            arrowImage.rectTransform.sizeDelta = new Vector2(0, 0);
        }
    }
}
