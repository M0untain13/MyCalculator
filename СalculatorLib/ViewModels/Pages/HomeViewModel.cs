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
                }
            }
        }

        public string OutputText => _calculateService.OutputText;

        public string OutputTip => _calculateService.GetMessageAboutError();

        #endregion

        #region Команды

        public IMvxCommand InputCharacterCommand { get; }

        public IMvxCommand InputDelCommand { get; }

        #endregion

        public HomeViewModel(ICalculateService calculateService)
        {
            #region Заполнение сервисов

            _calculateService = calculateService;
            _calculateService.InputText = _inputText;

            #endregion

            #region Заполнение команд

            InputCharacterCommand = new MvxCommand<char>(
                p => InputText += p
            );

            InputDelCommand = new MvxCommand(
                () => InputText = string.Empty,
                () => InputText.Length > 0
            );

            #endregion
        }
    }
}