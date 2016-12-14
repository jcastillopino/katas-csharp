using NSubstitute;
using Xunit;

namespace KataPrintDate.Tests {
    public class PrintDateTest
    {

        [Fact]
        public void PrintDate_Executed_PrintCurrentDate()
        {
            var writerDouble = new WriterDouble();
            var nowDouble = new NowDouble("Hola Stub");
            var printDate = new PrintDate(writerDouble, nowDouble);

            printDate.PrintCurrentDate();

            Assert.True(writerDouble.WasWriteLineExecuted());
        }

        [Fact]
        public void NowDouble_ValueOf_Now()
        {
            var nowDouble = new NowDouble("Hola Stub");

            var result = nowDouble.Now();

            Assert.Equal("Hola Stub", result);
        }

        [Fact]
        public void PrintDate_Returns_Now_Ok()
        {
            var nowDouble = new NowDouble("Hola Stub");
            var writerDouble = new WriterDouble();
            var printDate = new PrintDate(writerDouble, nowDouble);

            printDate.PrintCurrentDate();

            var result = writerDouble.ValueLastPrinted;
            Assert.Equal("Hola Stub", result);
        }

        [Fact]
        public void PrintDate_Executed_PrintCurrentDate_Using_NSubstitute()
        {
            var writerDouble = Substitute.For<IWriteLine>();
            var nowDouble = Substitute.For<INow>();
            var printDate = new PrintDate(writerDouble, nowDouble);

            printDate.PrintCurrentDate();
        
            writerDouble.Received().WriteLine(nowDouble.Now());
            nowDouble.Received().Now();
        }
    }
}
