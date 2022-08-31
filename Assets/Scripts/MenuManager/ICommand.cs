using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Random = UnityEngine.Random;

namespace ZarinkinProject { 
    public interface ICommand 
    {
        void Execute();
    }

    public class StartCommand : ICommand
    {
        private int _indexLevel;
        public StartCommand(int indexLevel) { _indexLevel = indexLevel; }

        public void Execute() => SceneManager.LoadScene(_indexLevel);
     
    }

    public class QuitCommand : ICommand
    {
        public void Execute()
        {
            Application.Quit();
        }
    }

    public class GetNumberCommand : ICommand
    {
        TMP_Text _text;
        ulong _number;
        public  String[] a = { "K", "M", "B", "T", "Qa", "Qi" };
        public GetNumberCommand(TMP_Text text)
        {
            _text = text;
            _number =(ulong) Random.Range(10, 101);
            _text.text = _number.ToString();
        }
        public void Execute()
        {
            _text.text =$"{print(_number *= (ulong)Random.Range(10, 35))} --- {_number}" ;
        }
        private  string print(ulong number)
        {

            String str = Convert.ToString(number);

            int index = 0;
            for (int i = 0; i < str.Length - 3; i += 3)
            {
                index++;
            }
            str = str.Substring(0, str.Length - index * 3);

            if (index > 0)
            {
                return str + a[index - 1];
            }
         
            return str;
        }
    }
}
