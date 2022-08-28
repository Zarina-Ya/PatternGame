using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZarinkinProject
{
    public class Player : MonoBehaviour { 

        protected IMove _moveTransform;
        protected IRotation _rotation;

        private Health health = new Health(100, 100);

        [SerializeField] private float _speed;
        [SerializeField] protected float _turnSpeed;
        [SerializeField] private float _endurance;
        [SerializeField] private float _runnigSpeed;
        [SerializeField] private float _maxEndurance = 50;
        [SerializeField] private float _speedWalk = 50;
        private bool _isRunning = false;
        protected Health Health { get => health; set => health = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public bool IsRunning { get => _isRunning; set => _isRunning = value; }
        public float Endurance { get => _endurance; set => _endurance = value; }
        public float MaxEndurance { get => _maxEndurance; set => _maxEndurance = value; }
        public float RunnigSpeed { get => _runnigSpeed; }
        public float SpeedWalk { get => _speedWalk;}

        private Controller move;
        private void Awake()
        {
           // Health = new Health(100, 100);
        }

        public void TakeDamage(int damage)
        {
            if (Health.Current <= damage)
                Destroy(gameObject);
            else
            {
                Health.ChangeCurrentHealth((int)Health.Current - damage);
                Debug.Log(Health.Current);
            }
        }

        private void Start()
        {
            //_moveTransform = new MoveTransform(transform, _speed, GetComponent<Rigidbody>(), GetComponent<Animator>());
           // _moveTransform = new MoveTest();
            _rotation = new RotationPlayer(transform, _turnSpeed);

            move = new RunKeyController(this);
            move.Add(new EnduranceController(this));
            move.Add(new SpeedController(this));
            move.Add(new MoveController(this));

        }
        private void Update()
        {
            //_isRunning = Input.GetKey(KeyCode.LeftShift) && _endurance > 0;
           
            _rotation.Rotation(Input.GetAxis("Horizontal"));
        }

        private void SetSpeed()
        {
            if (_isRunning)
            {
                if (_endurance > 10)
                    _moveTransform.Speed = _runnigSpeed;
            }
            else
                _moveTransform.Speed = _speed;
            
        }


        private void FixedUpdate()
        {
            move.Handle();
            //_moveTransform.Move(Input.GetAxis("Vertical"));
            // _moveTransform.Move();
        }
      
 
    }


    public class Controller
    {
        protected Player _player;
        protected Controller Next;
        public Controller(Player player)
        {
            _player = player;
        }
        public void Add(Controller cm)
        {
            if (Next != null)
              Next.Add(cm);
            else Next = cm;
            
        }
        public virtual void Handle() => Next?.Handle();
    }

    public class MoveController : Controller
    {
        private IMove _moveTransform;

        public MoveController(Player player) : base(player)
        {
            _moveTransform = new MoveTransform(_player.transform, _player.Speed, _player.GetComponent<Rigidbody>(),
                _player.GetComponent<Animator>());
        }
        public override void Handle()
        {
            _moveTransform.Speed = _player.Speed;
            _moveTransform.Move(Input.GetAxis("Vertical"));
            base.Handle();
        }


    }

    internal sealed class RunKeyController : Controller
    {
        public RunKeyController(Player player): base(player){}
        public override void Handle()
        {
            _player.IsRunning = Input.GetKey(KeyCode.LeftShift);
            base.Handle();
        }
    }

    internal sealed class EnduranceController : Controller
    {
        
        public EnduranceController(Player player) : base(player) { }
        public override void Handle()
        {
            if (_player.IsRunning)
            {
                if(_player.Endurance > 0)
                    _player.Endurance--;
            }
            else {
                if (_player.Endurance < _player.MaxEndurance)
                    _player.Endurance++;
            }
            base.Handle();
        }
    }

    internal sealed class SpeedController : Controller
    {

        public SpeedController(Player player) : base(player) { }
        public override void Handle()
        {
            if (_player.IsRunning && _player.Endurance > 0)
            {
                _player.Speed = _player.RunnigSpeed;
            }
            else
            {
                _player.Speed = _player.SpeedWalk;
            }
            base.Handle();
        }
    }
}

