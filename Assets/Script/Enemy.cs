using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 10f;
    private float rotationSmooth = 1f;

    private Vector3 targetPosition;

    private float changeTargetSqrDistance = 40f;

    private void Start()
    {
        targetPosition = GetRandomPositionOnLevel();
    }

    private void Update()
    {
        // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
        float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
        if (sqrDistanceToTarget < changeTargetSqrDistance)
        {
            targetPosition = GetRandomPositionOnLevel();
        }

        // 目標地点の方向を向く
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        // 前方に進む
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public Vector3 GetRandomPositionOnLevel()
    {
        float levelSize = 55f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }
}
