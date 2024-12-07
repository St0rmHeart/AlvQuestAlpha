using AlvQuestCore;

namespace AlvQuestAlpha.FrontEnd
{
    public class PerkPanel : CustomPanel
    {
        private const int EquipmentCount = 6;
        private readonly PerkEquipmentPanel[] EquipmentPanels = new PerkEquipmentPanel[EquipmentCount];

        public PerkPanel()
        {
            for (int i = 0; i < EquipmentCount; i++)
            {
                var pePanel = new PerkEquipmentPanel();
                pePanel.PanelLocation = new Point(0, 30 * i);
                pePanel.AddPanelToControls(Panel);
                EquipmentPanels[i] = pePanel;
            }
        }

        public PerkEquipmentPanel this[int perkNum]
        {
            get => EquipmentPanels[perkNum];
        }
    }
}
