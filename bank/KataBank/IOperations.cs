using System;
using System.Collections;
using System.Collections.Generic;

namespace KataBank
{
    public interface IOperations {
        void Withdraw(int amount);
        void Deposit(int amount);
        int Balance();
        Stack<Operation> GetHistory();
    }
}