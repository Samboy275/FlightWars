using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer bulletTrail;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private ParticleSystem bulletHitEffect;
    [SerializeField]
    private float shootDelay = 0.5f;
    [SerializeField]
    private float lastShootTime;
    [SerializeField]
    private LayerMask Mask;

    public void Shoot()
    {
        Vector3 shootDirection = GetDirction();

        if (Physics.Raycast(bulletSpawnPoint.position, shootDirection, out RaycastHit hit, float.MaxValue, Mask))
        {
            Debug.Log(hit);
            TrailRenderer trail = Instantiate(bulletTrail, transform.position, Quaternion.identity);
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject, trail.time);
                GameManager.Instance.IncrementScore();
            }
            StartCoroutine(SpawnTrail(trail, hit));
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;

        Vector3 startPosition = trail.transform.position;

        while (time < 0.4f)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;
            yield return null;
        }
        trail.transform.position = hit.point;
        Destroy(trail.gameObject, trail.time);
        

    }

    private Vector3 GetDirction()
    {
        Vector3 direction = transform.forward;
        return direction;
    }
}
