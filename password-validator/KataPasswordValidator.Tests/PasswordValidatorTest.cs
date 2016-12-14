using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KataPasswordValidator.Tests {
    public class PasswordValidatorTest {
        private static PasswordValidator _validator;

        public PasswordValidatorTest() {
            _validator = new PasswordValidator();
        }

        private static bool ValidatePassword(string password) {
            return _validator.IsValid(password);
        }

        [Fact]
        public void Passwor_Lesser_Than_8_Char_Incorrect() {
            Assert.False(ValidatePassword("123"));
        }

        [Fact]
        public void Password_With_Ok() {
            Assert.True(ValidatePassword("123_56aC"));
        }

        [Fact]
        public void Password_Without_Capital_Incorrect() {
            Assert.False(ValidatePassword("asd1_fes"));
        }

        [Fact]
        public void Password_Without_LowerCase_Incorrect() {
            Assert.False(ValidatePassword("CCCC1_CCC"));
        }

        [Fact]
        public void Password_Without_Number_Incorrect() {
            Assert.False(ValidatePassword("CaCCd_CCC"));
        }

        [Fact]
        public void Password_Without_Underscore_Incorrect() {
            Assert.False(ValidatePassword("CaCCd2CCC"));
        }
    }
}
