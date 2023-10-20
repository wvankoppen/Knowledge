<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Dynamic</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	object x = new {X = "123"};
	PrintVar(x);
	x = new {X = new int[1]};
	PrintVar(x);
	
	dynamic props = new ExpandoObject();
	props.group1 = new ExpandoObject();
	props.group2 = new ExpandoObject();
	props.group1.item1 = "hi";
	props.group1.item2 = "there";
	props.group1.item3 = "you";
	
	var json = JsonConvert.SerializeObject(props);
	Console.Write(json);


	//GenerateExcelSheet();
}

private void PrintVar(dynamic x)
{
	Console.Write(x);
	Console.Write(x.X);
}

private void GenerateExcelSheet()
{
	// Excel must be installed
	Type excelType = Type.GetTypeFromProgID("Excel.Application", true);
	
	// Because CreateInstance returns an object, we either have to use dynamic or reflection! Chose the former.
	dynamic excel = Activator.CreateInstance(excelType);
	excel.Visible = true;
	excel.Workbooks.Add();
	excel.ActiveSheet.Cells[1, "A"] = "Hello there!";
}