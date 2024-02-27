using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Commands;
using Interfaces;
using Data;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using UnityEngine.Events;
using Controllers;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Image _emptyImage;
        [SerializeField] TextMeshProUGUI _resultText, _undoCountText;
        [SerializeField] ExampleImageController _exampleImageController;
        [SerializeField] EmptyImageController _emptyImageController;

        public Button _rButton, _gButton, _bButton, _undoButton, _controlButton;

        private ICommand _changeBCommand, _changeRCommand, _changeGCommand;

        public Stack<ICommand> _commandHistory = new Stack<ICommand>();

        private float _colorChangeValue, _requiredSameValue, _currentUndoCount, _undoCountLimit;
        public float ResultColorCalculate;

        private string _addressableKey = "ColorChangeData";

        private CD_ColorChangeData _colorChangeData;

        private void Awake()
        {
            ImportData();
        }
        private void Start()
        {

            Init();

        }
        private async void ImportData()
        {
            AsyncOperationHandle<CD_ColorChangeData> handle = Addressables.LoadAssetAsync<CD_ColorChangeData>(_addressableKey);
            //_colorChangeData = Resources.Load<CD_ColorChangeData>("ColorChangeData");
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _colorChangeData = handle.Result;
                
                _colorChangeValue = _colorChangeData.ColorChangeValue;
                _requiredSameValue = _colorChangeData.RequiredSameValue;
                _currentUndoCount = _colorChangeData.UndoCountLimit;
                _undoCountLimit = _colorChangeData.UndoCountLimit;
                _undoCountText.text = _currentUndoCount.ToString();

                _changeBCommand = new ChangeBCommand(_emptyImage, _colorChangeValue);
                _changeRCommand = new ChangeRCommand(_emptyImage, _colorChangeValue);
                _changeGCommand = new ChangeGCommand(_emptyImage, _colorChangeValue);
                Debug.Log("ScriptableObject is Loaded: " + _colorChangeData.name + _colorChangeValue);
            }
            else
            {
                Debug.LogError("ScriptableObject not loaded. ");
            }
        }

        private void Init()
        {
            _exampleImageController.GenerateRandomColor();
            _rButton.onClick.AddListener(OnClickRButton);
            _gButton.onClick.AddListener(OnClickGButton);
            _bButton.onClick.AddListener(OnClickBButton);
            _undoButton.onClick.AddListener(OnClickUndoButton);
            _controlButton.onClick.AddListener(OnClickControlButton);
        }

        private void OnClickControlButton()
        {
            _emptyImageController.CalculateEuclideanDistance();
            if (ResultColorCalculate < _requiredSameValue)
            {
                StartCoroutine("SendMessage", "Nice! Similar Enough");
                _emptyImageController.ResetColor();

            }
            else
            {
                StartCoroutine("SendMessage", "Try Again Please!");

            }
        }
       
        private void OnClickBButton() => ExecuteCommand(_changeBCommand);
        private void OnClickGButton() => ExecuteCommand(_changeGCommand);
        private void OnClickRButton() => ExecuteCommand(_changeRCommand);
        private void OnClickUndoButton() => UndoLastCommand();


        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }
        private void UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand lastCommand = _commandHistory.Pop();
                lastCommand.Undo();
                DiscreaseUndoCount();
            }
        }

        IEnumerator SendMessage(string message)
        {
            _resultText.text = message;
            yield return new WaitForSeconds(0.8f);
            _resultText.text = "";
        }

        private void DiscreaseUndoCount()
        {
            _currentUndoCount--;
            _undoCountText.text = _currentUndoCount.ToString();
            if (_currentUndoCount <= 0)
            {
                StartCoroutine("SendMessage", "You tried all your luck!");
                _undoCountText.text = _undoCountLimit.ToString();
                _currentUndoCount = _undoCountLimit;
                _emptyImageController.ResetColor();
            }
        }
    }
}

