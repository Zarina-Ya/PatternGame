using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ZarinkinProject
{
   public class GameStarter : MonoBehaviour
   {
        Enemy primitiveEnemy;
        Enemy normalEnemy;
        [SerializeField] Transform _targetTransform;
        private Player _player;
        [SerializeField] float _minDistance;
        [SerializeField] float _speed;
        [SerializeField] GameObject _bullet;
        [SerializeField] Mesh _mesh;
        [SerializeField] Material _material;


        bool canShoot = true;

        private void Awake()
        {
            //var gameObjectBuilder = new GameObjectBuilder();
            //GameObject bullet =
            //gameObjectBuilder.Visual.Name("bulletBuilder").MeshFilter(_mesh).MeshRenderer(_material).Physics.Rigidbody(5).MeshCollider();

            //ServiceLocator.SetService(new ObjectPool(bullet));

            //Destroy(bullet);
        }
        private void Start()
        {
            //primitiveEnemy = new Enemy("TEstEnemy", new PrimitiveEnemyFactory());
            //normalEnemy = new Enemy("TEstNormalEnemy", new NormalEnemyFactory());





            //_targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            //  //CreateBulletViewService();


            //    TestCreateObjectPoolLocator();

            ParseJson parseJson = new ParseJson(Path.Combine(Application.dataPath + "/", "Scripts/Parse/uitInfo.json"));
            parseJson.GetPlayers();

        }


        private void CreateBulletViewService()
        {
            ViewService viewService = new ViewService();
            var test = viewService.Instantiate<Rigidbody>(_bullet);
            test.transform.position = Vector3.zero;
        }
        private void TestCreateObjectPoolLocator()
        {
            ServiceLocator.Resolve<ObjectPool>().Pop().transform.position = Vector3.zero;
        }

        private void Update()
        {
            if(_targetTransform)
                normalEnemy.Move(_targetTransform, _minDistance, _speed);
           
            if (_player  && Vector3.Distance(_targetTransform.position, normalEnemy.Prefab.GetComponent<Transform>().position) <= _minDistance)
            {
                if(canShoot) {
                     canShoot = false;
                    _player.TakeDamage(normalEnemy.Shoot());
                    Debug.Log("SHOOT");
                    Invoke(nameof(Reloading), 3);
                }
             
            }
        }


        private void Reloading()
        {
            canShoot = true;
        }
     
    }
}