using System;
using System.Collections.Generic;
using PizzaBoxDomain;
using PizzaBoxDomain.Interfaces;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using PizzaBoxDomain.Models;
using PizzaBoxStoring.Repositories;
using PizzaBoxStoring; 

namespace PizzaBoxClient
{
    class PizzaBoxProgram : IAuthentication
    {
        
       // static List<User> UserDataBase = new List<User>(); //What would eventually be a user database 
       // static List<Store> StoreDataBase = new List<Store>(); //What would eventually be a store database 

        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            var repo = Dependencies.CreatePizzaUserRepository();
            var PizzaUsers = repo.GetPizzaUser();

            var repoStore = Dependencies.CreatePizzaStoreRepository();
            var PizzaStores = repoStore.GetPizzaStore();

            
            Console.WriteLine("Database Connected\n");


        //Store Test 
        /*
        foreach (var st in PizzaStores)
        {
            Console.WriteLine($"{st.Storename} {st.PresetSpecial} ");
        }
        */


        //USER TEST 
        /*
        foreach (var pu in PizzaUsers)
        {
            Console.WriteLine($"{pu.Username}: {pu.FirstName} {pu.LastName}");

        }
        */


        Home:
            PizzaUsers = repo.GetPizzaUser();
            PizzaStores = repoStore.GetPizzaStore();
            SignOut:
            Console.WriteLine("Welcome to the PizzaBox Client \n Your Pie Awaits!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Are you a 'User' or a 'Store' ?\n");
            res1:
            string type = Console.ReadLine();

            // Authenticated Loggin or Sign Up 
            switch (type)
            {
                case "Store":
                    StoreLogin:
                    Console.WriteLine("Hello Store");
                    res1Store:
                    Console.WriteLine("Login or Sign Up");
                    string res1Store = Console.ReadLine();
                    switch (res1Store)
                    {
                        case "Login":
                            Console.Write("Storename: ");
                            string storename = Console.ReadLine();
                            Console.WriteLine();
                            System.Console.Write("Password: ");
                            string storepassword = null;

                            while (true)
                            {
                                var key = System.Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Enter)
                                    break;
                                storepassword += key.KeyChar;
                            }
                            try
                            {
                                foreach (var st in PizzaStores)
                                {
                                    if (st.Storename.Equals(storename) & (st.StorePassword.Equals(storepassword)))
                                    {
                                        Console.WriteLine($"Welcome back {st.Storename}");

                                        goto StoreSignedIn;
                                    }

                                }
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Nothing Found Here");

                            }
                            Console.WriteLine("Invalid Store Name or Password\n");
                            goto StoreLogin;


                        case "Sign Up":
                        StoreSignUp:
                            Console.WriteLine("Welcome Please Fill Out Your Information \n");

                            Console.Write("Store Name: ");
                            string su1 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Password: ");
                            string su2 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Cell: ");
                            string su3 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Store's Address: ");
                            string su4 = Console.ReadLine();
                            Console.WriteLine();

                            res2Store:
                            Console.WriteLine("Is This Information Correct? ");
                            Console.WriteLine("Store Name: " + su1);
                            Console.WriteLine("Password: " + su2);
                            Console.WriteLine("Store's Cell: " + su3);
                            Console.WriteLine("Store's Address: " + su4);
                            Console.WriteLine();
                            Console.WriteLine("Yes or No");

                            string resSignUpStore = Console.ReadLine();
                            switch (resSignUpStore)
                            {
                                case "Yes":

                                    PizzaStore temp = new PizzaStore(su1, su2, su3,su4);
                                    repoStore.AddPizzaStore(temp); 

                                    Console.WriteLine("Thank You for Registering Your Store on PizzaBox");
                                    goto Home;

                                case "No":
                                    goto StoreSignUp;


                                case "Home":
                                    goto Home;

                                default:
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid Input");
                                    goto res2Store;

                            }




                        case "Home":
                            goto Home;

                        default:
                            Console.WriteLine("Invalid Responce\n");
                            goto StoreLogin; 

                    }
                    

                


