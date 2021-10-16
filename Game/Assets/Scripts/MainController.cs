using System;
using UnityEngine;


namespace MobileGame
{
    public class MainController : BaseController
    {
        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private readonly Transform _placeForUI;
        private readonly PlayerProfile _playerProfile;

        public MainController(Transform placeForUi, PlayerProfile playerProfile)
        {
            _placeForUI = placeForUi;
            _playerProfile = playerProfile;
            OnChangeGameState(_playerProfile.CurrentState.Value);
            _playerProfile.CurrentState.SubscribeOnChange(OnChangeGameState);
        }

        protected override void OnDispose()
        {
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
            _playerProfile.CurrentState.UnsubscribeOnChange(OnChangeGameState);
            base.OnDispose();
        }

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUI, _playerProfile);
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _gameController = new GameController(_playerProfile);
                    _mainMenuController?.Dispose();
                    break;
                default:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
            }
        }
    }
}