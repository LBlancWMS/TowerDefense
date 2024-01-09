using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceEachFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceEachFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceEachFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
