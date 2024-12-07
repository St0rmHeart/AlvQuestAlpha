namespace AlvQuestAlpha.FrontEnd
{
    public class PerkEquipmentPanel : MoveableCustomPanel
    {
        private readonly PictureBox ImagePictureBox = new();
        private readonly Label NameLabel = new();

        public Image ObjImage
        {
            get => ImagePictureBox.Image;
            set => ImagePictureBox.Image = value;
        }
        public string ObjName
        {
            get => NameLabel.Text;
            set => NameLabel.Text = value;
        }
        public PerkEquipmentPanel()
        {
            Panel.BorderStyle = BorderStyle.None;

            ImagePictureBox.Location = new Point(1, 1);
            ImagePictureBox.Size = new Size(28, 28);
            ImagePictureBox.BackColor = Color.FromArgb(55, 22, 27);
            ImagePictureBox.BorderStyle = BorderStyle.FixedSingle;

            NameLabel.Location = new Point(33, 1);
            NameLabel.Size = new Size(186, 28);
            NameLabel.Font = new Font("Century Gothic", 13F);
            NameLabel.ForeColor = SystemColors.ControlLight;
            NameLabel.TextAlign = ContentAlignment.MiddleLeft;

            Panel.Controls.Add(ImagePictureBox);
            Panel.Controls.Add(NameLabel);
        }
    }
}
