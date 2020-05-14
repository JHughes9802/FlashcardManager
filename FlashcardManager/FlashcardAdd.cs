// Requirements - needs to receive Terms and TermsAndDefinitions lists
// Also need to set up the cancel button
// After that, test to make sure things work as intended
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashcardManager
{
    public partial class FlashcardAdd : Form
    {
        // A bool to keep track of whether or not a message should be displayed if btnCancel is clicked
        private bool AddClicked = false;
        // Copies of the lists - don't want to have the real ones replaced if the user clicks cancel
        List<string> TermsCopy = new List<string>();
        SortedList<string, string> TermsAndDefinitionsCopy = new SortedList<string, string>();

        public FlashcardAdd()
        {
            InitializeComponent();

            foreach (string term in TermsAndDefinitions.Keys)
            {
                TermsCopy.Add(term);
                // If things don't look right in FlashcardReview, this is like likely the cause
                TermsAndDefinitionsCopy.Add(term, TermsAndDefinitions[term]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string term = txtTerm.Text.Trim();
            string definition = txtDefinition.Text.Trim();

            if (ValidData(term, definition, out string textErrorMessage))
            {
                TermsCopy.Add(term);
                TermsAndDefinitionsCopy.Add(term, definition);

                txtTerm.Clear();
                txtDefinition.Clear();

                AddClicked = true;
            }
            else
            {
                MessageBox.Show(textErrorMessage, "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Make sure this properly updates by checking in FlashcardReview
            Terms = TermsCopy;
            TermsAndDefinitions = TermsAndDefinitionsCopy;
        }

        // Set this to discard changes if the user clicks "yes" when prompted
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (AddClicked)
            {

            }

            Close();
        }

        private bool ValidData(string term, string definition, out string errorMessage)
        {
            errorMessage = null;

            if (String.IsNullOrEmpty(term))
            {
                errorMessage = "Please enter a term.";
                txtTerm.Focus();
                return false;
            }
            else
            {
                if (term.Length == 1)
                {
                    errorMessage = "Please enter a term longer than 1 character.";
                    txtTerm.Focus();
                    return false;
                }
                else
                {
                    foreach (string termCopy in TermsCopy)
                    {
                        if (term.ToUpper() == termCopy.ToUpper())
                        {
                            errorMessage = "You can't add a term that's already added.";
                            txtTerm.Focus();
                            return false;
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(definition))
            {
                errorMessage = "Please enter a definition.";
                txtDefinition.Focus();
                return false;
            }
            else
            {
                // I considered leaving this out in case these flashcards were used for math, but it felt wrong
                if (definition.Length < 10)
                {
                    errorMessage = "The definition must be at least 10 characters long.";
                    txtDefinition.Focus();
                    return false;
                }
            }

            return true;
        }
    }
}
