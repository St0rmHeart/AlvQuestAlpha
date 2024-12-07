namespace AlvQuestAlpha.FrontEnd
{
    public class CardPanel : MoveableCustomPanel
    {
        //Панели-контейнеры для остальных элементов
        private readonly NamePanel NamePanel = new();
        private readonly HealthPanel HealthPanel = new();
        private readonly IconPanel IconPanel = new();
        private readonly ManaPanel ManaPanel = new();
        private readonly GoldExpPanel GoldExpPanel = new();
        private readonly EquipmentPanel EquipmentPanel = new();
        private readonly PerkPanel PerkPanel = new();
        private readonly StatPanel StatPanel = new();
        private readonly SpellPanel SpellPanel = new();

        public CardPanel()
        {
            NamePanel.AddPanelToControls(Panel);
            HealthPanel.AddPanelToControls(Panel);
            IconPanel.AddPanelToControls(Panel);
            ManaPanel.AddPanelToControls(Panel);
            GoldExpPanel.AddPanelToControls(Panel);
            EquipmentPanel.AddPanelToControls(Panel);
            PerkPanel.AddPanelToControls(Panel);
            StatPanel.AddPanelToControls(Panel);
            SpellPanel.AddPanelToControls(Panel);
        }
    }
}