                case "User":
                    TypeUser:
                    Console.WriteLine("'Login' or 'Sign Up'");
                    string res1User = Console.ReadLine();
                    switch (res1User)
                    {
                        case "Login":
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.WriteLine();
                            System.Console.Write("Password: ");
                            string password = null;

                            while (true)
                            {
                                var key = System.Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Enter)
                                    break;
                                password += key.KeyChar;
                            }
                            try
                            {
                                foreach (var pu in PizzaUsers)
                                {
                                    if (pu.Username.Equals(username) & (pu.UserPassword.Equals(password)))
                                    {
                                        Console.WriteLine($"Welcome back {pu.FirstName}");

                                        goto UserSignedIn;
                                    }

                                }
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Nothing Found Here");

                            }
                            Console.WriteLine("No Matching User Name or Password");
                            goto TypeUser; 


                        case "Sign Up":
                            UserSignUp:
                            Console.WriteLine("Welcome Please Fill Out Your Information \n");

                            Console.Write("Username: ");
                            string su1 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Password: ");
                            string su2 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("First Name: ");
                            string su3 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Last Name: ");
                            string su4 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Cell: ");
                            string su5 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Address: ");
                            string su6 = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Email: ");
                            string su7 = Console.ReadLine();
                            Console.WriteLine();


                            Console.WriteLine("Is This Information Correct? ");
                            Console.WriteLine("Username: " + su1);
                            Console.WriteLine("Password: " + su2);
                            Console.WriteLine("First Name: " + su3);
                            Console.WriteLine("Last Name: " + su4);
                            Console.WriteLine("Cell: " + su5);
                            Console.WriteLine("Address: " + su6);
                            Console.WriteLine("Email " + su7);
                            Console.WriteLine("Yes or No");

                        res3:
                            string resSignUpUser = Console.ReadLine();
                            switch (resSignUpUser)
                            {
                                case "Yes":
                                    

                                    PizzaUser temp = new PizzaUser(su1,su2,su3,su4,su5,su6,su7);
                                   
                                    repo.AddPizzaUser(temp);
                                    Console.WriteLine("Thanks For Signing Up!");
                                    goto Home;


                                case "No":
                                    goto UserSignUp;


                                case "Home":
                                    goto Home;

                                default:
                                    Console.WriteLine("Invalid Input: Please Enter 'Yes' to confirm account , 'No' to re-enter your information or enter 'Home' to return to the main menu\n");
                                    goto res3;

                            }


                        

                        case "Home":
                            goto Home;

                        default:
                            Console.WriteLine("Invalid Input");
                            goto TypeUser;//Outer Default for Selecting User Type


                    }

            

