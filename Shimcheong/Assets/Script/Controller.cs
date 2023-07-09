using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    int direction; // direction
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    bool bool_isHorizontal = false;
    // ray
    GameObject scanObject;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("move!!");
    }

    void Awake()
	{
        rigid = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    private void Update()
    {
        //Direction Sprite
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                //spriteRenderer.flipX = true;
                direction = -1;
            }
            else
            {
                //spriteRenderer.flipX = false;
                direction = 1;

            }
        }

        //scan object
        if(Input.GetButtonDown("Jump") && scanObject != null) // space
		{
			Debug.Log("오 스페이스 누름! This is :" + scanObject.name);
		}
	}
    public float detect_range = 1.5f;
    public float moveSpeed = 5.0f;

    private void FixedUpdate() // move
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;

        //����׼�
        Debug.DrawRay(GetComponent<Rigidbody2D>().position, new Vector3(direction * detect_range, 0, 0), new Color(0, 0, 1));

        //Layer�� Object�� ��ü�� rayHit_detect�� ���� 
        RaycastHit2D rayHit_detect = Physics2D.Raycast(GetComponent<Rigidbody2D>().position, new Vector3(direction, 0, 0), detect_range, LayerMask.GetMask("obj_NPC"));

        //�����Ǹ� scanObject�� ������Ʈ ���� 
        if (rayHit_detect.collider != null)
        {
            scanObject = rayHit_detect.collider.gameObject;
            Debug.Log(scanObject.name);
        }
        else
        {
            scanObject = null;
        }
    }

    void OnCollisionEnter(Collision npc_collider)
    {
        if (npc_collider.gameObject.name == "NPC")
            Debug.Log("Touch!");
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public static MovingObject instance;

    public float speed;
    public int walkCount;
    private int currentWalkCount;

    private Vector3 vector;

    private BoxCollider2D boxCollider;
    private LayerMask layerMask;
    private Animator animator;

    public float runSpeed;
    private float applyRunSpeed;
    private bool applyRunFlag = false;
    private bool canMove = true;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }


            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector.x != 0)
                vector.y = 0;


            //animator.SetFloat("DirX", vector.x);
            //animator.SetFloat("DirY", vector.y);
            //animator.SetBool("Walking", true);

            while (currentWalkCount < walkCount)
            {

                transform.Translate(vector.x * (speed + applyRunSpeed), vector.y * (speed + applyRunSpeed), 0);
                if (applyRunFlag)
                    currentWalkCount++;
                currentWalkCount++;
                yield return new WaitForSeconds(0.01f);
            }
            currentWalkCount = 0;

        }
        //animator.SetBool("Walking", false);
        canMove = true;

    }



    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }

    }
}*/