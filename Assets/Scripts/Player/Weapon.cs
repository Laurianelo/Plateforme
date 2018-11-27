using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private float fireRate = 0;

   // private float damage = 10;

    [SerializeField]
    private LayerMask notToHit;

    [SerializeField]
    private Transform bulletTrailPrefab; 

    [SerializeField]
    private Transform flashPrefab;

    private CameraShaker camShake;

    private Player player;
    private float timeToFire = 0;

    private Transform firePoint;


    private void Awake()
    {
        firePoint = transform.GetChild(0);

        if(firePoint == null)
        {
            Debug.LogError("no firePoint");
        }
    }

    private void Start()
    {
        player = GameManager.Instance.playerInstanciate.GetComponent<Player>();

        camShake = GameManager.Instance.GetComponent<CameraShaker>();

    }


    void Update () {
		if (fireRate == 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            else if(Input.GetMouseButtonDown(0) && Time.time> timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    private void Shoot()
    {
        Vector3 _mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _mousePosition = new Vector2(_mousePositionWorld.x, _mousePositionWorld.y);

        Vector2 _firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D _hit = Physics2D.Raycast(_firePointPosition, _mousePosition -_firePointPosition, Mathf.Infinity, notToHit);

        if(_hit.collider !=null)
        {
            if (_hit.collider.tag.Equals("enemy"))
            {
                EnemyFight _enemy = _hit.collider.gameObject.GetComponent<EnemyFight>();
                player.Attack(_enemy);
            }
        }

       // Effect();
        //Debug.DrawLine(_firePointPosition,(_mousePosition - _firePointPosition)*100);

        Vector3 _hitPos;
        if (_hit.collider ==null)
        {
            _hitPos = (_mousePosition - _firePointPosition) * 30;
        }else
        {
            _hitPos = _hit.point;
        }

        Effect(_hitPos);

        camShake.StartShake();
    }

    private void Effect(Vector3 hitPos)
    {
        
        Transform _trail = Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
        LineRenderer _lr = _trail.GetComponent<LineRenderer>();

        if(_lr != null)
        {
            _lr.SetPosition(0, firePoint.position);
            _lr.SetPosition(1, hitPos);
        }
        Destroy(_trail.gameObject, 0.03f);

        Transform _clone = Instantiate(flashPrefab, firePoint.position, firePoint.rotation) as Transform;

        float _size = UnityEngine.Random.Range(0.6f, 0.9f);

        _clone.localScale = new Vector3(_size, _size, _size);
        Destroy(_clone.transform.gameObject, 0.02f);
        
    }
}
