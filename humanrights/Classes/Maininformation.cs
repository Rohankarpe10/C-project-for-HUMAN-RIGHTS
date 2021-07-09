using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace humanrights.Classes
{
    public class Maininformation
    {
        public ObservableCollection<Information> Intro { get; set; }
        public ObservableCollection<Information> UniversalDeclaration { get; set; }
        public ObservableCollection<Information> Htypes { get; set; }
        public ObservableCollection<Information> Types { get; set; }
    }
}
