using System;

namespace KataBank {
    public class CustomDate : IDate {
        public DateTime Now() {
            return DateTime.Now.Date;
        }
    }
}