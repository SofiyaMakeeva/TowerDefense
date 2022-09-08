using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 1 * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        }

        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{
        //    if (height < maxHeight) tmpHeight += 1;
        //}
        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{
        //    if (height > minHeight) tmpHeight -= 1;
        //}

        //tmpHeight = Mathf.Clamp(tmpHeight, minHeight, maxHeight);
        //height = Mathf.Lerp(height, tmpHeight, 3 * Time.deltaTime);
        //transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}
