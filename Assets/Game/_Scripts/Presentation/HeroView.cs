using System;
using Game._Scripts.Interfaces;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Game._Scripts.Presentation
{
    public class HeroView : MonoBehaviour, IDisposable
    {
        private UIDocument _uiDocument;
        private IHeroPresenter _presenter;
        private IDisposable _levelSubscription;

        [Inject]
        private void Construct(UIDocument uiDocument, IHeroPresenter presenter)
        {
            _uiDocument = uiDocument;
            _presenter = presenter;
        }

        private void Awake()
        {
            var root = _uiDocument.rootVisualElement;
            var levelLabel = root.Q<Label>("level-label");
            var upgradeButton = root.Q<Button>("upgrade-button");

            upgradeButton.clicked += () => _presenter.UpgradeHero();
            _levelSubscription = _presenter.HeroLevel.Subscribe(level => levelLabel.text = $"Level: {level}");
        }

        public void Dispose()
        {
            _levelSubscription?.Dispose();
        }

        private void OnDestroy() => Dispose();
    }
}