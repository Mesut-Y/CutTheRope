using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D firstHook;
    public BallManager _Ball;
    public int linkCounter = 8; //kanca ve top arası bağlantı sayısı
    public GameObject linkPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateRope();
    }

    void CreateRope()
    {
        Rigidbody2D lastLink = firstHook;

        for (int i = 0; i < linkCounter; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = lastLink;
            if (i < linkCounter - 1)
            {
                lastLink = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                _Ball.TieLastChain(link.GetComponent<Rigidbody2D>());
            }
        }
    }
}
