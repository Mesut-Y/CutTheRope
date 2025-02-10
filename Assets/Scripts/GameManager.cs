using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Center_1") // method1
                {
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.CompareTag("Center_2")) //method2
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
