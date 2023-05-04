using СalculatorLib.Services.Interfaces;

namespace СalculatorLib.Services
{
    public class CalculateService : ICalculateService
    {
        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                _outputText = Calculate(_inputText);
            }
        }

        private string _outputText;
        public string OutputText => _outputText;

        private string Calculate(string value)
        {
            //TODO: здесь нужно описать логику вычисления
            return value;
        }
    }
}