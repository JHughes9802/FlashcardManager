// Requirements - needs to receive Terms and TermsAndDefinitions lists
// Also need to set up the cancel button
// Also need to set up the event to display the highlighted term's definition whenever the checked status changes
// I could instead set the event to display the highlighted term's definition whenever highlight changes though, right?
// Which would work better? (need to test)
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
    public partial class FlashcardRemove : Form
    {
        // A bool to keep track of whether or not a message should be displayed if btnCancel is clicked
        private bool RemoveClicked = false;
        // Copies of the lists - don't want to have the real ones replaced if the user clicks cancel
        List<string> TermsCopy = new List<string>();
        SortedList<string, string> TermsAndDefinitionsCopy = new SortedList<string, string>();

        public FlashcardRemove()
        {
            InitializeComponent();

            foreach (string term in TermsAndDefinitions.Keys)
            {
                clsTerm.Items.Add(term);
                TermsCopy.Add(term);
                // If things don't display as intended, this is like likely the cause
                TermsAndDefinitionsCopy.Add(term, TermsAndDefinitions[term]);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (BoxChecked())
            {
                int itemChecker = 0;

                // This needs testing.
                // Will it break if the last item is checked along with numerous others?
                // If it does, the if statement needs to be changed or removed
                foreach (string term in clsTerm.Items)
                {
                    if (clsTerm.GetItemChecked(itemChecker))
                    {
                        TermsCopy.Remove(term);
                        TermsAndDefinitionsCopy.Remove(term);
                        clsTerm.Items.Remove(term);
                    }

                    itemChecker++;
                }

                RemoveClicked = true;
            }
            else
            {
                MessageBox.Show("You must select an item to delete something.", "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Make sure this is works as intended once the Class gets figured out
            Terms = TermsCopy;
            TermsAndDefinitions = TermsAndDefinitionsCopy;
        }

        // Set this to discard changes if the user clicks "yes" when prompted
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (RemoveClicked)
            {

            }

            Close();
        }

        // A simple method to ensure at least 1 box is checked
        private bool BoxChecked()
        {
            int itemChecker = 0;

            foreach (string term in clsTerm.Items)
            {
                if (clsTerm.GetItemChecked(itemChecker))
                {
                    return true;
                }

                itemChecker++;
            }

            return false;
        }

        /* I originally had this, but soon found out the ItemChecked event for the CheckedListBox
         * fires BEFORE the check status changes, so I had to change it to what's above */
        /* This is the best way I could think of to disable the btnRemove when
         * all boxes are unchecked */
        /*private void CheckChanged(object sender, EventArgs e)
        {
            bool boxChecked = false;
            int itemChecker = 0;
            foreach(string term in clsTerm.Items)
            {
                if (clsTerm.GetItemChecked(itemChecker))
                {
                    boxChecked = true;
                    break;
                }

                itemChecker++;
            }

            if (boxChecked)
            {
                btnRemove.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
            }
        }*/
    }
}
