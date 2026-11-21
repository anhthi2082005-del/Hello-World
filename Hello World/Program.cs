using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hello_World
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Program : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            if (uidoc == null)
            {
                MessageBox.Show("Vui lòng mở một dự án Revit trước khi chạy lệnh!");
                return Result.Cancelled;
            }

            ICollection<ElementId> selectElement = uidoc.Selection.GetElementIds();
            int totalCount = selectElement.Count;

            MessageBox.Show("Bạn đã chọn " + totalCount + " đối tượng.");

            // Phát triển code: Liệt kê ID các đối tượng được chọn
            if (totalCount > 0)
            {
                string idList = "Danh sách ID của đối tượng:\n";
                foreach (ElementId el in selectElement)
                {
                    idList += el.ToString() + "\n";
                }
                MessageBox.Show(idList);
            }

            return Result.Succeeded;
        }
    }
}
