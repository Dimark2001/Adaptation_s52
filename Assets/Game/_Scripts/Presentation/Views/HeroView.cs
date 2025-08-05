using System;
using Game._Scripts.Presentation.Presenters;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Game._Scripts.Presentation.Views
{
    public class HeroView : MonoBehaviour, IDisposable
    {
        private UIDocument _uiDocument;
        private IHeroPresenter _presenter;
        private readonly CompositeDisposable _disposables = new();

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
            var attackLabel = root.Q<Label>("attack-label");
            var upgradeButton = root.Q<Button>("upgrade-button");

            upgradeButton.clicked += _presenter.UpgradeHero;

            _presenter.Level.Subscribe(level => levelLabel.text = $"Level: {level}").AddTo(_disposables);
            _presenter.Attack.Subscribe(attack => attackLabel.text = $"Attack: {attack}").AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables?.Dispose();
            _presenter?.Dispose();
        }

        private void OnDestroy() => Dispose();
    }
}