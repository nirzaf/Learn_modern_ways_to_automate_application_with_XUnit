using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EATestFramework.Extensions;
public static class HtmlTableExtension
{
    //Read of Table
    private static List<TableDatacollection> ReadTable(IWebElement table)
    {
        //Initialize the table
        var tableDataCollection = new List<TableDatacollection>();

        //Get all the columns from the table
        var columns = table.FindElements(By.TagName("th"));

        //Get all the rows
        var rows = table.FindElements(By.TagName("tr"));

        //Create row index
        int rowIndex = 0;
        foreach (var row in rows)
        {
            int colIndex = 0;

            var colDatas = row.FindElements(By.TagName("td"));
            //Store data only if it has value in row
            if (colDatas.Count != 0)
                foreach (var colValue in colDatas)
                {
                    tableDataCollection.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ?
                                     columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text,
                        ColumnSpecialValues = GetControl(colValue)
                    });

                    //Move to next column
                    colIndex++;
                }
            rowIndex++;
        }

        return tableDataCollection;
    }

    private static ColumnSpecialValue GetControl(IWebElement columnValue)
    {
        ColumnSpecialValue? columnSpecialValue = null;
        //Check if the control has specfic tags like input/hyperlink etc
        if (columnValue.FindElements(By.TagName("a")).Count > 0)
        {
            columnSpecialValue = new ColumnSpecialValue
            {
                ElementCollection = columnValue.FindElements(By.TagName("a")),
                ControlType = ControlType.hyperlink
            };
        }
        if (columnValue.FindElements(By.TagName("input")).Count > 0)
        {
            columnSpecialValue = new ColumnSpecialValue
            {
                ElementCollection = columnValue.FindElements(By.TagName("input")),
                ControlType = ControlType.input
            };
        }

        return columnSpecialValue;
    }

    public static void PerformActionOnCell(this IWebElement element, string targetColumnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
    {
        //First read the table
        var table = ReadTable(element);

        //iterate in the table and get the type of cell you are looking for
        foreach (int rowNumber in GetDynamicRowNumber(table, refColumnName, refColumnValue))
        {
            var cell = (from e in table
                        where e.ColumnName == targetColumnIndex && e.RowNumber == rowNumber
                        select e.ColumnSpecialValues).SingleOrDefault();

            //Need to operate on those controls
            if (controlToOperate != null && cell != null)
            {
                IWebElement? elementToClick = null;
                //Since based on the control type, the retriving of text changes
                //created this kind of control
                if (cell.ControlType == ControlType.hyperlink)
                {
                    elementToClick = (from c in cell.ElementCollection
                                      where c.Text == controlToOperate.ToString()
                                      select c).SingleOrDefault();

                }
                if (cell.ControlType == ControlType.input)
                {
                    elementToClick = (from c in cell.ElementCollection
                                      where c.GetAttribute("value") == controlToOperate.ToString()
                                      select c).SingleOrDefault();

                }

                //ToDo: Currenly only click is supported, future is not taken care here
                elementToClick?.Click();

            }
            else
            {
                cell.ElementCollection?.First().Click();
            }
        }

    }

    private static IEnumerable GetDynamicRowNumber(List<TableDatacollection> tableCollection, string columnName, string columnValue)
    {
        //dynamic row
        foreach (var table in tableCollection)
        {
            if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                yield return table.RowNumber;
        }
    }




}

public class TableDatacollection
{
    public int RowNumber { get; set; }
    public string? ColumnName { get; set; }
    public string? ColumnValue { get; set; }
    public ColumnSpecialValue? ColumnSpecialValues { get; set; }
}

public class ColumnSpecialValue
{
    public IEnumerable<IWebElement>? ElementCollection { get; set; }
    public ControlType? ControlType { get; set; }
}

public enum ControlType
{
    hyperlink,
    input,
    option,
    select
}
