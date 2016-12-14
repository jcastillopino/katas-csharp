using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBank {
    public interface IPrinter {
        void Print(Stack<Operation> history);
        void PrintLine(string line);
    }
}
