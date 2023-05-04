using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace СalculatorLib.ViewModels.Pages
{
    public class HomeViewModel : MvxViewModel
    {

        #region Поля ввод/вывод

        private string _inputText = "input";
        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        private string _outputText = "output";
        public string OutputText
        {
            get => _outputText;
            set => SetProperty(ref _outputText, value);
        }

        #endregion

        #region Команды

        public IMvxCommand InputCharacterCommand { get; }

        public IMvxCommand InputDelCommand { get; }

        #endregion

        public HomeViewModel()
        {
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