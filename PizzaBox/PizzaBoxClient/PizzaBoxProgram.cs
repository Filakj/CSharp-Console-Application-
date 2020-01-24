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
    class PizzaBoxProgram 
    {

        // static List<User> UserDataBase = new List<User>(); //What would eventually be a user database 
        // static List<Store> StoreDataBase = new List<Store>(); //What would eventually be a store database 

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello");




            var repo = Dependencies.CreatePizzaUserRepository();
            var PizzaUsers = repo.GetPizzaUser();

            var repoStore = Dependencies.CreatePizzaStoreRepository();
            var PizzaStores = repoStore.GetPizzaStore();

            var repoOrder = Dependencies.CreatePizzaOrderRepository();
            var PizzaOrders = repoOrder.GetPizzaOrder();

            var repoPizza = Dependencies.CreatePizzaPizza();
            var Pizzas = repoPizza.GetPizza();

            Console.WriteLine("Database Connected\n");

        /*
        foreach (PizzaStore store in PizzaStores)
        {
            Console.WriteLine(store.Storename + " " + store.PresetSpecial + " ! " + store.PresetPizzaId);
        }
        */

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
            PizzaUser currentPizzaUser = null;
            PizzaStore currentPizzaStore = null;

            string storeChoice = null;

        SignOut:
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Welcome to the PizzaBox Client \n Your Pie Awaits!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Are you a 'User' or a 'Store' ?\n");
            Console.WriteLine("-----------------------------------------------------------------------");
        res1:
            string type = Console.ReadLine();


            // Authenticated Loggin or Sign Up 
            switch (type)
            {
                case "Quit":
                    goto Quit;

                case "Store":
                StoreLogin:
                    //Console.WriteLine("Hello Store");
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
                                        currentPizzaStore = st;

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

                                    PizzaStore temp = new PizzaStore(su1, su2, su3, su4);
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
                                        currentPizzaUser = pu;

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


                                    PizzaUser temp = new PizzaUser(su1, su2, su3, su4, su5, su6, su7);

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
            Console.Clear();
            Console.WriteLine("Welcome Back. Lets Get Some Pizza");

        InvRes:
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Currently you can: \nView Pizza Locations : (View)\nSelect a Pizza Location: (Select) ");
            Console.WriteLine("Look at your Order History: (History)");
            Console.WriteLine("Selecting a location will allow you to create an order");
            Console.WriteLine("-----------------------------------------------------------------------");
            string ul1 = Console.ReadLine();


            if (ul1.Equals("View")) {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("Here are list of spots to grab a pie!\n");

                PizzaStores = repoStore.GetPizzaStore();

                foreach (PizzaStore store in PizzaStores)
                {
                    //Console.Clear();
                    Console.WriteLine($"{store.Storename,-1} {store.StoreAddress,-4} {store.Cell,-4}");
                    //Console.Clear();

                }
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine();
                goto InvRes;
            }
            if (ul1.Equals("History")) {
                Console.Clear();
                Console.WriteLine("Viewing Your Order History\n");
                Console.WriteLine("-----------------------------------------------------------------------");

                var history = repoOrder.GetPizzaOrderHistoryUser(currentPizzaUser.Username);
                foreach (var order in history)
                {
                    
                    Console.WriteLine($"Order: {order.Orderid,-1} Store: {order.Storename,-4} {(decimal)order.Cost,-4} {order.OrderDate,-4}");
                }
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine();
                goto InvRes;
            }

            if (ul1.Equals("Home")) {
                Console.WriteLine("Logging Out\n");
                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                goto Home;
            }
            if (ul1.Equals("Select"))
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("What PizzaStore would you like to order from ? ");
                foreach (PizzaStore store in PizzaStores)
                {
                    Console.WriteLine($"{store.Storename,-1} Address:{store.StoreAddress,-4} Cell: {store.Cell,-4}");

                }
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine();
                string location = Console.ReadLine();
                bool storeExist = false;
                foreach (PizzaStore store in PizzaStores)
                {
                    if (store.Storename.Equals(location))
                    {
                        storeExist = true;

                    }
                }

                switch (storeExist)
                {
                    case true:
                        storeChoice = location;
                        goto UserStorePage;

                    case false:
                        Console.WriteLine("Location Does Not Exist");
                        goto InvRes;

                }

            }//Select
            else
            {
                Console.WriteLine("Invalid Input\n");
                goto InvRes;
            }


        UserStorePage:
        startOrder:
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Your store choice =  " + storeChoice);
            Console.WriteLine("Would you like to start an order");
            Console.WriteLine("-----------------------------------------------------------------------");
            //Console.WriteLine(storeChoice);
            //Console.WriteLine("Note: Starting and order adds you to Store's Account");
            Console.WriteLine("'Yes' or 'No' ");
            string resStartOrder = Console.ReadLine();
            if (resStartOrder.Equals("Yes"))
            {

                PizzaOrder TempOrder = new PizzaOrder();
                TempOrder.Username = currentPizzaUser.Username;
                TempOrder.Storename = storeChoice;
                int storeSpecialID;
                
                Console.WriteLine("Lets take a look at the menus");
                foreach (var pizzastore in PizzaStores)
                {
                    if (pizzastore.Storename.Equals(storeChoice))
                    {
                        storeSpecialID = (int)pizzastore.PresetPizzaId;

                     

                        string specialpizza = (pizzastore.PresetSpecial);
                        

                    
                        if (specialpizza.Length > 1)
                        {
                        wantSpecial:
                            Console.Clear();
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine($"The house special pizza is {specialpizza}");
                            Console.WriteLine("Would you like to add this to your order? Yes or No");
                            Console.WriteLine("-----------------------------------------------------------------------");
                            string resPresetPizza = Console.ReadLine();
                            switch (resPresetPizza)
                            {
                                case "Yes":
                                    //get pizza by id and get cost and ad to order

                                    TempOrder.PizzaOne = storeSpecialID;
                                    repoPizza = Dependencies.CreatePizzaPizza();
                                    TempOrder.Cost += repoPizza.GetPizzaPrice(storeSpecialID);
                                    

                                inResCont:
                                    Console.Clear();
                                    Console.WriteLine("-----------------------------------------------------------------------");
                                    Console.WriteLine("Your Current Total Is: $" + TempOrder.Cost);
                                    Console.WriteLine("Would you like to continue order with a custom Pizza? Yes or No");
                                    Console.WriteLine("-----------------------------------------------------------------------");
                                    string resContinue = Console.ReadLine();
                                    switch (resContinue) {
                                        case "Yes":
                                            Pizza tempPizza = new Pizza();
                                        createCustom:
                                            //Create Custom Pizza and Add it

                                            Console.Clear();
                                            Console.WriteLine("What kind of crust would you like:");
                                            String[] crusts = { "Regular", "Thin", "Deep Dish", "Stuffed" };
                                            String[] sizes = { "Small", "Medium", "Large", "X-Large" };

                                            foreach (String crust in crusts)
                                            {
                                                Console.WriteLine(crust);
                                            }
                                            string crustChoice = Console.ReadLine();
                                            switch (crustChoice)
                                            {
                                                case "Regular":
                                                case "Thin":
                                                case "Deep Dish":
                                                case "Stuffed":
                                                    tempPizza.Crust = crustChoice;
                                                    break;
                                                default:
                                                    Console.WriteLine("Invalid Input");
                                                    System.Threading.Thread.Sleep(2000);
                                                    goto createCustom;
                                            }
                                        pickSize:
                                            Console.Clear();
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            Console.WriteLine("What size pizza would you like?");
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            foreach (String size in sizes)
                                            {
                                                Console.WriteLine(size);
                                            }
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            string sizeChoice = Console.ReadLine();
                                            switch (sizeChoice)
                                            {
                                                case "Small":
                                                case "Medium":
                                                case "Large":
                                                case "X-Large":
                                                    tempPizza.Size = sizeChoice;
                                                    break;
                                                default:
                                                    Console.WriteLine("Invalid Input");
                                                    System.Threading.Thread.Sleep(2000);
                                                    goto createCustom;

                                            }

                                            Console.Clear();
                                        Toppings:
                                            Console.WriteLine("Add up to three toppings");
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            bool x = true;
                                            int toppings = 0;
                                            tempPizza.Pepper = 0;
                                            tempPizza.ExtraCheese = 0;
                                            tempPizza.Bacon = 0;
                                            tempPizza.Mozzerella = 0;
                                            tempPizza.Pepperoni = 0;
                                            tempPizza.Sausage = 0;
                                            tempPizza.Pineapple = 0;
                                            tempPizza.Onion = 0;
                                            tempPizza.Chicken = 0;
                                            while (x)
                                            {

                                                Console.WriteLine("Extra Cheese? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string cheese = Console.ReadLine();
                                                if (cheese.Equals("Yes")) {
                                                    tempPizza.ExtraCheese = 1;
                                                    toppings++;
                                                }
                                                else if (cheese.Equals("No"))
                                                {
                                                    tempPizza.ExtraCheese = 0;
                                                }
                                                else {
                                                    goto Toppings;
                                                }

                                                Console.WriteLine("Bacon? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string bacon = Console.ReadLine();
                                                if (bacon.Equals("Yes"))
                                                {
                                                    tempPizza.Bacon = 1;
                                                    toppings++;
                                                }
                                                else if (bacon.Equals("No"))
                                                {
                                                    tempPizza.Bacon = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }
                                                Console.WriteLine("Pepperoni? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string pepe = Console.ReadLine();
                                                if (pepe.Equals("Yes"))
                                                {
                                                    tempPizza.Pepperoni = 1;
                                                    toppings++;
                                                }
                                                else if (pepe.Equals("No"))
                                                {
                                                    tempPizza.Pepperoni = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }
                                                Console.WriteLine("Mozzerella? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string moz = Console.ReadLine();
                                                if (moz.Equals("Yes"))
                                                {
                                                    tempPizza.Mozzerella = 1;
                                                    toppings++;
                                                }
                                                else if (moz.Equals("No"))
                                                {
                                                    tempPizza.Mozzerella = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }
                                                Console.WriteLine("Sausage? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string sau = Console.ReadLine();
                                                if (sau.Equals("Yes"))
                                                {
                                                    tempPizza.Sausage = 1;
                                                    toppings++;
                                                }
                                                else if (sau.Equals("No"))

                                                {
                                                    tempPizza.Sausage = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }
                                                Console.WriteLine("Pineapple? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string pine = Console.ReadLine();

                                                if (pine.Equals("Yes"))
                                                {
                                                    tempPizza.Pineapple = 1;
                                                    toppings++;
                                                }
                                                else if (pine.Equals("No"))
                                                {
                                                    tempPizza.Pineapple = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }
                                                Console.WriteLine("Onions? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string oni = Console.ReadLine();
                                                if (oni.Equals("Yes"))
                                                {
                                                    tempPizza.Onion = 1;
                                                    toppings++;
                                                }
                                                else if (oni.Equals("No"))
                                                {
                                                    tempPizza.Onion = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }
                                                Console.WriteLine("Chicken? Yes or No");
                                                Console.WriteLine("-----------------------------------------------------------------------");
                                                string chi = Console.ReadLine();
                                                if (chi.Equals("Yes"))
                                                {
                                                    tempPizza.Chicken = 1;
                                                    toppings++;
                                                }
                                                else if (chi.Equals("No"))
                                                {
                                                    tempPizza.Chicken = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }
                                                Console.WriteLine("Peppers? Yes or No");
                                                string pep = Console.ReadLine();
                                                if (cheese.Equals("Yes"))
                                                {
                                                    tempPizza.Pepper = 1;
                                                    toppings++;
                                                }
                                                else if (pep.Equals("No"))
                                                {
                                                    tempPizza.Pepper = 0;
                                                }
                                                else
                                                {
                                                    goto Toppings;
                                                }



                                                if (toppings > 3)
                                                {
                                                    Console.WriteLine("TOO MANY TOPPINGS ! CHOOSE TOPPINGS AGAIN");
                                                    Console.WriteLine("-----------------------------------------------------------------------");
                                                    System.Threading.Thread.Sleep(2000);
                                                    goto Toppings;
                                                }
                                                if (toppings < 4)
                                                {
                                                    x = false;
                                                }




                                            }//while

                                            tempPizza.Cost = (decimal)tempPizza.ComputePrice(toppings);
                                            TempOrder.Cost += tempPizza.Cost;

                                            repoPizza = Dependencies.CreatePizzaPizza();
                                            repoPizza.AddPizza(tempPizza);
                                            Pizzas = repoPizza.GetPizza();

                                            int newID = repoPizza.GetLastPizza();
                                            TempOrder.PizzaTwo = Convert.ToInt32(newID);
                                            Console.Clear();
                                        SubmitO:
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            Console.WriteLine($"So your total is {TempOrder.Cost}");
                                            Console.WriteLine("Would you like to confirm and place your order? Yes or No?");
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            string placeOrder = Console.ReadLine();

                                            switch (placeOrder)
                                            {
                                                case "Yes":
                                                    Console.Clear();
                                                    repoOrder.AddPizzaOrder(TempOrder);
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    Console.WriteLine("Done");
                                                    Console.WriteLine("Your Pizza Should Arrive in 30 Minutes or Less");
                                                    System.Threading.Thread.Sleep(3000);
                                                    goto UserSignedIn;


                                                case "No":
                                                    Console.WriteLine("The Pizza Didnt Want You Either!");
                                                    Console.WriteLine("Discarding Order");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    Console.WriteLine("Done");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Clear();
                                                    goto UserSignedIn;

                                                default:
                                                    Console.WriteLine("Invalid Input");
                                                    System.Threading.Thread.Sleep(3000);
                                                    goto SubmitO;
                                            }




                                        case "No":
                                        NoMore:
                                            Console.Clear();
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            Console.WriteLine("Confirm Order? Yes or No");
                                            Console.WriteLine("'No' will discard your order");
                                            Console.WriteLine("-----------------------------------------------------------------------");
                                            string endOrder = Console.ReadLine();
                                            switch (endOrder)
                                            {
                                                case "Yes":


                                                    repoOrder.AddPizzaOrder(TempOrder);
                                                    //TODO in API update so order does not get posted if it is alread there
                                                    Console.WriteLine("-----------------------------------------------------------------------");
                                                    Console.WriteLine("Your pizza is being crafted as we speak");
                                                    Console.WriteLine("The pizza will be delievered in 30 mins or less");
                                                    Console.WriteLine("-----------------------------------------------------------------------");
                                                    System.Threading.Thread.Sleep(3000);

                                                    goto UserSignedIn;


                                                case "No":
                                                Discarding:
                                                    Console.WriteLine("-----------------------------------------------------------------------");
                                                    Console.WriteLine("The Pizza Didnt Want You Either!");
                                                    Console.WriteLine("Discarding Order");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Write(".");
                                                    Console.WriteLine("Done");
                                                    Console.WriteLine("Taking You back to the User Homepage");
                                                    System.Threading.Thread.Sleep(3000);
                                                    Console.Clear();

                                                    goto UserSignedIn;

                                                default:
                                                    Console.WriteLine("Invalid Response\n");
                                                    System.Threading.Thread.Sleep(3000);
                                                    goto NoMore;
                                            }



                                            break;
                                        default:
                                            Console.WriteLine("Invalid Responce\n");
                                            System.Threading.Thread.Sleep(3000);
                                            goto inResCont;
                                    }

                                    break;

                                case "No":
                                    goto strrtCustom;
                                    break;


                                default:
                                    Console.WriteLine("Invalid Response\n");

                                    goto wantSpecial;

                            }
                        }
                        else
                        {
                        resStartOrder1:
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine("This store has no special! Lets customize a pizza for you!");
                            goto strrtCustom;// Make Custom 

                        }



                    }
                }
            strrtCustom:
                Console.WriteLine();
                Console.Clear();

            }
            if (resStartOrder.Equals("No"))
            {
                goto UserSignedIn;
            }
            else
            {
                Console.WriteLine("Invalid Response");
                goto startOrder;
            }//NOT Starting Order





        StoreSignedIn:
            Console.Clear();
            ValidStoreInput:
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Welcome Back. Lets Sell Some Pizzas\n");
            Console.WriteLine("Currently you can: \nView Compleyed Orders: (Orders)\nView Sales: (Sales) ");
            Console.WriteLine("Look at your customers: (Users)");
            Console.WriteLine("-----------------------------------------------------------------------");
            repoOrder = Dependencies.CreatePizzaOrderRepository();
            var pizzaOrdersForStore = repoOrder.GetOrders(currentPizzaStore.Storename);

            string sl1 = Console.ReadLine();
            switch (sl1)
            {
                case("Orders"):
                    Console.WriteLine("Lets view those completed orders");

                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine("");
                    foreach (PizzaOrder o in pizzaOrdersForStore)
                    {
                        Console.WriteLine($"{o.Username,-10} {o.Cost,-15} {o.OrderDate,-20}");
                    }
                    goto ValidStoreInput;


                case ("Sales"):
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine("Lets look at the income");
                    //Query Method
                    int count = 0;
                    decimal totalSales = 0.0m;
                    foreach(PizzaOrder o in pizzaOrdersForStore)
                    {
                        count++;
                        totalSales = totalSales + (decimal)o.Cost;
                    }
                    Console.WriteLine("Total Number of Sales: " + count);
                    Console.WriteLine("Total Revenue: " + totalSales);
                    Console.WriteLine("-----------------------------------------------------------------------");
                    goto ValidStoreInput;

                case ("Users"):
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine("Lets look at all the users registered with your store");
                    Console.WriteLine("-----------------------------------------------------------------------");

                    pizzaOrdersForStore = repoOrder.GetOrders(currentPizzaStore.Storename);
                    var RepoUser = Dependencies.CreatePizzaUserRepository();
                    var namesForStore = RepoUser.GetPizzaUser();

                    foreach (PizzaOrder o in pizzaOrdersForStore)
                    {
                        Console.WriteLine($"{o.Username,-10} ");
                    }

                    goto ValidStoreInput; 

                case ("Logout"):
                    Console.WriteLine("Signing Off...");

                    goto Home;



                default:
                    Console.WriteLine("Invalid Input");
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                    goto StoreSignedIn;
                   

            }



        Quit:
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Thank You For Using PizzaBox\n Have a pie day! ");


        }//Main 
    }//Class 
}//NameSpeace 
