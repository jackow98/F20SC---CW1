﻿using System.Windows.Forms;
using Browser;

namespace Coursework.GUI
{
    public static class EditFavouritePopUp
    {
        public static HTMLPage ShowDialog(string caption, string nameDisplayText = "", string urlDisplayText = "")
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
            var urlLabel = new Label {Left = 50, Top = 80, Text = "URL: ", Width = 50};
            var nameTextBox = new TextBox {Left = 110, Top = 50, Width = 350, Text = nameDisplayText};
            var urlTextBox = new TextBox {Left = 110, Top = 80, Width = 350, Text = urlDisplayText};
            var confirmation = new Button
                {Text = "Add", Left = 350, Width = 100, Top = 130, DialogResult = DialogResult.OK};
            confirmation.Click += (sender, e) => { sddFavouritePopUp.Close(); };
            sddFavouritePopUp.Controls.Add(nameLabel);
            sddFavouritePopUp.Controls.Add(urlLabel);
            sddFavouritePopUp.Controls.Add(confirmation);
            sddFavouritePopUp.Controls.Add(nameTextBox);
            sddFavouritePopUp.Controls.Add(urlTextBox);
            sddFavouritePopUp.AcceptButton = confirmation;

            return sddFavouritePopUp.ShowDialog() == DialogResult.OK
                ? new HTMLPage(urlTextBox.Text, nameTextBox.Text, "", "")
                : null;
        }
    }
}