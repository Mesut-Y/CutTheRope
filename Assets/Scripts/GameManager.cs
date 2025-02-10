using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BallManager _Ball;
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
                    //Destroy(hit.collider.gameObject); // alternative method
                    hit.collider.gameObject.SetActive(false);
                    _Ball.hingeControl["Center_1"].enabled = false;
                }
                else if(hit.collider.CompareTag("Center_2")) //method2
                {
                    hit.collider.gameObject.SetActive(false);
                    _Ball.hingeControl["Center_2"].enabled = false;
                }
            }
        }
    }
}
