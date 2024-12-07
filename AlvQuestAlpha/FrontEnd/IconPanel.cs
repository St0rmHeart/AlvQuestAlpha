namespace AlvQuestAlpha.FrontEnd
{
    public class IconPanel : CustomPanel
    {
        private readonly PictureBox IconPictureBox = new();

        public IconPanel()
        {
            IconPictureBox.Location = new Point(0, 0);
            IconPictureBox.Size = new Size(285, 285);
            IconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        public Image Icon
        {
            get => IconPictureBox.Image;
            set => IconPictureBox.Image = value;
        }
    }
}
