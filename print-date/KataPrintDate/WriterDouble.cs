namespace KataPrintDate
{
    public class WriterDouble : IWriteLine {
        private bool _executed;

        public bool WasWriteLineExecuted() {
            return _executed;
        }

        public WriterDouble() {
            _executed = false;
        }

        public void WriteLine(string text) {
            _executed = true;
        }
    }
}