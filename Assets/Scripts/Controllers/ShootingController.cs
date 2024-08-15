using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private FireType _fireType;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private ParticleSystem _fireParticles;

    private void Awake()
    {
        _bulletPool.InitBulletPool(_bulletPrefab.GetComponent<Bullet>(), 10, _bulletSpawnPoint);

        for (int i = 0; i < 10; i++)
        {
            _bulletPool._pool.Get();
        }
    }

    private void Update()
    {
        if (_fireType == FireType.single)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Bullet bullet = _bulletPool._pool.Get();
        _fireParticles.Play();
    }

    public enum FireType
    {
        single = 1,
        multi = 2
    }
}
