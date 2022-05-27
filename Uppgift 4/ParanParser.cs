using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_4
{
    internal class ParanParser {

        private List<string> report;
        private Stack<Char> lParans;
        private string input;

        public ParanParser() {
            report = new List<string>();
            lParans = new Stack<char>();
        }

        private List<string> Parse() {

            foreach (char c in input) {
                switch (c) {
                    case '(':
                    case '{':
                    case '[':
                    case '<':
                        lParans.Push(c);
                        break;

                    case ')':
                        MatchAndReport(expected: '(', c);
                        break;

                    case '}':
                        MatchAndReport(expected: '{', c);
                        break;

                    case ']':
                        MatchAndReport(expected: '[', c);
                        break;

                    case '>':
                        MatchAndReport(expected: '<', c);
                        break;
                }
            }

            if (lParans.Count != 0) {

                while (lParans.Count != 0) {
                    Char p = lParans.Pop();
                    report.Add($"Error: no matching closing parenthesis to \'{p}\'");
                }
            }

            if(report.Count == 0) {
                report.Add("Correct!");
            }

            return report;
        }

        public List<string> Parse(string input) {
            this.input = input;
            report.Clear();
            lParans.Clear();

            return this.Parse();
        }

        // helper function, testing and reporting
        private void MatchAndReport(Char expected, Char closing) {

            if (lParans.Count == 0) {
                report.Add($"Error: no matching \'{expected}\' found");
            }
            else {
                Char paren = lParans.Pop();
                if (paren != expected) {
                    report.Add($"Error: \'{paren}\' does not match \'{closing}\'");
                }
            }
        }


    }
}











//}
