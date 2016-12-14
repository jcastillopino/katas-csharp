namespace KataPrintDate {
    public class PrintDateDouble {

        private readonly PrintDate _printDate;

        public PrintDateDouble(PrintDate printDate) {
            _printDate = printDate;
        }

        public void Run() {
            _printDate.PrintCurrentDate();
        }
    }
}