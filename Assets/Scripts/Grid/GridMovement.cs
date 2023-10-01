using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    
    [SerializeField]
    private float timeToMove = 0.2f;
    [SerializeField] private float moveLegth = 1;

    public bool hadFlag;
    public int colorFlag;


    private Animator anim;
    private bool rightLeg;

    //Wall Detect
    public bool collideForward,collideLeft,collideRight,collideBack;
    public float wallDistance = 1f;
    public float yVector = 1f;

    GameObject child;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rightLeg = false;
        child = transform.GetChild(0).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        collideForward = Physics.Raycast(transform.position + new Vector3(0, yVector, 0), transform.forward, wallDistance, LayerMask.GetMask("Wall"));
        collideBack = Physics.Raycast(transform.position + new Vector3(0, yVector, 0), transform.forward *-1, wallDistance, LayerMask.GetMask("Wall"));
        collideRight = Physics.Raycast(transform.position + new Vector3(0, yVector, 0), transform.right, wallDistance, LayerMask.GetMask("Wall"));
        collideLeft = Physics.Raycast(transform.position + new Vector3(0, yVector, 0), transform.right *-1, wallDistance, LayerMask.GetMask("Wall"));

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !isMoving)
        {
            child.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            if (collideForward)
                return;
            
            rightLeg = !rightLeg;
            if (rightLeg)
                anim.SetTrigger("RightWalk");
            else
                anim.SetTrigger("LeftWalk");

                StartCoroutine(MovePlayer(new Vector3(0, 0, moveLegth)));
            

        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isMoving)
        {
            child.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            if (collideLeft)
                return;
            rightLeg = !rightLeg;
            if (rightLeg)
                anim.SetTrigger("RightWalk");
            else
                anim.SetTrigger("LeftWalk");

            StartCoroutine(MovePlayer(new Vector3(-moveLegth, 0, 0)));


        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isMoving)
        {
            child.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            if (collideRight)
                return;

            rightLeg = !rightLeg;
            if (rightLeg)
                anim.SetTrigger("RightWalk");
            else
                anim.SetTrigger("LeftWalk");


            StartCoroutine(MovePlayer(new Vector3(moveLegth, 0, 0)));


        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !isMoving)
        {
            child.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            if (collideBack)
                return;
            rightLeg = !rightLeg;
            if (rightLeg)
                anim.SetTrigger("RightWalk");
            else
                anim.SetTrigger("LeftWalk");

            StartCoroutine(MovePlayer(new Vector3(0, 0, -moveLegth)));


        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (Input.GetKey(KeyCode.E) && other.GetComponent<Platform>().isGenerator)
            {
                hadFlag = true;
                colorFlag = other.GetComponent<Platform>().color;

            }
            else if (Input.GetKey(KeyCode.E) && !other.GetComponent<Platform>().isGenerator)
            {
                hadFlag = false;
            }

        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsetime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsetime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsetime / timeToMove));
            elapsetime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
        
        //StartCoroutine(WaitForAnimation(anim.GetCurrentAnimatorStateInfo(0).length));

    }

    IEnumerator WaitForAnimation(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        isMoving = false;

    }

    private void OnDrawGizmos()
    {
        if (collideForward)
            Debug.DrawRay(transform.position + new Vector3(0,yVector,0), transform.forward * wallDistance, Color.red);
        else
            Debug.DrawRay(transform.position + new Vector3(0, yVector, 0), transform.forward * wallDistance, Color.white);

        if (collideBack)
            Debug.DrawRay(transform.position + new Vector3(0, yVector, 0), transform.forward *-1 * wallDistance, Color.red);
        else
            Debug.DrawRay(transform.position + new Vector3(0, yVector, 0), transform.forward *-1* wallDistance, Color.white);

        if (collideRight)
            Debug.DrawRay(transform.position + new Vector3(0, yVector, 0), transform.right * wallDistance, Color.red);
        else
            Debug.DrawRay(transform.position + new Vector3(0, yVector, 0), transform.right * wallDistance, Color.white);

        if (collideLeft)
            Debug.DrawRay(transform.position + new Vector3(0, yVector, 0), transform.right *-1 * wallDistance, Color.red);
        else
            Debug.DrawRay(transform.position + new Vector3(0, yVector, 0), transform.right *-1 * wallDistance, Color.white);
    }
}
