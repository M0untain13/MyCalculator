using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using СalculatorLib.Services.Interfaces;

namespace СalculatorLib.ViewModels.Pages
{
    public class HomeViewModel : MvxViewModel
    {
        #region Сервисы

        private readonly ICalculateService _calculateService;

        #endregion

        #region Поля ввод/вывод

        #region Ввод

        #region Выделенный текст

        private int _selStartInd;
        public int SelStartInd
        {
            get => _selStartInd;
            set => SetProperty(ref _selStartInd, value);
        }

        private int _selLen;
        public int SelLen
        {
            get => _selLen;
            set => SetProperty(ref _selLen, value);
        }

        #endregion



        private string _inputText = "2 + 2 * 2";
        public string InputText
        {
            get => _inputText;
            set
            {
                if (SetProperty(ref _inputText, value))
                {
                    _calculateService.InputText = _inputText;
                    RaisePropertyChanged(nameof(OutputText));
                    RaisePropertyChanged(nameof(OutputTip));
                    InputState = _inputText;
                    SelLen = 0;
                    if (InputText.Length > 0)
                        SelStartInd = InputText.Length;
                    else
                        SelStartInd = 0;
                }
            }
        }

        #endregion

        #region Вывод

        public string OutputText => _calculateService.OutputText;

        public string OutputTip => _calculateService.GetMessageAboutError();

        #endregion

        #region Состояния ввода

        private readonly List<string> _inputStates = new();

        private const byte _CACHE_SIZE = 50;

        public string InputState
        {
            get
            {
                if (_inputStates.Count <= 1)
                    return string.Empty;
                _inputStates.RemoveAt(_inputStates.Count - 1);
                var state = _inputStates.Last();
                _inputStates.RemoveAt(_inputStates.Count - 1);
                return state;
            }
            set
            {
                if(_inputStates.Count >= _CACHE_SIZE)
                    _inputStates.RemoveAt(0);
                _inputStates.Add(value);
            }
        }

        #endregion

        #endregion

        #region Команды

        public IMvxCommand InputCharacterCommand { get; }

        public IMvxCommand InputTrigCommand { get; }

        public IMvxCommand InputDelCommand { get; }

        public IMvxCommand InputBackCommand { get; }

        #endregion

        public HomeViewModel(ICalculateService calculateService)
        {
            #region Заполнение сервисов

            _calculateService = calculateService;
            _calculateService.InputText = _inputText;

            #endregion

            #region Заполнение команд

            InputCharacterCommand = new MvxCommand<char>(
                p => {
                    if (SelLen == 0)
                    {
                        var startInd = SelStartInd;
                        InputText = InputText.Insert(startInd, $"{p}");
                    }
                    else
                    {
                        var startInd = SelStartInd;
                        var len = SelLen;
                        InputText = InputText.Insert(startInd + len, $"){p}");
                        InputText = InputText.Insert(startInd, "(");

                    }
                }
            );

            InputTrigCommand = new MvxCommand<string>(
                p => {
                    if (SelLen == 0) {
                        var startInd = SelStartInd;
                        InputText = InputText.Insert(startInd, $"{p}()");
                    }
                    else {
                        var startInd = SelStartInd;
                        var len = SelLen;
                        InputText = InputText.Insert(startInd + len, ")");
                        InputText = InputText.Insert(startInd, $"{p}(");
                        
                    }
                }
            );

            InputDelCommand = new MvxCommand(
                () => InputText = string.Empty,
                () => InputText.Length > 0
            );

            InputBackCommand = new MvxCommand(
                () => InputText = InputState//,
                //() => _inputStates.Count > 0
            );

            #endregion
        }
    }
}