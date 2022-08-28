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
        [SerializeField] private Canvas _canvas;
       
        void Start()
        {
            _buttonQuit = new QuitCommand();
            _buttonStart = new StartCommand(0);
            InitButtons();
        }

        public void InitButtons()
        {
            var buttons = _canvas.GetComponentsInChildren<Button>();
            InitNeedButton("StartButton", buttons, _buttonStart);
            InitNeedButton("QuitButton", buttons, _buttonQuit);
        }

        public void InitNeedButton(string name, Button[] buttons, ICommand command)
        {
            var needButton = buttons.First( s => s.name == name );
            needButton.onClick.RemoveAllListeners();
            needButton.onClick.AddListener(() => command.Execute());
        }
          
    }
}
