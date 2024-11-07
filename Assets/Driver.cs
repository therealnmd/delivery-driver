/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        //nếu các số liệu Rotation là + thì sẽ xoay theo chiều kim đồng hồ và ngược lại
        //Rotation:
        //trục X sẽ là xoay upside-down (từ trên xuống dưới) theo phương ngang
        //trục Y sẽ là xoay từ trái sang phải theo trục thẳng đứng
        //trục Z sẽ là xoay tròn 360 độ theo hướng mắt nhìn thẳng
        //(nếu số liệu là +, lấy điểm đặt mắt ở 0 độ thì object sẽ quay ngược chiều kim đồng hồ)
        //(nếu số liệu là -, lấy điểm đặt mắt ở 180 độ thì object sẽ quay thuận chiều kim đồng hồ)
        //transform.Rotate(0, 0, 90);

        //Scale:
        //trục X sẽ là kéo rộng bề mặt object theo phương ngang
        //trục Y sẽ là kéo dài bề mặt object theo trục thẳng đứng
        //trục Z sẽ là kéo rộng bề mặt object theo hướng mắt nhìn thẳng
    }

    // Update is called once per frame
    void Update()
    {
        //Translate:
        //trục X sẽ là di chuyển lên xuống theo phương ngang
        //trục Y sẽ là di chuyển trái phải theo phương thẳng đứng
        //trục Z sẽ là di chuyển tiến tới/lùi về theo hướng mắt nhìn thẳng
        //transform.Rotate(0, 0, -0.1f);
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveSpeed, 0);
        
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = -40.5f;
    [SerializeField] float normalSpeed = 2.6f;
    [SerializeField] float slowSpeed = 0.1f;
    [SerializeField] float boostSpeed = 7.0f;
    float currentSpeed;
    

    void Start()
    {

    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * normalSpeed * Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
        
        
        
      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        normalSpeed = slowSpeed;
        //StartCoroutine(SlowSpeed());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Speed Orb")
        {
            normalSpeed = boostSpeed;
            //StartCoroutine(BoostSpeed());           
        }    
        

    }
    /*private IEnumerator BoostSpeed()
    {
        currentSpeed = boostSpeed;
        yield return new WaitForSeconds(3);
        currentSpeed = normalSpeed;
    }

    private IEnumerator SlowSpeed()
    {
        currentSpeed = slowSpeed;
        yield return new WaitForSeconds(3);
        currentSpeed = normalSpeed;
    }*/
}
