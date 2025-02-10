using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallManager _Ball;
    [SerializeField] private GameObject[] centersOfRope;
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
                    //Destroy(hit.collider.gameObject); // alternative method 1 tıklanan bağlantı yok edilir.
                    //_Ball.hingeControl["Center_1"].enabled = false; //alternative method 2 tıklanan bağlantı hinge özelliği kapatılır.

                    hit.collider.gameObject.SetActive(false); //alternative method 3 tıklanan bağlantı deaktif yapılır.
                    foreach (var item in centersOfRope) //tüm ipin hinge özelliği kapatılır.
                    {
                        if (item.GetComponent<RopeManager>().hingeName == "Center_1")
                        {
                            foreach (var item2 in item.GetComponent<RopeManager>().linkPool)
                            {
                                item2.GetComponent<HingeJoint2D>().enabled = false;
                                //item2.SetActive(false); //alternative method
                            }
                        }
                    }
                }
                else if(hit.collider.CompareTag("Center_2")) //method2
                {
                    hit.collider.gameObject.SetActive(false); //alternative method 3 tıklanan bağlantı deaktif yapılır.
                    foreach (var item in centersOfRope) //tüm ipin hinge özelliği kapatılır.
                    {
                        if (item.GetComponent<RopeManager>().hingeName == "Center_2")
                        {
                            foreach (var item2 in item.GetComponent<RopeManager>().linkPool)
                            {
                                item2.GetComponent<HingeJoint2D>().enabled = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
