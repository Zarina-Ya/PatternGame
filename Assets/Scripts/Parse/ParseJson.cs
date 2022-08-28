
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace ZarinkinProject
{
    public class ParseJson
    {
       
        FactoryInfantry _factoryInfantry = new FactoryInfantry();
        FactoryMag _factoryMag = new FactoryMag();
        JsonUnits jsonUnits;
        public ParseJson(string path)
        {
            var json = File.ReadAllText(path);
            //Unit employeesInJson = JsonUtility.FromJson<Unit>(json);
            //Debug.Log(employeesInJson.informations.ToString());

            jsonUnits = JsonUtility.FromJson<JsonUnits>(json);
        }

        public List<Player> GetPlayers()
        {
            var players = new List<Player>();
            foreach (var unit in jsonUnits.units)
            {
                players.Add(GetPlayer(unit.type, unit.health));
            }

            return players;
        }

        private Player GetPlayer(string type, string strHealth)
        {
            var intHealt = Convert.ToInt32(strHealth);
            var health  = new Health(intHealt, intHealt); 
            switch (type)
            {
                case "mag":
                     return _factoryMag.Create(health);
                 
                case "infantry":
                    return _factoryInfantry.Create(health);
              
                default:
                    throw new Exception("Unrecognised type of unit");
          
            }
        }
    }
    [System.Serializable]
    public struct JsonUnit
    {
        public string type;
        public string health;

        public override string ToString()
        {
            return $"{type}. {health}";
        }
    }
    [System.Serializable]
    public struct JsonUnits
    {
        public JsonUnit[] units;

    }

    //[System.Serializable]
    //public struct Tests
    //{
    //    public Test[] tests;
    //}
    //[System.Serializable]
    //public struct Test
    //{
    //    public string Name;
      
    //    public int Age;

    //    public override string ToString()
    //    {
    //        return $"{Name}. {Age}";
    //    }
    //}
}

