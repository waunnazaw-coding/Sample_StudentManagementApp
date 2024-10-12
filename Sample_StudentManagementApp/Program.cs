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

            usingEFCore.Create();

            break;

        case 3:

            usingEFCore.Edit();

            break;

        case 4:

            //Method Calling To Update
            usingEFCore.Update();

            break;

        case 5:
            //Mehtod Calling for Deleting
            usingEFCore.Delete();
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