namespace KataPrintDate
{
    public class NowDouble : INow {
        private readonly string _value;

        public NowDouble(string value) {
            _value = value;
        }

        public string Now() {
            return _value;
        }
    }
}