using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace humanrights.Classes
{
    public class Quiz
    {
        public int quizId { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public bool correct { get; set; }
    }
}
