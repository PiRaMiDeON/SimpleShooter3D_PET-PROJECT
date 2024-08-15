using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [Range(0, 300)]
    [SerializeField] private float _bulletSpeed;
    public void Shoot(Vector3 direction)
    {
        _rb.velocity = Vector3.zero;
        _rb.AddForce(direction.normalized * _bulletSpeed, ForceMode.VelocityChange);
        StartCoroutine(Timer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Aim")
        {
            ReleaseBullet();
            Debug.Log("Я попала во врага!");
        }
        else
        {
            ReleaseBullet();
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);

        ReleaseBullet();
    }

    private void ReleaseBullet()
    {
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        bulletPool._pool.Release(this);
    }
}
