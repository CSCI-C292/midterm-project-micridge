using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleGuy : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _moveSpeedUp = 3f;
    [SerializeField] GameObject _projPrefab;
    bool isGrounded;
    bool isBig = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Move();
        SizeChange();
    }

    void FixedUpdate()
    {
        isGrounded = false;
    }

    void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if(Input.GetButtonDown("Jump") && isGrounded){
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, _moveSpeedUp);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void Fire()
    {
        if(Input.GetButtonDown("Fire1")){
            Instantiate(_projPrefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        }
    }

    void SizeChange()
    {
        if(Input.GetButtonDown("Fire2")){
            isBig = !isBig;
            if(isBig){
                _moveSpeedUp = _moveSpeedUp + 2;
                transform.localScale = new Vector2(2, 2);
            }
            else{
                _moveSpeedUp = _moveSpeedUp - 2;
                transform.localScale = new Vector2(1, 1);
            }
        }

    }


}
