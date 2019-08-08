using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Web.Extensions.Constants
{
    /// <summary>
    /// Localization constants
    /// </summary>
    public class LocalizationConstants
    {
        /// <summary>
        /// Constants for Russian
        /// </summary>
        public static Dictionary<string, string> Ru = new Dictionary<string, string>()
        {
            { "Model.Area.Display.Name", "Наименование"},
            { "Model.Area.Display.InventoryNum", "Инвентарный номер"},
            { "Model.Area.Display.CadastralNum", "Кадастровый номер"},
            { "Model.Area.Display.AreaTypeId", "Тип"},
            { "Model.Area.Display.AreaType", "Тип"},
            { "Model.Area.Display.AreaOwnershipTypeId", "Вид права"},
            { "Model.Area.Display.AreaOwnershipType", "Вид права"},
            { "Model.Area.Display.Document", "Правоустанавливающий документ"},
            { "Model.Area.Display.FileDetail", "Файл"},

            { "Common.Select.File", "Выбрать"},
            { "Common.Button.Download.Text", "Скачать"},

            { "Area.Editor.Title", "Карточка объекта"},

            { "Area.Polygon.Button.Save.Text", "Сохранить полигон"},

            { "Model.Area.Required.Name", "[Наименование]: обязательно для заполнения!"},
            { "Model.Area.Required.CadastralNum", "[Кадастровый номер]: обязательно для заполнения!"},
        };
    }
}
