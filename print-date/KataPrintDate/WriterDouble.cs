namespace KataPrintDate
{
    public class WriterDouble : IWriteLine {
        private bool _executed;
        private string _valuePrinted;

        public bool WasWriteLineExecuted() {
            return _executed;
        }

        public WriterDouble() {
            _executed = false;
        }

        public void WriteLine(string text) {
            _executed = true;
            _valuePrinted = text;
        }

        public string ValueLastPrinted => _valuePrinted;
    }
}