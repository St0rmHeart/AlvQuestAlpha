namespace AlvQuestAlpha
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainPanel = new Panel();
            ArenaPanel = new Panel();
            TurnCounter = new Label();
            GridPanel = new Panel();
            CardPanel = new Panel();
            HealthPanel = new Panel();
            HealthLabel = new Label();
            NamePanel = new Panel();
            NameLabel = new Label();
            SpellPanel = new Panel();
            PerkPanel = new Panel();
            StatPanel = new Panel();
            StatElementPanel = new Panel();
            StatLabel = new Label();
            EquipmentPanel = new Panel();
            GoldExpPanel = new Panel();
            ManaPanel = new Panel();
            IconPanel = new Panel();
            IconPictureBox = new PictureBox();
            panel9 = new Panel();
            TopMenuPanel = new Panel();
            MainPanel.SuspendLayout();
            ArenaPanel.SuspendLayout();
            CardPanel.SuspendLayout();
            HealthPanel.SuspendLayout();
            NamePanel.SuspendLayout();
            StatPanel.SuspendLayout();
            StatElementPanel.SuspendLayout();
            IconPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(25, 23, 24);
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Controls.Add(ArenaPanel);
            MainPanel.Controls.Add(TopMenuPanel);
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1920, 1080);
            MainPanel.TabIndex = 0;
            // 
            // ArenaPanel
            // 
            ArenaPanel.Controls.Add(TurnCounter);
            ArenaPanel.Controls.Add(GridPanel);
            ArenaPanel.Controls.Add(CardPanel);
            ArenaPanel.Controls.Add(panel9);
            ArenaPanel.Location = new Point(2, 44);
            ArenaPanel.Margin = new Padding(1);
            ArenaPanel.Name = "ArenaPanel";
            ArenaPanel.Size = new Size(1914, 1032);
            ArenaPanel.TabIndex = 7;
            // 
            // TurnCounter
            // 
            TurnCounter.BorderStyle = BorderStyle.FixedSingle;
            TurnCounter.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TurnCounter.ForeColor = SystemColors.ControlLight;
            TurnCounter.Location = new Point(457, 1002);
            TurnCounter.Margin = new Padding(1);
            TurnCounter.Name = "TurnCounter";
            TurnCounter.Size = new Size(1000, 30);
            TurnCounter.TabIndex = 7;
            TurnCounter.Text = "Ход:";
            TurnCounter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridPanel
            // 
            GridPanel.BackgroundImageLayout = ImageLayout.Zoom;
            GridPanel.BorderStyle = BorderStyle.FixedSingle;
            GridPanel.Location = new Point(457, 0);
            GridPanel.Margin = new Padding(1);
            GridPanel.Name = "GridPanel";
            GridPanel.Size = new Size(1000, 1000);
            GridPanel.TabIndex = 6;
            // 
            // CardPanel
            // 
            CardPanel.BorderStyle = BorderStyle.FixedSingle;
            CardPanel.Controls.Add(HealthPanel);
            CardPanel.Controls.Add(NamePanel);
            CardPanel.Controls.Add(SpellPanel);
            CardPanel.Controls.Add(PerkPanel);
            CardPanel.Controls.Add(StatPanel);
            CardPanel.Controls.Add(EquipmentPanel);
            CardPanel.Controls.Add(GoldExpPanel);
            CardPanel.Controls.Add(ManaPanel);
            CardPanel.Controls.Add(IconPanel);
            CardPanel.Location = new Point(0, 0);
            CardPanel.Margin = new Padding(1);
            CardPanel.Name = "CardPanel";
            CardPanel.Padding = new Padding(1);
            CardPanel.Size = new Size(455, 1032);
            CardPanel.TabIndex = 1;
            // 
            // HealthPanel
            // 
            HealthPanel.BorderStyle = BorderStyle.FixedSingle;
            HealthPanel.Controls.Add(HealthLabel);
            HealthPanel.Location = new Point(291, 2);
            HealthPanel.Margin = new Padding(1);
            HealthPanel.Name = "HealthPanel";
            HealthPanel.Size = new Size(160, 52);
            HealthPanel.TabIndex = 4;
            // 
            // HealthLabel
            // 
            HealthLabel.Font = new Font("Century Gothic", 14F);
            HealthLabel.ForeColor = SystemColors.ControlLight;
            HealthLabel.Location = new Point(1, 1);
            HealthLabel.Margin = new Padding(1);
            HealthLabel.Name = "HealthLabel";
            HealthLabel.Size = new Size(156, 18);
            HealthLabel.TabIndex = 1;
            HealthLabel.Text = "105 / 120";
            HealthLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // NamePanel
            // 
            NamePanel.BorderStyle = BorderStyle.FixedSingle;
            NamePanel.Controls.Add(NameLabel);
            NamePanel.Location = new Point(2, 2);
            NamePanel.Margin = new Padding(1);
            NamePanel.Name = "NamePanel";
            NamePanel.Size = new Size(287, 52);
            NamePanel.TabIndex = 3;
            // 
            // NameLabel
            // 
            NameLabel.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NameLabel.ForeColor = SystemColors.ControlLight;
            NameLabel.Location = new Point(1, 1);
            NameLabel.Margin = new Padding(1);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(283, 48);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Тестовая надпись";
            NameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SpellPanel
            // 
            SpellPanel.BorderStyle = BorderStyle.FixedSingle;
            SpellPanel.Location = new Point(227, 561);
            SpellPanel.Margin = new Padding(1);
            SpellPanel.Name = "SpellPanel";
            SpellPanel.Size = new Size(224, 467);
            SpellPanel.TabIndex = 5;
            // 
            // PerkPanel
            // 
            PerkPanel.BorderStyle = BorderStyle.FixedSingle;
            PerkPanel.Location = new Point(227, 377);
            PerkPanel.Margin = new Padding(1);
            PerkPanel.Name = "PerkPanel";
            PerkPanel.Size = new Size(224, 182);
            PerkPanel.TabIndex = 4;
            // 
            // StatPanel
            // 
            StatPanel.BorderStyle = BorderStyle.FixedSingle;
            StatPanel.Controls.Add(StatElementPanel);
            StatPanel.Location = new Point(2, 561);
            StatPanel.Margin = new Padding(1);
            StatPanel.Name = "StatPanel";
            StatPanel.Size = new Size(224, 467);
            StatPanel.TabIndex = 4;
            // 
            // StatElementPanel
            // 
            StatElementPanel.Controls.Add(StatLabel);
            StatElementPanel.Location = new Point(0, 0);
            StatElementPanel.Margin = new Padding(0);
            StatElementPanel.Name = "StatElementPanel";
            StatElementPanel.Size = new Size(222, 60);
            StatElementPanel.TabIndex = 0;
            // 
            // StatLabel
            // 
            StatLabel.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            StatLabel.ForeColor = SystemColors.ControlLight;
            StatLabel.Location = new Point(0, 0);
            StatLabel.Name = "StatLabel";
            StatLabel.Size = new Size(222, 60);
            StatLabel.TabIndex = 0;
            StatLabel.Text = "Мастерство огня: 55\r\nБс.999% Дх.999% Сп.999%";
            StatLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EquipmentPanel
            // 
            EquipmentPanel.BorderStyle = BorderStyle.FixedSingle;
            EquipmentPanel.Location = new Point(2, 377);
            EquipmentPanel.Margin = new Padding(1);
            EquipmentPanel.Name = "EquipmentPanel";
            EquipmentPanel.Size = new Size(224, 182);
            EquipmentPanel.TabIndex = 3;
            // 
            // GoldExpPanel
            // 
            GoldExpPanel.BorderStyle = BorderStyle.FixedSingle;
            GoldExpPanel.Location = new Point(2, 345);
            GoldExpPanel.Margin = new Padding(1);
            GoldExpPanel.Name = "GoldExpPanel";
            GoldExpPanel.Size = new Size(449, 30);
            GoldExpPanel.TabIndex = 2;
            // 
            // ManaPanel
            // 
            ManaPanel.BorderStyle = BorderStyle.FixedSingle;
            ManaPanel.Location = new Point(291, 56);
            ManaPanel.Margin = new Padding(1);
            ManaPanel.Name = "ManaPanel";
            ManaPanel.Size = new Size(160, 287);
            ManaPanel.TabIndex = 1;
            // 
            // IconPanel
            // 
            IconPanel.BorderStyle = BorderStyle.FixedSingle;
            IconPanel.Controls.Add(IconPictureBox);
            IconPanel.Location = new Point(2, 56);
            IconPanel.Margin = new Padding(1);
            IconPanel.Name = "IconPanel";
            IconPanel.Size = new Size(287, 287);
            IconPanel.TabIndex = 0;
            // 
            // IconPictureBox
            // 
            IconPictureBox.Location = new Point(0, 0);
            IconPictureBox.Margin = new Padding(0);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(285, 285);
            IconPictureBox.TabIndex = 0;
            IconPictureBox.TabStop = false;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Location = new Point(1459, 0);
            panel9.Margin = new Padding(1);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(2);
            panel9.Size = new Size(455, 1032);
            panel9.TabIndex = 5;
            // 
            // TopMenuPanel
            // 
            TopMenuPanel.BorderStyle = BorderStyle.FixedSingle;
            TopMenuPanel.Location = new Point(2, 2);
            TopMenuPanel.Margin = new Padding(2);
            TopMenuPanel.Name = "TopMenuPanel";
            TopMenuPanel.Size = new Size(1914, 40);
            TopMenuPanel.TabIndex = 0;
            // 
            // SettingsForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1920, 1080);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            MainPanel.ResumeLayout(false);
            ArenaPanel.ResumeLayout(false);
            CardPanel.ResumeLayout(false);
            HealthPanel.ResumeLayout(false);
            NamePanel.ResumeLayout(false);
            StatPanel.ResumeLayout(false);
            StatElementPanel.ResumeLayout(false);
            IconPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private Panel TopMenuPanel;
        private Panel CardPanel;
        private Panel GoldExpPanel;
        private Panel ManaPanel;
        private Panel IconPanel;
        private Panel EquipmentPanel;
        private Panel panel9;
        private Panel GridPanel;
        private Panel SpellPanel;
        private Panel StatPanel;
        private Panel PerkPanel;
        private Panel ArenaPanel;
        private Label TurnCounter;
        private Panel HealthPanel;
        private Panel NamePanel;
        private Label NameLabel;
        private Label HealthLabel;
        private PictureBox IconPictureBox;
        private Panel StatElementPanel;
        private Label StatLabel;
    }
}