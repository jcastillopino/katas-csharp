using Xunit;

namespace KataPrintDate.Tests {
    public class PrintDateTest {

        [Fact]
        public void PrintDate_Executed_PrintCurrentDate() {
            var writerDouble = new WriterDouble();
            var printDate = new PrintDate(writerDouble);

            printDate.PrintCurrentDate();

            Assert.True(writerDouble.WasWriteLineExecuted());
        }

        [Fact]
        public void NowDouble_ValueOf_Now() {
            var nowDouble = new NowDouble("Hola Stub");

            var result = nowDouble.Now();

            Assert.Equal("Hola Stub", result);
        }
    }
}
