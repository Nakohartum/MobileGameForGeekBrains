using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace MobileGame
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;
        private MainController _mainController;

        private void Awake()
        {
            var playerProfile = new PlayerProfile(15f);
            playerProfile.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUI, playerProfile);
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}
