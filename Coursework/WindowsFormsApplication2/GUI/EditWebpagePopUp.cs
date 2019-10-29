using System.Windows.Forms;
using Browser;

namespace Coursework.GUI
{
    public static class EditWebpagePopUp
    {
        public static HTMLPage ShowDialog(string caption, string nameDisplayText = null, string urlDisplayText = null)
        {
            var sddFavouritePopUp = new Form
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            var nameLabel = new Label {Left = 50, Top = 50, Text = "Name: ", Width = 50};
            var nameTextBox = new TextBox {Left = 110, Top = 50, Width = 350, Text = nameDisplayText};
            var urlLabel = new Label {Left = 50, Top = 80, Text = "URL: ", Width = 50};
            var urlTextBox = new TextBox {Left = 110, Top = 80, Width = 350, Text = urlDisplayText};
            
            if (nameDisplayText != null)
            {
                sddFavouritePopUp.Controls.Add(nameLabel);
                sddFavouritePopUp.Controls.Add(nameTextBox);
            }

            if (urlDisplayText != null)
            {
                sddFavouritePopUp.Controls.Add(urlLabel);
                sddFavouritePopUp.Controls.Add(urlTextBox);
            }
            
            var confirmation = new Button
                {Text = "Add", Left = 350, Width = 100, Top = 130, DialogResult = DialogResult.OK};
            confirmation.Click += (sender, e) => { sddFavouritePopUp.Close(); };

            sddFavouritePopUp.Controls.Add(confirmation);
            sddFavouritePopUp.AcceptButton = confirmation;

            return sddFavouritePopUp.ShowDialog() == DialogResult.OK
                ? new HTMLPage(
                    nameDisplayText == null ? "" : urlTextBox.Text, 
                    nameDisplayText == null ? "" : nameTextBox.Text, 
                    "", 
                    ""
                    )
                : null;
        }
    }
}