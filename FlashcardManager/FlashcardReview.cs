// Requirements - needs to receive Terms and TermsAndDefinitions lists
// Beyond that, this form should be set for testing
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
    public partial class FlashcardReview : Form
    {
        // Global variables to keep track of what's displayed
        private int CurrentCard = 0;
        private bool ShowingTerm = true;
        /* ShuffledTerms needs to be global because it's used on form load and for
         * every button besides btnReturn */
        private List<string> ShuffledTerms = new List<string>();

        public FlashcardReview()
        {
            InitializeComponent();
        }

        private void FlashcardReview_Load(object sender, EventArgs e)
        {
            /* These prevent the user from pressing a button that'll set the
             * CurrentCard tracker outside the boundaries of the lists */
            btnPrevious.Enabled = false;
            if (Terms.Count == 1)
            {
                btnNext.Enabled = false;
            }

            Random random = new Random();

            /* This is similar to the randomized quiz. However, I find it unnecessary to
             * randomize both the selected item and the placed index. You get similar results
             * by randomizing only one or the other */
            while (Terms.Count > 0)
            {
                int index = random.Next(Terms.Count);
                string term = Terms[index];
                ShuffledTerms.Add(term);
                Terms.RemoveAt(index);
            }
            
            // This sets the label to display the first term after they've been shuffled
            lblFlashcard.Text = ShuffledTerms[CurrentCard];
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            /* If you're looking at a term, it's only logical that you'd want the next
             * card to also be on the term side. Likewise for the definition side */
            if (ShowingTerm)
            {
                lblFlashcard.Text = ShuffledTerms[CurrentCard];
            }
            else
            {
                lblFlashcard.Text = TermsAndDefinitions[ShuffledTerms[CurrentCard]];
            }

            CurrentCard++;

            if (CurrentCard == ShuffledTerms.Count())
            {
                btnNext.Enabled = false;
            }
            /* I need to have this else statements in case the end of the list is reached and
             * the user decides to go back a card. Otherwise, btnNext is permanently disabled*/
            else
            {
                btnNext.Enabled = true;
            }
            // If you clicked btnNext, it's guaranteed you can click btnPrevious
            btnPrevious.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Was a lot easier than I expected to create a "Previous" button
            if (ShowingTerm)
            {
                lblFlashcard.Text = ShuffledTerms[CurrentCard];
            }
            else
            {
                lblFlashcard.Text = TermsAndDefinitions[ShuffledTerms[CurrentCard]];
            }

            CurrentCard--;

            if (CurrentCard == 0)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }
            // If you clicked btnPrevious, it's guaranteed you can click btnNext
            btnNext.Enabled = true;
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            /* A simple way to flip between term and definition. I'd normally leave the text
             * alignment centered, but I felt like changing with btnFlip it as a proof of concept*/
            if (ShowingTerm)
            {
                lblFlashcard.Text = TermsAndDefinitions[ShuffledTerms[CurrentCard]];

                // Autofill helped me find this one
                lblFlashcard.TextAlign = ContentAlignment.TopLeft;

                ShowingTerm = false;
            }
            else
            {
                lblFlashcard.Text = ShuffledTerms[CurrentCard];

                lblFlashcard.TextAlign = ContentAlignment.MiddleCenter;

                ShowingTerm = true;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
