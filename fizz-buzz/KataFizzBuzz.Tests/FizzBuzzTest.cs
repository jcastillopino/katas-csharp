using System;
using System.Collections.Generic;
using Xunit;

namespace KataFizzBuzz.Tests {
    public class FizzBuzzTest {
        private IList<string> ProcessNumbersFrom1To100() {
            var fizzBuzz = new FizzBuzz(1, 100);
            return fizzBuzz.ProcessNumbers();
        }

        [Fact]
        public void my_first_test() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("1", result[0]);
        }

        [Fact]
        public void FizzBuzz_2_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("2", result[1]);
        }

        [Fact]
        public void FizzBuzz_3_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Fizz", result[2]);
        }

        [Fact]
        public void FizzBuzz_5_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Buzz", result[4]);
        }

        [Fact]
        public void FizzBuzz_6_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Fizz", result[5]);
        }

        [Fact]
        public void FizzBuzz_10_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Buzz", result[9]);
        }

        [Fact]
        public void FizzBuzz_15_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("FizzBuzz", result[14]);
        }

        [Fact]
        public void FizzBuzz_outOfRange_ok() {
            var result = ProcessNumbersFrom1To100();
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => result[100]);
        }

        [Fact]
        public void FizzBuzz_13_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Fizz", result[12]);
        }

        [Fact]
        public void FizzBuzz_30_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("FizzBuzz", result[29]);
        }

        [Fact]
        public void FizzBuzz_31_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Fizz", result[30]);
        }

        [Fact]
        public void FizzBuzz_33_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Fizz", result[32]);
        }

        [Fact]
        public void FizzBuzz_35_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("FizzBuzz", result[34]);
        }

        [Fact]
        public void FizzBuzz_51_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("FizzBuzz", result[50]);
        }

        [Fact]
        public void FizzBuzz_52_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("Buzz", result[51]);
        }

        [Fact]
        public void FizzBuzz_53_ok() {
            var result = ProcessNumbersFrom1To100();
            Assert.Equal("FizzBuzz", result[52]);
        }
    }
}
