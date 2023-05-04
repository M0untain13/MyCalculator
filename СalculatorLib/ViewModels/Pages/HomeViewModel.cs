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

        private string _inputText = "input";
        public string InputText
        {
            get => _inputText;
            set
            {
                if (SetProperty(ref _inputText, value))
                {
                    _calculateService.InputText = _inputText;
                    RaisePropertyChanged(nameof(OutputText));
                }
            }
        }

        public string OutputText => _calculateService.OutputText;

        #endregion

        #region Команды

        public IMvxCommand InputCharacterCommand { get; }

        public IMvxCommand InputDelCommand { get; }

        #endregion

        public HomeViewModel(ICalculateService calculateService)
        {
            #region Заполнение сервисов

            _calculateService = calculateService;

            #endregion

            #region Заполнение команд

            InputCharacterCommand = new MvxCommand<char>(
                p => InputText += p
            );

            InputDelCommand = new MvxCommand(
                () => InputText = InputText.Substring(0, InputText.Length-1),
                () => InputText.Length > 0
            );

            #endregion
        }
    }
}