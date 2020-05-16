using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashcardManager
{
    class Flashcard
    {
        public Flashcard(string term, string definition)
        {
            Term = term;
            Definition = definition;
        }

        public string Term { get; set; }
        public string Definition { get; set; }
        public List<string> TermList { get
            {
                List<string> termList = new List<string>();
                termList.Add(Term);

                return termList;
            } }
        public List<string> DefinitionList { get
            {
                List<string> definitionList = new List<string>();
                definitionList.Add(Definition);

                return definitionList;
            } }

        public override string ToString()   // return something human-readable 
        {
            return Term + " " + Definition; 
        }
    }
}
