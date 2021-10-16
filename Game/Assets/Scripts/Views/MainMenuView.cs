using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace MobileGame
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }

    }
}
