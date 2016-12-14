using System;

namespace KataPrintDate {
    public class PrintDate {
        private readonly IWriteLine _writeLine;

        public PrintDate(IWriteLine writeLine) {
            _writeLine = writeLine;
        }

        public void PrintCurrentDate() {
            _writeLine.WriteLine(DateTime.Now.ToLongDateString());
        }

    }
}
