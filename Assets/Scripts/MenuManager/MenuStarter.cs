using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ZarinkinProject
{
    public class MenuStarter : MonoBehaviour
    {
        private ICommand _buttonStart;
        private ICommand _buttonQuit;
        private ICommand _buttonGetNumber;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TMPro.TMP_Text _textNumber;

        void Start()
        {
            _buttonQuit = new QuitCommand();
            _buttonStart = new StartCommand(0);
            _buttonGetNumber = new GetNumberCommand(_textNumber);
            InitButtons();
        }

        public void InitButtons()
        {
            var buttons = _canvas.GetComponentsInChildren<Button>();
            InitNeedButton("StartButton", buttons, _buttonStart);
            InitNeedButton("QuitButton", buttons, _buttonQuit);
            InitNeedButton("GetNumberButton", buttons, _buttonGetNumber);
        }

        public void InitNeedButton(string name, Button[] buttons, ICommand command)
        {
            var needButton = buttons.First( s => s.name == name );
            needButton.onClick.RemoveAllListeners();
            needButton.onClick.AddListener(() => command.Execute());
        }

       
    }
}
