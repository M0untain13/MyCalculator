using System.Globalization;
using org.mariuszgromada.math.mxparser;
using СalculatorLib.Services.Interfaces;

namespace СalculatorLib.Services
{
    public class CalculateService : ICalculateService
    {
        static CalculateService()
        {
            License.iConfirmNonCommercialUse("");
        }

        private Expression _expression = new("");

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
            _expression = new Expression(value);
            if (_expression.checkSyntax())
                return _expression.calculate().ToString(CultureInfo.CurrentCulture);
            return "Ошибка";
        }

        public string GetMessageAboutError()
        { 
            return _expression.getErrorMessage();
        }

        // private async Task<string> GetTranslateTask() 
    }
}