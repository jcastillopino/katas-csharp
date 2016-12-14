using System;

namespace KataBank {
    internal class EmptyDate : IDate {
        public DateTime Now() {
            return DateTime.Now;
        }
    }
}