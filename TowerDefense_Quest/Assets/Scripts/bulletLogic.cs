using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 150f;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            this.gameObject.SetActive(false);
            bulletPool.bulletPoolInstance.ReturnToPool(this);
            return;
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            float distanceEachFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceEachFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceEachFrame, Space.World);
        }
    }

    public void HitTarget()
    {
        bulletPool.bulletPoolInstance.ReturnToPool(this);
    }

}
