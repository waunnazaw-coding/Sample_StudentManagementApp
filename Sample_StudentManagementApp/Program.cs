using Sample_StudentManagementApp;




UsingEFCore usingEFCore = new UsingEFCore();
usingEFCore.MenuList();
int chooseMenu = Convert.ToInt32(Console.ReadLine());  

while (chooseMenu != 6)
{
    switch (chooseMenu)
    {
        case 1:

            usingEFCore.Read();
            break;

        case 2:

            Console.WriteLine("Enter Name => ");
            string name = Console.ReadLine() ?? "Not Vaild";

            Console.WriteLine("Enter Phone Number => ");
            string phNum = Console.ReadLine() ?? "Not Vaild";

            Console.WriteLine("Enter Class Name => ");
            string className = Console.ReadLine() ?? "Not Vaild";

            usingEFCore.Create(name, phNum, className);

            break;

        case 3:

            Console.WriteLine("Enter Id To Edit => ");
            int id = Convert.ToInt32(Console.ReadLine());

            usingEFCore.Edit(id);

            break;

        case 4:
            //Input For Updating
            Console.WriteLine("Enter Id to Update");
            int updateId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name to Update => ");
            string updateName = Console.ReadLine() ?? "Not Vaild";

            Console.WriteLine("Enter Phone Number to Update => ");
            string updatePhNum = Console.ReadLine() ?? "Not Vaild";

            Console.WriteLine("Enter Class Name to Update => ");
            string updateClassName = Console.ReadLine() ?? "Not Vaild";

            //Method Calling To Update
            usingEFCore.Update(updateId , updateName , updatePhNum , updateClassName);

            break;

        case 5:

            //Input For Deletion
            Console.WriteLine("Enter Id to Delete");
            int deleteId = Convert.ToInt32(Console.ReadLine());

            //Mehtod Calling for Deleting
            usingEFCore.Delete(deleteId);
            break;

        case 6:

            Console.WriteLine("Exiting the program.");

            break;

        default:

            Console.WriteLine("Invalid choice. Please choose again.");
            break;

    }
    usingEFCore.MenuList();
     chooseMenu = Convert.ToInt32(Console.ReadLine());
}
//usingEFCore.Read();
//usingEFCore.Create("YE MINN HTET", "09 8976754", "ASP.NET");
//usingEFCore.Edit(1);
//usingEFCore.Update(1, "THET PAING SOE", "098765432", "ENGINEERING");
//usingEFCore.Delete(9);

//Console.ReadLine();