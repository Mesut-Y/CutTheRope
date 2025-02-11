using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallManager _Ball;
    [SerializeField] private GameObject[] centersOfRope;

    [SerializeField] private int ballCounter;
    [SerializeField] private int targetObjectCounter;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Center_1")
                    CreateRope(hit, "Center_1");
                else if(hit.collider.CompareTag("Center_2"))
                    CreateRope(hit, "Center_2");
                else if (hit.collider.CompareTag("Center_3"))
                    CreateRope(hit, "Center_3");
                else if (hit.collider.CompareTag("Center_4"))
                    CreateRope(hit, "Center_4");
            }
        }
    }

    void CreateRope(RaycastHit2D hit, string centerName)
    {
        //Destroy(hit.collider.gameObject); // alternative method 1 tıklanan bağlantı yok edilir.
        //_Ball.hingeControl["Center_1"].enabled = false; //alternative method 2 tıklanan bağlantı hinge özelliği kapatılır.

        hit.collider.gameObject.SetActive(false); //alternative method 3 tıklanan bağlantı deaktif yapılır.
        foreach (var item in centersOfRope) //tüm ipin hinge özelliği kapatılır.
        {
            if (item.GetComponent<RopeManager>().hingeName == centerName)
            {
                foreach (var item2 in item.GetComponent<RopeManager>().linkPool)
                {
                    item2.GetComponent<HingeJoint2D>().enabled = false;
                    //item2.SetActive(false); //alternative method
                }
            }
        }
    }

    public void TargetFalling()
    {
        targetObjectCounter--;
        
    }

    public void BallFalling()
    {
        ballCounter--;

    }

}


