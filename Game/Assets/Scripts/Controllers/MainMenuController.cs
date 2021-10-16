using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MobileGame
{
    public class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };
        private readonly PlayerProfile _playerProfile;
        private MainMenuView _mainMenuView;

        public MainMenuController(Transform placeForUi, PlayerProfile playerProfile)
        {
            _playerProfile = playerProfile;
            _mainMenuView = LoadView(placeForUi);
            _mainMenuView.Init(StartGame);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObject(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _playerProfile.CurrentState.Value = GameState.Game;
        }
    }
}
