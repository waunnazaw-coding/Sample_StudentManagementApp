using Sample_StudentManagementApp;

UsingEFCore usingEFCore = new UsingEFCore();
UsingDapper Dapper = new UsingDapper();
UsingAdo Ado = new UsingAdo();
MenuList();
int chooseMenu = Convert.ToInt32(Console.ReadLine());

while (chooseMenu != 6)
{
    switch (chooseMenu)
    {
        case 1:

            //usingEFCore.Read();
            //Dapper.Read();
            Ado.Read();
            break;

        case 2:

            //usingEFCore.Create();
            //Dapper.Create();
            Ado.Create();
            break;

        case 3:

            //usingEFCore.Edit();
            //Dapper.Edit();
            Ado.Edit();
            break;

        case 4:

            //Method Calling To Update
            //usingEFCore.Update();
            //Dapper.Update();
            Ado.Update();
            break;

        case 5:
            //Mehtod Calling for Deleting
            //usingEFCore.Delete();
            //Dapper.Delete();
            Ado.Delete();
            break;

        case 6:

            Console.WriteLine("Exiting the program.");

            break;

        default:

            Console.WriteLine("Invalid choice. Please choose again.");
            break;

    }
    MenuList();
    chooseMenu = Convert.ToInt32(Console.ReadLine());
}
//usingEFCore.Read();
//usingEFCore.Create("YE MINN HTET", "09 8976754", "ASP.NET");
//usingEFCore.Edit(1);
//usingEFCore.Update(1, "THET PAING SOE", "098765432", "ENGINEERING");
//usingEFCore.Delete(9);

//Console.ReadLine();

//UsingDapper Dapper = new UsingDapper();
//Dapper.Read();
//Dapper.Create();
//Dapper.Edit();
//Dapper.Update(4);
//Dapper.Delete();

//UsingAdo Ado = new UsingAdo();
//Ado.Read();
//Ado.Create();
//Ado.Edit();
//Ado.Update(5);
//Ado.Delete();

static void MenuList()
{
    Console.WriteLine("----- MENU LISTS -----");
    Console.WriteLine("1 . READ ALL STUDENTS ! ");
    Console.WriteLine("2 . CREATE OR ADD NEW STUDENT ! ");
    Console.WriteLine("3 . EDIT STUDENT ! ");
    Console.WriteLine("4 . UPDATE STUDENT ! ");
    Console.WriteLine("5 . DELETE STUDENT  ! ");
    Console.WriteLine("6 . TO EXIST ! ");
    Console.WriteLine("Choose Funtion (1 - 6) =>  ");
}

