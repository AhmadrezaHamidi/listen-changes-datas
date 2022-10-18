We have a windows application (windowsForm,wpf) which is connected to a data base. 
We need to notice database changes every minute in order to notify updates to our users .
Instructions :
	1.	Setting up a CDC data base
<img width="337" alt="Screen Shot 1401-07-25 at 14 02 05" 
src="https://user-images.githubusercontent.com/61118112/196400255-17265a91-df07-4e64-aeab-37b78154562a.png">
	
	
	</br>
	2.	Reading data from data base by View
	3.	Setting up a sample code webAPI and a DB context for reading data from database
	4.	Setting up Signal R Hub in order to connect users to Hub
	5.	Setting up a background service and noticing database changes every 5 minutes and sending these changes to Signal R Hub
