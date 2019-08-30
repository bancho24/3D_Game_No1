using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //カメラオブジェクト
    public GameObject mainCamera;

    //位置調整
    public int zAdjust = 5;

    // Update is called once per frame
    void Update()
    {
        //カメラ初期位置
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zAdjust);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 1);
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -1);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
        }
    }
}
