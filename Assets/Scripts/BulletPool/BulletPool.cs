using UnityEngine;
using UnityEngine.Pool;

public class BulletPool: MonoBehaviour
{
    public ObjectPool<Bullet> _pool;

    private Bullet _prefab;

    private Transform _spawnPoint;

    public void InitBulletPool(Bullet prefab, int prewarmObjectCount, Transform spawnPoint)
    {
        _prefab = prefab;
        _spawnPoint = spawnPoint;

        _pool = new ObjectPool<Bullet>(OnCreateBullet,
            OnGetBullet,
            OnRelease, 
            OnBulletDestroy, 
            false, 
            prewarmObjectCount);
    }

    public Bullet OnCreateBullet()
    {
        Bullet bullet = GameObject.Instantiate(_prefab, _spawnPoint, false);

        return bullet;
    }

    public void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.transform.position = _spawnPoint.position;
        bullet.gameObject.SetActive(true);
        bullet.Shoot(_spawnPoint.forward);
    }
    
    public void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public void OnBulletDestroy(Bullet bullet)
    {
        GameObject.Destroy(bullet.gameObject);
    }
}
