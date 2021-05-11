# ITSuite Community
ITSuite Community is a web application for IT Service Desk services. ITSuite can manage asset management, IT assistance requests (trouble ticketing), network services and many more.

Our ITSuite project is a web application that allows you to manage all the technical assistance and asset management services of an IT company.
We have made our software open source because we believe that IT technical support is a fundamental service and we want to be ready to help those who would like to open a new IT support company.
This community version is based on Microsoft SQL Server LocalDB but it is always possible to modify the connection to your liking. It is derived from the first version of ITSuite and all those who want to support the growth of this software are welcome!

If you are looking for the binary version with ready-made sample database, go to https://www.ameamer.com/itsuite/.

The complete guide for installing ITSuite in local IIS can be found at https://www.ameamer.com/guidepages/default.aspx?id=3.

Below is a brief guide on the prerequisites before starting the ITSuite Community project in Visual Studio.

Database creation with minimum mandatory data (user: admin, password: adminadmin):

* Open the project in Visual Studio 2019;
* Create a new SQL Server database called **itstdb.mdf** in **App_Data** folder;
* Run the queries contained in the "**App_Data\SQL**" folder. Run files starting with "**LAST**" last;
* At this point it will be possible to start the project by accessing ITSuite with the admin / adminadmin credentials. 

You can download the complete itstdb.mdf file with examples from https://www.ameamer.com/download/.
