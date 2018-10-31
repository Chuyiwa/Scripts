using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	
    // 目標對象
    public Transform targetObj = null;

    // 攝影機與目標的最遠距離
    public float maxDistance = 100;

    // 攝影機與目標的最小距離
    public float minDistance = 1;

    // 攝影機與目標的當前距離
    public float currentDistance = 50;

    // 滑鼠滾輪與距離的控制量，值越大，量越大；反之越小
    public float scrollWheelSpeed = 3;

    public Vector3 velocity = Vector3.zero;

    // public Vector3 direct = new Vector3(0, 0, 1);

    private float rotateX = 0.0f;

    void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (null == this.targetObj)
            return;

        FollowTarget();
        //RotateCamera();
    }

    /// <summary>
    /// 跟随目標
    /// </summary>
    private void FollowTarget()
    {
        // 取得鼠標的滾輪值
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        this.currentDistance -= scrollWheel * this.scrollWheelSpeed;
        this.currentDistance = Mathf.Clamp(this.currentDistance, this.minDistance, this.maxDistance);

        Vector3 vector = new Vector3(0, 3.0f, this.currentDistance * -1);
        vector = this.targetObj.TransformVector(vector);

        this.transform.LookAt(this.targetObj.position);
        Vector3 targetPosition = this.targetObj.transform.position + vector;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, 0.3f);
    }

    /// <summary>
    /// 鼠標控制攝影機旋轉
    /// </summary>
    private void RotateCamera()
    {
        this.rotateX += Input.GetAxis("Mouse X");
        this.targetObj.rotation = Quaternion.Euler(0, this.rotateX, 0);
    }
}

