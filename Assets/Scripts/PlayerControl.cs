using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float moveSpeed = 5f;
    public bool IsGameOver { private get; set; }
    bool facingRight;
    private void Awake()
    {
        player = gameObject;
        facingRight = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver) return;
        //up
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        //down
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                player.transform.localScale = new Vector3(-1, 1, 1);
                facingRight = !facingRight;
            }

            player.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        //right
        else if (Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                player.transform.localScale = new Vector3(1, 1, 1);
                facingRight = !facingRight;
            }
            player.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
