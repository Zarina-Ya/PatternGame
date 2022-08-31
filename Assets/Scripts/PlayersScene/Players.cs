using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ZarinkinProject
{
    public class Players : MonoBehaviour
    {
        private List<Player> _players = new List<Player>();
      
        void Start()
        {

            _players.Add(new Mag(GenerateHealth()));
            _players.Add(new Archer(GenerateHealth()));
            _players.Add(new Infantry(GenerateHealth()));
            _players.Add(new Mag(GenerateHealth()));
            _players.Add(new Archer(GenerateHealth()));
            _players.Add(new Infantry(GenerateHealth()));
            _players.Add(new Mag(new Health(100, 0)));
            _players.Add(new Mag(new Health(100, 100)));

            Print(_players);
        }

        public void Print(List<Player> players)
        {
            StringBuilder str = new StringBuilder();
            foreach (var player in players)
            {
                str.Append(player.Health.Current.ToString());
                str.Append(' ');
                //Debug.Log($"- {player.Health.Current}");
            }

            Debug.Log(str.ToString());
        }
        public float MaxHealth => _players.Select(a => a.Health.Current).Max();
        public List<Player> DeadPlayers => _players.Where(a => a.IsDead()).ToList();
        public List<Player> AlivesPlayers => _players.Where(a => a.IsAlive()).ToList();
        public List<Player> MaxHealthPlayers => _players.Where(a => a.IsFullHealth()).ToList();
        private Health GenerateHealth()
        {
            return new Health( 100, Random.Range(0, 100));
        }

      
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.W))
                Debug.Log(MaxHealth.ToString());
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Print(DeadPlayers);
     
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Print(AlivesPlayers);
                
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Print(MaxHealthPlayers);
               
            }
        }
    }
}
