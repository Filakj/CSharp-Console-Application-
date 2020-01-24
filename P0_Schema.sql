USE master
GO
CREATE DATABASE Revature
GO
use Revature;
go;
create schema PizzaBox; 
go;

--Pizza Table
create table PizzaBox.Pizza(
    pid INT PRIMARY KEY Identity(1,1),
    cost MONEY NOT NULL, 
    crust VARCHAR(10) NOT NULL CHECK (crust IN ('Regular','Thin','Deep Dish','Stuffed')),
    size VARCHAR(10) NOT NULL CHECK (size IN ('Small','Medium','Large','X-Large')), 
    cheese INT default(1),
    sauce INT default(1),
    extra_cheese INT NOT NULL CHECK (extra_cheese = 0 OR extra_cheese = 1), 
    bacon INT NOT NULL CHECK (bacon = 0 OR bacon = 1), 
    pepperoni INT NOT NULL CHECK (pepperoni = 0 OR pepperoni = 1), 
    mozzerella INT NOT NULL CHECK (mozzerella = 0 OR mozzerella = 1), 
    sausage INT NOT NULL CHECK (sausage = 0 OR sausage = 1), 
    pineapple INT NOT NULL CHECK (pineapple = 0 OR pineapple = 1), 
    onion INT NOT NULL CHECK (onion = 0 OR onion = 1), 
    chicken INT NOT NULL CHECK (chicken = 0 OR chicken = 1), 
    pepper INT NOT NULL CHECK (pepper = 0 OR pepper = 1), 
    CONSTRAINT limit_toppings CHECK (cheese + sauce + bacon + pepperoni + mozzerella + sausage + pineapple + onion + chicken + pepper  <= 5)
)

---- Store TABLE ---- 
create table PizzaBox.PizzaStore(
storename VARCHAR(20) PRIMARY KEY,
store_password VARCHAR(20) not null, 
cell VARCHAR(10) not null, 
store_address VARCHAR(50) not null,
preset_special VARCHAR(30), 
preset_pizza_ID INT FOREIGN KEY REFERENCES PizzaBox.Pizza(pid), 
store_join_date smalldatetime DEFAULT(getdate()),

)

-- USER SIDE 
create table PizzaBox.PizzaUser(
username VARCHAR(20) PRIMARY KEY,
user_password VARCHAR(20) not null, 
first_name varchar(20) not null, 
last_name varchar(20) not null,
cell VARCHAR(10) not null, 
user_address VARCHAR(50) not null, 
email VARCHAR(30) not null, 
last_order_time smalldatetime default(null), 
last_order_store VARCHAR(20) default(null) FOREIGN KEY REFERENCES PizzaBox.PizzaStore(storename), 
user_join_date smalldatetime DEFAULT(getdate())
)

GO;

-------USER ABOVE ----- 

CREATE TABLE PizzaBox.PizzaOrder(
    orderid INT PRIMARY KEY IDENTITY(1000,1), 
    username VARCHAR(20)NOT NULL,
    storename VARCHAR(20) NOT NULL,
    cost MONEY NOT NULL CHECK (cost <= 250.00), 
    pizza_one INT NOT NULL, 
    pizza_two INT ,
    pizza_three INT ,
    pizza_four INT ,
    pizza_five INT ,
    pizza_six INT ,
    pizza_seven INT ,
    pizza_eight INT ,
    pizza_nine INT ,
    pizza_ten INT,
    order_date smalldatetime DEFAULT(getdate()),
    
    
    --FOREIGN KEYS FROM USER AND STORE WILL HELP WITH QUERYING FROM OTHER TABLES
    FOREIGN KEY (username) REFERENCES PizzaBox.PizzaUser(username), 
    FOREIGN KEY (storename) REFERENCES PizzaBox.PizzaStore(storename),
    -- PIZZAS IN ORDER WILL REPRESENT PIZZAS FROM THE PIZZA TABLE 
    FOREIGN KEY (pizza_one) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_two) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_three) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_four) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_five) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_six) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_seven) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_eight) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_nine) REFERENCES PizzaBox.Pizza(pid),
    FOREIGN KEY (pizza_ten) REFERENCES PizzaBox.Pizza(pid)
)


GO; 
--INSERT TRIGGER THAT CONNECTS USER TO LAST ORDER 
CREATE TRIGGER PizzaBox.trg_order  
    ON PizzaBox.PizzaOrder
    AFTER INSERT
    AS 
    BEGIN
        UPDATE PizzaBox.PizzaUser
        SET last_order_time = GETDATE()
        FROM Inserted i
        WHERE PizzaUser.username = i.username
    END

  GO; 

--INSERT TRIGGER THAT CONNECTS USER TO LAST ORDER 
CREATE TRIGGER PizzaBox.trg_order2  
    ON PizzaBox.PizzaOrder
    AFTER INSERT
    AS 
    BEGIN
        UPDATE PizzaBox.PizzaUser
        SET last_order_store = i.storename
        FROM Inserted i
        WHERE PizzaUser.username = i.username
    END
  