                default: //Outer Default for Type
                    Console.WriteLine("Invalid Input");
                    goto Home; 
            }


        UserSignedIn:
            Console.WriteLine("Welcome Back. Lets Get Some Pizza");
            bool uLog = true;
            while (uLog)
            {
                InvRes:
                Console.WriteLine("Currently you can: \nView Pizza Locations : (View)\nSelect a Pizza Location: (Select <StoreName>)");
                Console.WriteLine("Look at your Order History: (History)");
                Console.WriteLine("Selecting a location will allow you to create an order");
                string ul1 = Console.ReadLine();


            }





        StoreSignedIn:
        Console.WriteLine("Welcome Back. Lets Sell Some Pizzas");



            /*


//--------------------------------------User View ------------------------
#region UserClient 
UserLogged:
Console.WriteLine("User Logged In \n");
bool uLOG = true;
while (uLOG)
{

Console.WriteLine("Welcome to PizzaBox\n");
InvRes:
Console.WriteLine("Currently you can: \nView Pizza Locations : (View)\nSelect a Pizza Location: (Select <StoreName>)");
Console.WriteLine("Look at your Order History: (History)");
Console.WriteLine("Selecting a location will allow you to create an order");
string ul1 = Console.ReadLine();

String[] splitul1 = ul1.Split(" ");
int lenUserArg = ul1.Length; 

if (lenUserArg == 1) //viewing Locations 
{
    switch (ul1)
    {

        case "View":
            ViewLocations:
            Console.WriteLine("Here are list of spots to grab a pie!\n");
            foreach (Store store in StoreDataBase)
            {
                Console.WriteLine();
                store.DisplayInfo(); 
            }
            goto InvRes;

        case "History":

            Console.WriteLine("Viewing Your History");
            currentUser.showHistory();
            goto InvRes;

        case"Home":
            uLOG = false; 
            goto Home;

        default:
            Console.WriteLine($"Invalid Input: {ul1} \n");
            goto InvRes; 
    }

}
else if(lenUserArg == 2)// used for selecting a location 
{
    switch (splitul1[0])
    {


        case "Select":
            bool storeExist = false;
            foreach (Store store in StoreDataBase)
            {
                if(store.getName().Equals(splitul1[1]))
                {
                    storeExist = true; 
                }
            }
            switch (storeExist)
            {
                case true:
                    goto UserStorePage; 

                case false:
                    Console.WriteLine("Store does not exist!");
                    goto InvRes; 
            }



        default:
            Console.WriteLine("Invalid Input");
            goto InvRes;

    }


}//else if 2 arguments 

else
{
    Console.WriteLine("Invalid Input:\n");
    goto InvRes;

}



UserStorePage:
Console.WriteLine("Lets take a look at the menus");
Console.WriteLine(splitul1[1]);

//in the database this instead could be the unique key or UUID 
Store curStore = StoreDataBase.Find((Store obj) => obj.getName().Equals(splitul1));
curStore.DisplayPresets();
startOrder:
Console.WriteLine("Would you like to start an order");
Console.WriteLine("Note: Starting and order adds you to Store's Account");
Console.WriteLine("'Yes' or 'No' ");
string startOrderRes = Console.ReadLine();
switch (startOrderRes)
{
    case "Yes":
        curStore.addUser(currentUser);
    StoreMenuPage:

        //HERE we will create the order object

        Order newUserOrder = new Order(); 

        Console.WriteLine("Ok! Lets get started with your order!");
        AnotherPizza:
        Console.WriteLine("Here is the menu again");
        curStore.DisplayPresets();
        Console.WriteLine("\nWould you like to add one of their presets pizzas: 'Preset'");
        Console.WriteLine("Or would you like to build your own custom pizza : 'Custom' ");
        string pizzaRes = Console.ReadLine();



        // possibly have the using block
        //to create an order  incase it should be destroyed later

        switch (pizzaRes)
        {
            case "Preset":
                PresetPizza:
                Console.WriteLine("What preset pizza would you like to add to your order");
                Console.WriteLine("Enter the number of the preset");
                curStore.DisplayPresets();
                string presetChoice = Console.ReadLine();

                try
                {

                }
                catch (Exception e) {

                    Console.WriteLine("Invalid Choice");
                    throw;

                }



                break;

            case "Custom":

                break;



            case "Cancel":
                goto UserLogged;

            case "Home":
                goto UserLogged;

            default:
                Console.WriteLine("Inv; lid Response");
                goto StoreMenuPage;

        }




        break;


    case "No":
        goto UserLogged; 


    case "Home":
        goto UserLogged;

    default:
        Console.WriteLine("Invalid Response");
        goto startOrder;
}



}// While User is Logged In 

#endregion UserClient




//---------------------------------Store View  ------------------------
#region StoreClient
StoreLogged:
Console.WriteLine("Store Logged In");
bool sLOG = true;
while (sLOG)
{

}
#endregion Store Client
*/

        }//Main 
    }//Class 
}//NameSpeace 
