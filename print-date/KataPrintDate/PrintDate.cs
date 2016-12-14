using System;

namespace KataPrintDate {
    public class PrintDate {
        private readonly IWriteLine _writeLine;
        private readonly INow _now;

        public PrintDate(IWriteLine writeLine, INow now)
        {
            _writeLine = writeLine;
            _now = now;
        }

        public void PrintCurrentDate() {
            _writeLine.WriteLine(_now.Now());
        }

    }
}
