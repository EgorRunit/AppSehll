using System.Collections.Generic;

namespace AppShell.Controls
{
    /// <summary>
    /// РРЅС‚РµСЂС„РµР№СЃ РѕРїРёСЃС‹РІР°РµС‚ СЌРµР»РµРјРµРЅС‚ РїСЂРёР»РёРїР°СЋС‰РµР№ РїР°РЅРµР»Рё.
    /// </summary>
    public interface ISnapPanelChild
    {
        /// <summary>
        /// РЎСЃР»С‹РєР° РЅР° РЅР° РІР»Р°РґРµР»СЊС†Р° (ISnapPanel) СЌР»РµРјРµРЅС‚Р°.
        /// </summary>
        ISnapPanel Parent { get; set; }
        /// <summary>
        /// РЎСЃС‹Р»РєР° РЅ РїРѕС‚РѕРјРєР° (ISnapPanel) СЌР»РµРјРµРЅС‚Р°.
        /// </summary>
        ISnapPanel Child { get; set; }
        /// <summary>
        /// РўРёРї РёР·РјРµСЂРµРЅРёСЏ РґР»СЏ СЌР»РµРјРµРЅС‚Р°.
        /// </summary>
        SnapSize SnapSize { get; set; }
        /// <summary>
        /// РўРёРї СЃРѕРґРµСЂР¶РёРјРѕРіРѕ СЌР»РµРјРµРЅС‚Р°.
        /// </summary>
        SnapChildType Type { get; set; }
        /// <summary>
        /// РЎРїРёСЃРѕРє СЃРѕРґРµСЂР¶Р°С‰РёС…СЃСЏ СЌР»РµРјРµРЅС‚РѕРІ СЃС‚РѕСЂРѕРЅРЅРёС… СЌР»РµРјРµРЅС‚РѕРІ СѓРїСЂР°РІР»РµРЅРёСЏ.
        /// </summary>
        List<ISnapChildControl> Controls { get; set; }

        void AddPanel(SnapPanelType snapPanelType, ISnapChildControl snapControl);
    }
}
