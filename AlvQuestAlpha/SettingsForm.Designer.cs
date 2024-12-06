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
            GridPanel = new Panel();
            ArenaPanel = new Panel();
            CardPanel = new Panel();
            SpellPanel = new Panel();
            PerkPanel = new Panel();
            StatPanel = new Panel();
            EquipmentPanel = new Panel();
            GoldExpPanel = new Panel();
            ManaPanel = new Panel();
            IconPanel = new Panel();
            panel9 = new Panel();
            TopMenuPanel = new Panel();
            MainPanel.SuspendLayout();
            ArenaPanel.SuspendLayout();
            CardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(25, 23, 24);
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Controls.Add(GridPanel);
            MainPanel.Controls.Add(ArenaPanel);
            MainPanel.Controls.Add(TopMenuPanel);
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1920, 1080);
            MainPanel.TabIndex = 0;
            // 
            // GridPanel
            // 
            GridPanel.BackgroundImageLayout = ImageLayout.Zoom;
            GridPanel.BorderStyle = BorderStyle.FixedSingle;
            GridPanel.Location = new Point(459, 44);
            GridPanel.Margin = new Padding(2);
            GridPanel.Name = "GridPanel";
            GridPanel.Size = new Size(1000, 1000);
            GridPanel.TabIndex = 6;
            // 
            // ArenaPanel
            // 
            ArenaPanel.Controls.Add(CardPanel);
            ArenaPanel.Controls.Add(panel9);
            ArenaPanel.Location = new Point(2, 44);
            ArenaPanel.Margin = new Padding(1);
            ArenaPanel.Name = "ArenaPanel";
            ArenaPanel.Size = new Size(1914, 1032);
            ArenaPanel.TabIndex = 7;
            // 
            // CardPanel
            // 
            CardPanel.BorderStyle = BorderStyle.FixedSingle;
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
            // SpellPanel
            // 
            SpellPanel.BorderStyle = BorderStyle.FixedSingle;
            SpellPanel.Location = new Point(227, 559);
            SpellPanel.Margin = new Padding(1);
            SpellPanel.Name = "SpellPanel";
            SpellPanel.Size = new Size(224, 469);
            SpellPanel.TabIndex = 5;
            // 
            // PerkPanel
            // 
            PerkPanel.BorderStyle = BorderStyle.FixedSingle;
            PerkPanel.Location = new Point(227, 333);
            PerkPanel.Margin = new Padding(1);
            PerkPanel.Name = "PerkPanel";
            PerkPanel.Size = new Size(224, 224);
            PerkPanel.TabIndex = 4;
            // 
            // StatPanel
            // 
            StatPanel.BorderStyle = BorderStyle.FixedSingle;
            StatPanel.Location = new Point(2, 559);
            StatPanel.Margin = new Padding(1);
            StatPanel.Name = "StatPanel";
            StatPanel.Size = new Size(224, 469);
            StatPanel.TabIndex = 4;
            // 
            // EquipmentPanel
            // 
            EquipmentPanel.BorderStyle = BorderStyle.FixedSingle;
            EquipmentPanel.Location = new Point(2, 333);
            EquipmentPanel.Margin = new Padding(1);
            EquipmentPanel.Name = "EquipmentPanel";
            EquipmentPanel.Size = new Size(224, 224);
            EquipmentPanel.TabIndex = 3;
            // 
            // GoldExpPanel
            // 
            GoldExpPanel.BorderStyle = BorderStyle.FixedSingle;
            GoldExpPanel.Location = new Point(2, 291);
            GoldExpPanel.Margin = new Padding(1);
            GoldExpPanel.Name = "GoldExpPanel";
            GoldExpPanel.Size = new Size(449, 40);
            GoldExpPanel.TabIndex = 2;
            // 
            // ManaPanel
            // 
            ManaPanel.BorderStyle = BorderStyle.FixedSingle;
            ManaPanel.Location = new Point(291, 2);
            ManaPanel.Margin = new Padding(1);
            ManaPanel.Name = "ManaPanel";
            ManaPanel.Size = new Size(160, 287);
            ManaPanel.TabIndex = 1;
            // 
            // IconPanel
            // 
            IconPanel.BorderStyle = BorderStyle.FixedSingle;
            IconPanel.Location = new Point(2, 2);
            IconPanel.Margin = new Padding(1);
            IconPanel.Name = "IconPanel";
            IconPanel.Size = new Size(287, 287);
            IconPanel.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Location = new Point(1459, 0);
            panel9.Margin = new Padding(2);
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
    }
}