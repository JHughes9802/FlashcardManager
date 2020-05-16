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
    public partial class FlashcardHome : Form
    {
        public SortedList<string, string> Test = new SortedList<string, string>();
        private List<Flashcard> Flashcards;
        public FlashcardHome()
        {
            InitializeComponent();

            // This is all testing in an attempt to figure out how Classes work with Lists and SortedLists
            // Sadly, I get garbage output
            // Do I need to use on overwrite?
            // I wish we didn't lose two weeks of class, so things could've been better covered
            Test.Add("cat", "meow");
            Test.Add("Horse", "neigh");

            string test1 = null;
            string test2 = null;

            foreach (string keys in Test.Keys)
            {
                string values = Test[keys];
                test1 = test1 + "\n" + keys;
                test2 = test2 + "\n" + values;
            }

            // displays as intended
            MessageBox.Show(test1, "test");
            MessageBox.Show(test2, "test");

            Flashcard test3 = new Flashcard("dog", "woof");
            Flashcard test4 = new Flashcard("pig", "oink");

            Flashcards = new List<Flashcard> { test3, test4 };

            string test5 = "";

            foreach (object item in Flashcards)
            {
                test5 = test5 + "\n" + item.ToString();
            }

            // doesn't display properly
            MessageBox.Show(test5, "test");

        }

        private void btnAddCards_Click(object sender, EventArgs e)
        {
            FlashcardAdd flashcardAdd = new FlashcardAdd();
            flashcardAdd.Tag = Test;
            flashcardAdd.ShowDialog();

            // Get the updated sortedlist 
            Test = (SortedList<string, string>)flashcardAdd.Tag;
            // Only testing to see if the flashcards are updated correctly
            MessageBox.Show(String.Join(", ", Test.Keys) + "\n" +String.Join(", ", Test.Values));
        }

        private void btnRemoveCards_Click(object sender, EventArgs e)
        {
            FlashcardRemove flashcardRemove = new FlashcardRemove();
            flashcardRemove.ShowDialog();
        }

        private void btnReviewCards_Click(object sender, EventArgs e)
        {
            FlashcardReview flashcardReview = new FlashcardReview();
            flashcardReview.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
