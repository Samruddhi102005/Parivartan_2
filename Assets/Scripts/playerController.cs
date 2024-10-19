using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float for_speed;
    public float side_speed;

    public Transform center_pos;
    public Transform left_pos;
    public Transform right_pos;

    private int current_pos;

    private bool isPlay;

    public Animator player_animator;

    void Start()
    {
        isPlay = false;
        current_pos = 0;
    }

     void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isPlay = true;
            player_animator.SetFloat("is running",1);
        }
        if (isPlay) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + for_speed * Time.deltaTime);
            if (current_pos == 0)
            {
                //transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new Vector3(center_pos.position.x, transform.position.y, transform.position.z), side_speed * Time.deltaTime);
            }
            else if (current_pos == 1)
            {
                //transform.position = new Vector3(-2.25f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new Vector3(left_pos.position.x, transform.position.y, transform.position.z), side_speed * Time.deltaTime);
            }
            else if (current_pos == 2)
            {
                //transform.position = new Vector3(2.25f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new Vector3(right_pos.position.x, transform.position.y, transform.position.z), side_speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (current_pos == 0)
                {
                    current_pos = 1;
                }
                else if (current_pos == 2)
                {
                    current_pos = 0;
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (current_pos == 0)
                {
                    current_pos = 2;
                }
                else if (current_pos == 1)
                {
                    current_pos = 0;
                }

            }
        }
        
    }
}