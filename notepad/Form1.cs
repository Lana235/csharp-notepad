using System.Diagnostics;
using System.Drawing.Printing;
using static System.Net.WebRequestMethods;

namespace notepad
{
    public partial class Form1 : Form
    {
        string Path = ""; //used to store location of file
        public Form1()
        {
            InitializeComponent();
        }
        #region Trash
        private void ctrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //removed this shit
        }
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //removed this too
        }
        private void searchWithBingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void statusBarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //wtf is that even...
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region FILE
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        Path = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        richTextBox1.Text = text.Result;
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Path))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Textdocument|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLineAsync(richTextBox1.Text);
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    sw.WriteLineAsync(richTextBox1.Text);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Textdocument|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLineAsync(richTextBox1.Text);
                    }
                }
            }
        }



        private void peintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //print code 
            printPreviewDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region EDIT
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currentTimeDate = DateTime.Now.ToString("hh:mm tt MM/dd/yyyy");
            Clipboard.SetText(currentTimeDate);
            MessageBox.Show("ახლანდელი დრო და თარიღი ^^", currentTimeDate);
        }
        #endregion

        #region FORMAT
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
        }
        #endregion

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 12, 10);
        }
        
        #region VIEW
        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currentSize;
            currentSize = richTextBox1.Font.Size;
            currentSize += 2.0F;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }


        #endregion

        #region HELP
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string videoUrl = "https://www.youtube.com/watch?v=gEJ-hBbsaC8";
            try
            {
                // Start a new process to open the default browser with the video URL
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = videoUrl,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("An error occurred while opening the YouTube video: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creator Is Dumb!");
        }
        #endregion

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
